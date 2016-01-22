using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MT4DLL
{
    class Socketer
    {
        TcpClient client = null;

        public Socketer()
        {
        }

        ~Socketer()
        {
            if (isConnected())
            {
                CloseSocket();
            }
        }

        public bool isConnected()
        {
            if (client == null)
                return false;
            else
                return true;
        }


        //参考URL
        //http://www.macs123.dtdns.net/algo/cs/cs009.html
        //TcpClient 取得
        public int ConnectSocket(string server, int port)
        {
            Log.Write("サーバーに接続します。");

            if (client != null)
            {
                Log.Write("既に接続されています。");
                return 1;
            }

            try
            {
                //サーバーに接続 

                client = new TcpClient(server, port);


                Log.Write("接続");
            }
            catch (Exception e)
            {
                Log.Write(e.Message);
                return 1;
            }
            return 0;
        }

        //Close
        public bool CloseSocket()
        {
            if (isConnected())
            {
                client.Close();
                client = null;
                return true;
            }
            Log.Write("既にCloseされています。");
            return false;
        }

        //msgを送る
        //送ったら、サーバーからの応答を待つ
        //応答を戻り値に入れる
        public int Send(string msg)
        {

            //サーバーにメッセージを送信 
            // msgは，Unicodeなので，SJISに変換して送信
            Byte[] data = System.Text.Encoding.GetEncoding(932).GetBytes(msg);  //SJIS
            //ストリーム取得
            NetworkStream stream = client.GetStream();

            //送信
            stream.Write(data, 0, data.Length);

            return 0;
        }

        //
        //受信するデータがあったらTrue
        //
        public bool IsReceivable()
        {
            if (this.client.Available > 0)
            {
                return true;
            }

            return false;
        }

        //
        //Reserve
        //
        public string Resv()
        {

            //ストリーム取得
            NetworkStream stream = client.GetStream();

            //Serverからの応答データ受信
            String responseData = String.Empty;
            Byte[] rdata = new Byte[1024];

            // サーバからの応答データを受信
            Int32 bytes = stream.Read(rdata, 0, rdata.Length);
            // サーバからは，UTF8で返してくるので，Unicodeにもどす．
            responseData = System.Text.Encoding.UTF8.GetString(rdata, 0, bytes).TrimEnd('\0');

            return responseData;
        }
    }
}
