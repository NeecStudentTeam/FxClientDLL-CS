using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MT4DLL
{
    public partial class MT4 : IMT4
    {
        CommunicationMql4 com = null;
        
        public MT4()
        {
        }

        public virtual int OnInit()
        {
            return 0;
        }

        public int Connect(string server = "127.0.0.1", int port = 9999)
        {
            if (com == null)
            {
                //インスタンス化＆接続
                com = new CommunicationMql4();
                return com.Connect(server,port);
            }
            else
            {
                return 0;
            }
        }

        public bool isConnected()
        {
            return com == null ? false : com.isConnected();
        }

        public int Disconnect()
        {
            return com == null ? 1 : com.Disconnect();
        }


        public void Start()
        {
            Connect();

            //リフレクションでメソッドを呼ぶDelegateをラムダ式で作成。comに入れる。
            com.resvSpecialFunctionEvent = (string funcName, string[] paramStrArr) =>
                {
                    //メソッドをゲット
                    MethodInfo method = this.GetType().GetMethod(funcName);

                    //エラー処理
                    if(method == null || !method.IsVirtual)
                    {
                        throw new Exception();
                    }

                    //メソッドの引数の情報をゲット
                    ParameterInfo[] paramInfos = method.GetParameters();

                    //メソッドの引数を入れる物
                    List<Object> paramObjList = new List<Object>();

                    //メソッドの引数のTypeでキャストする
                    //paramStrArrがNullだったら実行しない
                    for(int i = 0; paramStrArr != null && i < paramStrArr.Length; i++)
                    {
                        //引数一致しなかったらエラー
                        if(!(paramInfos.Length < i))
                        {
                            throw new Exception();
                        }

                        //paramのString
                        string paramStr = paramStrArr[i];

                        //paramのInfo
                        ParameterInfo paramInfo = paramInfos[i];

                        //キャストの為にParseメソッドをGet
                        //確認したParseメソッドは以下
                        //int.Parse,string.Parse,double.Parse,long.Parse
                        MethodInfo parse = paramInfos[i].ParameterType.GetMethod("Parse");

                        //Parseメソッドがあったか
                        if(parse != null)
                        {
                            try
                            {
                                //あったのでParse
                                object parsedObj = parse.Invoke(null, new string[] { paramStr });
                                //追加
                                paramObjList.Add(parsedObj);
                            }
                            catch (TargetInvocationException e)
                            {
                                //InnerExceptionがFormatExceptionかどうか
                                if (e.InnerException is FormatException)
                                {
                                    //Parseに失敗したのでCast＆追加
                                    paramObjList.Add(Convert.ChangeType(paramStrArr[i], paramInfos[i].ParameterType));
                                }
                                else
                                {
                                    throw;
                                }
                            }
                        }
                        else
                        {
                            //なかったのでCast＆追加
                            paramObjList.Add(Convert.ChangeType(paramStrArr[i], paramInfos[i].ParameterType));
                        }

                    }

                    //メソッドの引数の配列を作成
                    //paramObjListがnullか要素数0ならnull、それ以外ならparamObjListの内容を入れる
                    object[] paramObjArr = paramObjList == null || paramObjList.Count == 0 ? null : paramObjList.ToArray();

                    //メソッド実行
                    object result = method.Invoke(this, paramObjArr);

                    //Stringに変換
                    return result.ToString();
                };

            //回す
            com.WaitSpecialFunction();

            //開放＆SocketClose
            com = null;
        }
    }

}
