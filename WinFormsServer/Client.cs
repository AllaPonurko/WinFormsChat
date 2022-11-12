using Lib.Entities;
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
using System.Threading.Tasks;

namespace FormsServer
{public struct NewMess
    {
        public string mess { get; set; }
    }
    public class Client
    {
        public static NewMess newMess;
        protected internal string Id { get; }= Guid.NewGuid().ToString();
        protected internal StreamWriter Writer { get; }
        protected internal StreamReader Reader { get; }
        public Client(TcpClient client, Server serverObject)
        {
            
            tcpClient = client;
            server = serverObject;
            var stream = client.GetStream();
            Reader = new StreamReader(stream);
            Writer = new StreamWriter(stream);
            NewUser = new User(); 
        }
        public User NewUser { get; set; }
        
        TcpClient tcpClient;
        Server server;
        protected internal NetworkStream Stream{ get; private set; }
        public async Task ProcessAsync()
        {
            try
            {
                // получаем имя пользователя
                string? userName = await Reader.ReadLineAsync();
                
                string? message = $"{userName} вошел в чат";
                // посылаем сообщение о входе в чат всем подключенным пользователям
                await server.BroadcastMessageAsync(message, Id);
                MessageBox.Show(message);
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        message = await Reader.ReadLineAsync();
                        if (message == null) continue;
                        message = $"{userName}: {message}";
                        await server.BroadcastMessageAsync(message, Id);
                    }
                    catch
                    {
                        message = $"{userName} покинул чат";
                        await server.BroadcastMessageAsync(message, Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(Id);
            }
        }
        protected internal void Close()
        {
            Writer.Close();
            Reader.Close();
            tcpClient.Close();
        }
        //private string GetMessage()
        //{
        //    byte[] data = new byte[64]; // буфер для получаемых данных
        //    StringBuilder builder = new StringBuilder();
        //    int bytes = 0;
        //    do
        //    {
        //        bytes = Stream.Read(data, 0, data.Length);
        //        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //    }
        //    while (Stream.DataAvailable);

        //    return builder.ToString();
        //}
        
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
        //public List<string> GetMessages(User CurrentUser)
        //{
        //    //List<string> messages = new List<string>();
        //    //var m = (from msg in FormsServer.FormServer.dbChat.Messages where
        //    //         CurrentUser.Id == msg.UserId select msg).ToList();
        //    //return messages;
        //}

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
