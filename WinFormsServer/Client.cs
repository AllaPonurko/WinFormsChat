﻿using Lib.Entities;
using Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FormsServer.Entities;
using System.Linq;

namespace FormsServer
{public struct NewMess
    {
        public string mess { get; set; }
    }
    public class Client
    {
        public static NewMess newMess;
        //Socket socket;
        protected internal string Id { get; private set; }
        public Client(TcpClient client, Server serverObject)
        {
            Id = Guid.NewGuid().ToString();
            tcpClient = client;
            server = serverObject;
            serverObject.AddConnection(this);
        }
        public User NewUser { get; set; }
        TcpClient tcpClient;
        Server server;
        public void Process()
        {
            try
            {
                Stream = tcpClient.GetStream();
                // получаем имя пользователя
                string message = GetMessage();
                NewUser.Login = message;

                message = NewUser.Login + " вошел в чат";
                // посылаем сообщение о входе в чат всем подключенным пользователям
                server.BroadcastMessage(message, this.Id);
                Console.WriteLine(message);
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = String.Format("{0}: {1}", NewUser.Login, message);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
                    }
                    catch
                    {
                        message = String.Format("{0}: покинул чат", NewUser.Login);
                        newMess.mess= message;
                        server.BroadcastMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.Id);
                Close();
            }
        }
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (tcpClient != null)
                tcpClient.Close();
        }
        private string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }
        protected internal NetworkStream Stream { get; private set; }
        ///// <summary>
        ///// когда отправка завершена
        ///// </summary>
        ///// <param name="ar"></param>
        //private void WhenSending(IAsyncResult ar)
        //{
        //    socket.Shutdown(SocketShutdown.Both);//закрываем соединение с двух сторон
        //    socket.Close();//закрываем сокет
        //}
        //public void run()
        //{
        //    while (true)
        //    {
        //        byte[] buffer = new byte[1024]; // буфер для получаемых данных

        //        do
        //        {
        //            int bytes = socket.Receive(buffer);
        //        }
        //        while (socket.Available > 0);

        //        BinaryFormatter formatter = new BinaryFormatter();
        //        Request request;

        //        using (MemoryStream ms = new MemoryStream(buffer))
        //        {
        //            try
        //            {
        //                request = (Request)formatter.Deserialize(ms);
        //                switch (request.Command)
        //                {
        //                    case Lib.Enum.RequestCommand.Auth:
        //                        Auth auth = (Auth)request.Body;
        //                        MessageBox.Show(auth.Email);
        //                        break;
        //                    case Lib.Enum.RequestCommand.Read:
        //                        List<MyMessage> myMessages = new List<MyMessage>();
        //                        myMessages = (List<MyMessage>)request.Body;
        //                        break;
        //                    case Lib.Enum.RequestCommand.Create:
        //                        Auth auth1 = new Auth();
        //                        User newUser = new User(auth1.Email,auth1.Pass);
                                
        //                        break;
        //                    case Lib.Enum.RequestCommand.Update:

        //                        break;

        //                    default:
        //                        MessageBox.Show(" No Command ");
        //                        break;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }

        //        }
        //    }

        //}
        public List<MyMessage> GetMessages(User CurrentUser)
        {
            List<MyMessage> messages = new List<MyMessage>();
            var m = (from msg in FormsServer.FormServer.dbChat.Messages where
                     CurrentUser.Id == msg.UserId select msg).ToList();
            return messages;
        }

        ///// <summary>
        ///// Процесс работы с клиентом
        ///// </summary>
        //public void run_connect()
        //{
        //    Thread.Sleep(2000);
        //    string send = new DateTime().ToString();
        //    socket.BeginSend(
        //        Encoding.Unicode.GetBytes(send), // Что я отсылаю
        //        0,
        //        send.Length,
        //        0,
        //        new AsyncCallback(WhenSending),
        //        socket
        //        );
        //}
    }
}
