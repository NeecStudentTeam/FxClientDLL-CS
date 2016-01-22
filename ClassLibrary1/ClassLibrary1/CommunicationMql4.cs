using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codeplex.Data;
using System.Reflection;

namespace MT4DLL
{
    class CommunicationMql4
    {
        SocketMessenger messenger;

        IMql4ExceptionThrower thrower;

        public const int CALL_FUNC = 1;
        public const int CALL_FUNC_RESULT = 2;
        public const int CALL_MT4_SPECIAL_FUNC = 3;
        public const int CALL_MT4_SPECIAL_FUNC_RESULT = 4;
        public const int CLIENT_INFO = 5;
        public const int SERVER_INFO = 6;

        public const int CLIENT_STATE_EXIT = 1;
        public const int SERVER_STATE_EXIT = 1;

        public delegate string ResvSpecialFunction(string funcName, string[] paramArr);

        public ResvSpecialFunction resvSpecialFunctionEvent = null;
  
        public CommunicationMql4()
        {
            //エクセプションスロワーを設定
            thrower = new Mql4ExceptionThrowerStub();
        }

        public int Connect(string server, int port)
        {
            if(messenger == null)
            {
                messenger = new SocketMessenger();
                return messenger.Connect(server, port);
            }
            return 0;
        }

        public bool isConnected()
        {
            return messenger == null ? false : messenger.isConnected();
        }

        public bool WaitSpecialFunction()
        {

            dynamic resvJson = ResvJson(CALL_MT4_SPECIAL_FUNC);

            int resv = (int)resvJson["type"];
            
            if(resv != CALL_MT4_SPECIAL_FUNC)
            {
                //終了
                return false;
            }

            
            string result = resvSpecialFunctionEvent(resvJson["name"],resvJson["params"]);

            SendJson(CALL_MT4_SPECIAL_FUNC_RESULT, resvJson["name"], result);

            return true;
        }

        /// <summary>
        /// CallMql4を使用する。戻り値を型パラメータでキャスト
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callType"></param>
        /// <param name="callName"></param>
        /// <param name="paramObjArr"></param>
        /// <returns></returns>
        public T CallMql4<T>(int callType, string callName, params object[] paramObjArr)
        {
            //戻り値
            T result = default(T);

            //MQL4の関数を読んで戻り値をstringでもらう
            string resultStr = CallMql4(callType, callName, paramObjArr);

            //キャストの為にオブジェクトのParseメソッドをGet
            //確認したParseメソッドは以下
            //int.Parse,string.Parse,double.Parse,long.Parse,MT4DateTime.Parse,MT4Color.Parse
            MethodInfo parse = typeof(T).GetMethod("Parse", new Type[]{typeof(string)});

            //Parseメソッドがあったか
            if (parse != null)
            {
                try
                {
                    //あったのでParse
                    result = (T)parse.Invoke(null, new object[]{resultStr});
                }
                catch(TargetInvocationException e)
                {
                    //InnerExceptionがFormatExceptionかどうか
                    if (e.InnerException is FormatException)
                    {
                        //Parseに失敗したのでCast
                        result = (T)Convert.ChangeType(resultStr, typeof(T));
                    }
                    else
                    {
                        //よくわからんエラーだったので再スロー
                        throw;
                    }
                }
            }
            else
            {
                //なかったのでCast
                result = (T)Convert.ChangeType(resultStr, typeof(T));
            }

			//MQL4の関数の戻り値がエラーかどうか
			thrower.CheckError(callName, result);

            //返す
            return result;
        }

        //mql4の関数を呼ぶ
        private string CallMql4(int callType, string funcName, params object[] paramObjArr)
        {

            //string param list
            List<string> paramStrList = new List<string>();

            //ObjectをStringに変換
            if (paramObjArr != null)
            {
                for (int i = 0; i < paramObjArr.Length; i++)
                {
                    paramStrList.Add(paramObjArr[i] == null ? null : paramObjArr[i].ToString());
                }
            }
            else
            {
                paramStrList = null;
            }

            //送る
            SendJson(callType, funcName, paramStrList == null ? null : paramStrList.ToArray());

            //受け取る
            dynamic json = ResvJson(callType+1);

            //エラー処理
            if ((int)json["type"] != callType+1)
            {
                throw new JsonTypeException();
            }

            //戻り値
            string result = json["result"].ToString();

            return result;
        }

        public int Disconnect()
        {
            //json作成
            dynamic json = new DynamicJson();

            //値入れ込み
            json["type"] = CLIENT_INFO;

            //正常終了ステータス
            json["state"] = CLIENT_STATE_EXIT;

            //シリアライズ
            string jsonStr = json.ToString();

            //Send
            int ret = messenger.SendMessage(jsonStr);

            //戻り値
            return ret;
        }

        /// <summary>
        /// jsonTypeに一致するメッセージが受信されるまで待つ。
        /// 一致されるメッセージが受信された、されていたらそれをDynamicJsonにかけて返す
        /// </summary>
        /// <param name="jsonType">jsonの"type"キー</param>
        /// <returns>DynamicJson</returns>
        protected dynamic ResvJson(int jsonType)
        {
            //戻り値
            string resultMsg = null;
            dynamic resultDynamic = null;
            
            //値が入るまで回す
            while (resultMsg == null || resultDynamic == null)
            {
                //メッセージリスト取得&Recv
                var msgs = this.messenger.GetRecvMsgs();

                //リストの中身を回す
                foreach (string msg in msgs)
                {
                    //パース
                    dynamic json = DynamicJson.Parse(msg);
                    //jsonType判定
                    if (((int)json["type"]) == jsonType)
                    {
                        //戻り値に入れる
                        resultMsg = msg;
                        resultDynamic = json;
                        //foreachを抜ける
                        break;
                    }
                    //サーバーが終了した
                    else if (((int)json["type"]) == SERVER_INFO && ((int)json["state"]) == SERVER_STATE_EXIT)
                    {
                        throw new ServerClosedException();
                    }
                }
            }

            //値が入っていたらメッセージリストから消す
            this.messenger.GetRecvMsgs().Remove(resultMsg);

            //パースしたjsonを返す
            return resultDynamic;
        }

        protected bool SendJson(int sendType, string funcName, params string[] paramArr)
        {
            //json作成
            dynamic json = new DynamicJson();

            //値入れ込み
            json["type"] = sendType;

            //値入れ込み(param or result)
            switch(sendType)
            {
                case CALL_FUNC:
                case CALL_MT4_SPECIAL_FUNC:
                    json["name"] = funcName;
                    json["params"] = paramArr != null && paramArr.Length > 0 ? paramArr : null;
                    break;
                case CALL_FUNC_RESULT:
                case CALL_MT4_SPECIAL_FUNC_RESULT:
                    json["result"] = paramArr != null && paramArr.Length > 0 ? paramArr[0] : null;
                    break;
                default:
                    Log.Write("SendJsonerror");
                    throw new Exception();
            }
            //シリアライズ
            string jsonStr = json.ToString();
            //Send
            int ret = messenger.SendMessage(jsonStr);
            return ret == 0;
        }

        class JsonTypeException : Exception
        {
            public JsonTypeException() : base() {}
        }

        class ServerClosedException : Exception
        {
            public ServerClosedException() : base() { }
        }
    }
}
