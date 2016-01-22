using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MT4DLL
{
    /// <summary>
    /// MT4のDateTimeクラス。
    /// C#のDateTimeクラスを指定するとそのまま変換してくれる。
    /// </summary>
    public class MT4DateTime : Mt4Object
    {
        /// <summary>
        /// DateTime
        /// </summary>
        protected DateTime dateTime;

        /// <summary>
        /// C#のDateTimeクラスをセット
        /// </summary>
        /// <param name="dateTime">C# DateTime</param>
        /// <returns>Trueなら成功</returns>
        public bool SetDateTime(DateTime dateTime)
        {
            if (dateTime == null)
            {
                return false;
            }

            this.dateTime = dateTime;

            return true;
        }

        /// <summary>
        /// C#のDateTimeクラスを取得する
        /// </summary>
        /// <returns>C#のDateTime</returns>
        public DateTime GetDateTime()
        {
            return dateTime;
        }

        /// <summary>
        /// C# のDateTimeで初期化
        /// </summary>
        /// <param name="dateTime">C#のDateTime</param>
        public MT4DateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        /// <summary>
        /// MT4のDateTimeの文字列表現からMT4DateTime型を取得する
        /// </summary>
        /// <param name="mt4DateTimeStr">MT4のDateTimeの文字列表現</param>
        /// <returns>MT4DateTime型</returns>
        public static MT4DateTime Parse(string mt4DateTimeStr)
        {
            //mt4DateTimeStrがMT4のDateTimeに則っているか
            if (!System.Text.RegularExpressions.Regex.IsMatch(
    mt4DateTimeStr, @"^[1-2][0-9][0-9][0-9]\.[0-1][0-9]\.[0-3][0-9] [0-2][0-9]:[0-6][0-9]:[0-6][0-9]$"))
            {
                //則っていなかったら例外をスロー
                throw new FormatException("Mt4DateTime parse error:" + mt4DateTimeStr);
            }

            //ドットをスラッシュに変える
            string dateTimeStr = mt4DateTimeStr.Replace('.', '/');

            //そのままパース出来るはず
            DateTime dateTime = DateTime.Parse(dateTimeStr);

            //自分に入れて返す
            return new MT4DateTime(dateTime);
        }

        /// <summary>
        /// C#のDateTime型からMT4DateTime型を取得する
        /// </summary>
        /// <param name="dateTime">C#のDateTime</param>
        /// <returns>MT4DateTime型</returns>
        public static MT4DateTime Parse(DateTime dateTime)
        {
            //自分に入れて返す
            return new MT4DateTime(dateTime);
        }

        /// <summary>
        /// MT4の文字列表現に順守した文字列を返す
        /// </summary>
        /// <returns>MT4の文字列表現に順守した文字列</returns>
        public override string ToString()
        {
            //文字列取得
            string dateTimeStr = this.dateTime.ToString("yyyy.MM.dd HH:mm:ss");

            //返す
            return dateTimeStr;
        }
    }
}
