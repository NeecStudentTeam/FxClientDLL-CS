using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MT4DLL
{
    /// <summary>
    /// MT4のColorクラス。
    /// r,g,bを指定出来る。
    /// </summary>
    public class MT4Color : Mt4Object
    {
        /// <summary>
        /// Red 0~255
        /// </summary>
        public int r;
        /// <summary>
        /// Green 0~255
        /// </summary>
        public int g;
        /// <summary>
        /// Blue 0~255
        /// </summary>
        public int b;

        /// <summary>
        /// カラーを指定
        /// </summary>
        /// <param name="red">0~255</param>
        /// <param name="green">0~255</param>
        /// <param name="blue">0~255</param>
        public MT4Color(int red, int green, int blue)
        {
            this.r = red;
            this.g = green;
            this.b = blue;
        }

        /// <summary>
        /// デフォルトではr,g,bには0が入る
        /// </summary>
        public MT4Color()
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;
        }

        /// <summary>
        /// MT4のカラーを表現する文字列をMT4Colorに変換
        /// </summary>
        /// <param name="mt4ColorStr">MT4でColorToStringをした時の文字列</param>
        /// <returns>MT4Color</returns>
        public static MT4Color Parse(string mt4ColorStr)
        {
            //mt4ColorStrがMT4のColorに則っているか
            if (!System.Text.RegularExpressions.Regex.IsMatch(
    mt4ColorStr, @"^[0-9]{1,3},[0-9]{1,3},[0-9]{1,3}$"))
            {
                //則っていなかったら例外をスロー
                throw new FormatException("MT4Color parse error:" + mt4ColorStr);
            }

            //正規表現のインスタンスを作成
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^([0-9]{1,3}),([0-9]{1,3}),([0-9]{1,3})$");

            //正規表現を実行
            var match = reg.Match(mt4ColorStr);

            //赤をパース
            int red = int.Parse(match.Groups[1].Value);
            //緑をパース
            int green = int.Parse(match.Groups[2].Value);
            //青をパース
            int blue = int.Parse(match.Groups[3].Value);

            //返す
            return new MT4Color(red, green, blue);
        }

        /// <summary>
        /// MT4の文字列表現に順守した文字列を返す
        /// </summary>
        /// <returns>MT4の文字列表現に順守した文字列</returns>
        public override string ToString()
        {
            //"R,G,B"
            return r.ToString() + "," + g.ToString() + "," + b.ToString();
        }
    }
}
