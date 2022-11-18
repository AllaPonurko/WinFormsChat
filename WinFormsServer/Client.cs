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
using System.Net;

namespace FormsServer
{
    public class Client
    {
       
        protected internal string Id { get; } = Guid.NewGuid().ToString();
        protected internal StreamWriter Writer { get; }
        protected internal StreamReader Reader { get; }
        TcpClient client;
        Server server;
        //Socket incomingClientSocket;

        ///// <summary>
        ///// Для работы с клиентом мне нужно знать его сокет
        ///// </summary>
        ///// <param name="incomingClientSocket">Входящий сокет клиента</param>
        public Client(TcpClient _client, Server _server)
        {
            client = _client;
            server = _server;
            Stream stream = client.GetStream();
            Writer = new StreamWriter(stream);
            Reader = new StreamReader(stream);
            NewUser = new User();
        }

        ///// <summary>
        ///// Когда я закончил отсылку
        ///// </summary>
        ///// <param name="ar"></param>
        //private void WhenSending(IAsyncResult ar)
        //{
        //    incomingClientSocket.Shutdown(SocketShutdown.Both);
        //    incomingClientSocket.Close(); // По завершению работы - закрыть
        //}

        //public void run()
        //{
        //    while (true)
        //    {
        //        int bytes = 0; // количество полученных байтов
        //        byte[] data = new byte[1024]; // буфер для получаемых данных

        //        do
        //        {
        //            bytes = incomingClientSocket.Receive(data);

        //            // builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //        }
        //        while (incomingClientSocket.Available > 0);

        //        BinaryFormatter formatter = new BinaryFormatter();
        //        Lib.Request request;

        //        using (MemoryStream ms = new MemoryStream(data))
        //        {
        //            try
        //            {
        //                request = (Lib.Request)formatter.Deserialize(ms);
        //                switch (request.Command)
        //                {
        //                    case Lib.Enum.RequestCommand.Auth:
        //                        Lib.Entities.Auth auth = (Lib.Entities.Auth)request.Body;
        //                        MessageBox.Show(auth.Email);
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
        /// <summary>
        /// Процесс работы с клиентом
        /// </summary>
        //public void run_connect()
        //{
        //    Thread.Sleep(2000);
        //    while (true)
        //    {
        //        int bytes; // количество полученных байтов
        //        byte[] data = new byte[1024]; // буфер для получаемых данных
        //        string send;
        //        do
        //        {
        //            bytes = incomingClientSocket.Receive(data);
        //            StringBuilder builder = new StringBuilder();
        //            builder.Append(Encoding.Unicode.GetString(data));
        //            send = builder.ToString();
        //            FormServer.temp.Name = send;
        //            FormServer.temp.flag = true;
        //        incomingClientSocket.BeginSend(Encoding.Unicode.GetBytes(send), // Что я отсылаю
        //        0, send.Length, 0, new AsyncCallback(WhenSending),
        //        incomingClientSocket);
        //        }
        //        while (incomingClientSocket.Available > 0);


        //        // Закрытие соединения следует вызывать уже тогда, когда передеча произошла
        //        //incomingClientSocket.Shutdown(SocketShutdown.Both);
        //        //incomingClientSocket.Close(); // По завершению работы - закрыть
        //    }
        //}
       public class NewMess
    {
        public string mess { get; set; }
        public bool flag;
       public NewMess()
        {
            flag = false;
        }
    }
        
        public User NewUser { get; set; }
        public static NewMess tempMessage = new NewMess();   
        public async Task ProcessAsync()
        {
            try
                {

                //Request request;
                //Response response;
                //request= (Request)Reader.ReadLineAsync();
                //response = (Response)Writer.WriteLineAsync();
                //while(true)
                //{
                //    switch (request.Command)
                //{
                //    case Lib.Enum.RequestCommand.Auth:
                //        
                //        NewUser.Login = await Reader.ReadLineAsync();
                //        tempMessage.mess = $"{NewUser.Login} вошел в чат";
                //        tempMessage.flag = true;
                //            //response.StatusText = "Success";
                //            MessageBox.Show(tempMessage.mess);
                //        //tempMessage.mess = (string)response.Body;
                //        await server.BroadcastMessageAsync(tempMessage.mess, Id);

                //        Reader.Dispose();
                //        break;
                //    case Lib.Enum.RequestCommand.GET:
                //        List<string> myMessages = new List<string>();
                //        myMessages = (List<string>)request.Body;
                //        break;
                //    case Lib.Enum.RequestCommand.POST:


                //        break;
                //    case Lib.Enum.RequestCommand.PUT:

                //        break;
                //    case Lib.Enum.RequestCommand.DELETE:

                //        break;
                //    case Lib.Enum.RequestCommand.READ:
                //            tempMessage.mess = await Reader.ReadLineAsync();
                //            tempMessage.flag = true;
                //            await server.BroadcastMessageAsync(tempMessage.mess, Id);
                //            break;
                //    case Lib.Enum.RequestCommand.END:
                //            tempMessage.mess = $"{NewUser.Login} покинул чат";
                //            //tempMessage.mess = (string)request.Body;
                //            //response.StatusText = "Exit";
                //            await server.BroadcastMessageAsync(tempMessage.mess, Id);
                //            break;

                //    default:
                //        MessageBox.Show(" No Command ");
                //        break;
                //}

                //}

                //получаем имя пользователя
                NewUser.Login = await Reader.ReadLineAsync();
                tempMessage.mess = $"{NewUser.Login} вошел в чат";
                tempMessage.flag = true;
                MessageBox.Show(tempMessage.mess);
                
                // посылаем сообщение о входе в чат всем подключенным пользователям
                await server.BroadcastMessageAsync(tempMessage.mess, Id);

                //в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        tempMessage.mess = await Reader.ReadLineAsync();
                        if (tempMessage.mess == null) continue;
                        string SendMessage = $"{NewUser.Login}: {tempMessage.mess}";
                        await server.BroadcastMessageAsync(SendMessage, Id);
                    
                    }
                    catch 
                    {
                        tempMessage.mess = $"{NewUser.Login} покинул чат";
                        await server.BroadcastMessageAsync(tempMessage.mess, Id);
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
                    server.RemoveConnection(Id);
                }
           
        }
        protected internal void _Close()
        {
            Writer.Close();
            Reader.Close();
            client.Close();
        }
        //    private void GetMessage(string str)
        //    {
        //    List<string> vs = new List<string>();
        //    vs.Add(str);
        //byte[] data = new byte[64]; // буфер для получаемых данных
        //StringBuilder builder = new StringBuilder();
        //int bytes = 0;
        //do
        //{
        //    bytes = Stream.Read(data, 0, data.Length);
        //    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //}
        //while (Stream.DataAvailable);

        //return builder.ToString();
        //}
        //        public List<string> GetMessages(User CurrentUser)
        //        {
        //            List<string> messages = new List<string>();
        //            var m = (from msg in FormsServer.FormServer.dbChat.Messages
        //                     where
        //CurrentUser.Id == msg.UserId
        //                     select msg).ToList();
        //            return messages;
        //        }

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
