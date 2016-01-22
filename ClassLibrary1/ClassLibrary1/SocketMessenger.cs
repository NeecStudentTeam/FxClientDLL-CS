using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT4DLL
{
    class SocketMessenger
    {
        Socketer socketer = null;

        protected SynchronizedCollection<string> messageQueue = new SynchronizedCollection<string>();

        public SocketMessenger()
        {
        }

        public int Connect(string server, int port)
        {
            if(socketer == null)
            {
                socketer = new Socketer();
                return socketer.ConnectSocket(server, port);
            }
            return 0;
        }

        public bool isConnected()
        {
            return socketer == null ? false : socketer.isConnected();
        }

        public int SendMessage(string msg)
        {
            return socketer.Send(msg);
        }

        public SynchronizedCollection<string> GetRecvMsgs()
        {
            ReceiveMessage();
            return messageQueue;
        }

        public int ReceiveMessage()
        {
            int count = 0;
            while (socketer.IsReceivable())
            {
                messageQueue.Add(socketer.Resv());
                count++;
            }

            return count;
        }

    }

}
