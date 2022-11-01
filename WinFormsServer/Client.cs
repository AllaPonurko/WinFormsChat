using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinFormsServer.Entities;

namespace WinFormsChat
{
    public class Client
    {
        Socket socket;
        public Client(Socket incoming)
        {
            socket = incoming;
        }
        /// <summary>
        /// когда отправка завершена
        /// </summary>
        /// <param name="ar"></param>
        private void WhenSending(IAsyncResult ar)
        {
            socket.Shutdown(SocketShutdown.Both);//закрываем соединение с двух сторон
            socket.Close();//закрываем сокет
        }
        public void run()
        {
            while (true)
            {
                byte[] buffer = new byte[1024]; // буфер для получаемых данных

                do
                {
                    int bytes = socket.Receive(buffer);
                }
                while (socket.Available > 0);

                BinaryFormatter formatter = new BinaryFormatter();
                Lib.Request request;

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    try
                    {
                        request = (Lib.Request)formatter.Deserialize(ms);
                        switch (request.Command)
                        {
                            case Lib.Enum.RequestCommand.Auth:
                                Lib.Entities.Auth auth = (Lib.Entities.Auth)request.Body;
                                MessageBox.Show(auth.Email);
                                break;
                            case Lib.Enum.RequestCommand.Read:
                                List<MyMessage> myMessages = new List<MyMessage>();
                                myMessages = (List<MyMessage>)request.Body;
                                break;
                            case Lib.Enum.RequestCommand.Create:
                                MyMessage message = new MyMessage();
                                message = (MyMessage)request.Body;
                                break;
                            case Lib.Enum.RequestCommand.Update:

                                break;

                            default:
                                MessageBox.Show(" No Command ");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        }


        /// <summary>
        /// Процесс работы с клиентом
        /// </summary>
        public void run_connect()
        {
            Thread.Sleep(2000);
            string send = new DateTime().ToString();
            socket.BeginSend(
                Encoding.Unicode.GetBytes(send), // Что я отсылаю
                0,
                send.Length,
                0,
                new AsyncCallback(WhenSending),
                socket
                );
        }
    }
}
