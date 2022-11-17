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
        Socket incomingClientSocket;

        /// <summary>
        /// Для работы с клиентом мне нужно знать его сокет
        /// </summary>
        /// <param name="incomingClientSocket">Входящий сокет клиента</param>
        public Client(Socket incomingClientSocket)
        {
            this.incomingClientSocket = incomingClientSocket;
        }

        /// <summary>
        /// Когда я закончил отсылку
        /// </summary>
        /// <param name="ar"></param>
        private void WhenSending(IAsyncResult ar)
        {
            incomingClientSocket.Shutdown(SocketShutdown.Both);
            incomingClientSocket.Close(); // По завершению работы - закрыть
        }

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
        public void run_connect()
        {
            Thread.Sleep(2000);
            while (true)
            {
                int bytes = 0; // количество полученных байтов
                byte[] data = new byte[1024]; // буфер для получаемых данных
                string send;
                do
                {
                    bytes = incomingClientSocket.Receive(data);
                    StringBuilder builder = new StringBuilder();
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    send = builder.ToString();
                }
                while (incomingClientSocket.Available > 0);
                FormServer.temp.Name = send;
                FormServer.temp.flag = true;
                incomingClientSocket.BeginSend(Encoding.Unicode.GetBytes(send), // Что я отсылаю
                0, send.Length, 0, new AsyncCallback(WhenSending),
                incomingClientSocket);
                // Закрытие соединения следует вызывать уже тогда, когда передеча произошла
                //incomingClientSocket.Shutdown(SocketShutdown.Both);
                //incomingClientSocket.Close(); // По завершению работы - закрыть
            }
        }
        //protected internal string Id { get; }= Guid.NewGuid().ToString();
        //protected internal StreamWriter Writer { get; }
        //protected internal StreamReader Reader { get; }
        //public Client(TcpClient client, Server serverObject)
        //{

        //    tcpClient = client;
        //    server = serverObject;
        //    var stream = client.GetStream();
        //    Reader = new StreamReader(stream);
        //    Writer = new StreamWriter(stream);
        //    NewUser = new User(); 
        //}
        //public User NewUser { get; set; }
        //public static TempMessage tempMessage = new TempMessage();
        //TcpClient tcpClient;
        //Server server;
        //protected internal NetworkStream Stream{ get; private set; }
        //public async Task ProcessAsync()
        //{
        //    while (true)
        //    { 
        //        try
        //        {
        //            //byte[] buffer = new byte[1024]; // буфер для получаемых данных

        //            //do
        //            //{
        //            //    int bytes = Stream.Read(buffer, 0, buffer.Length);
        //            //}
        //            //while (Stream.DataAvailable);


        //            //BinaryFormatter formatter = new BinaryFormatter();
        //            //Request request;

        //            //using (MemoryStream ms = new MemoryStream(buffer))
        //            //{
        //            //    try
        //            //    {
        //            //        request = (Request)formatter.Deserialize(ms);
        //            //        switch (request.Command)
        //            //        {
        //            //            case Lib.Enum.RequestCommand.Auth:
        //            //                Auth auth = (Auth)request.Body;
        //            //                MessageBox.Show(auth.Email);

        //            //                break;
        //            //            case Lib.Enum.RequestCommand.GET:
        //            //                List<string> myMessages = new List<string>();
        //            //                myMessages = (List<string>)request.Body;
        //            //                break;
        //            //            case Lib.Enum.RequestCommand.POST:


        //            //                break;
        //            //            case Lib.Enum.RequestCommand.PUT:

        //            //                break;
        //            //            case Lib.Enum.RequestCommand.DELETE:

        //            //                break;

        //            //            default:
        //            //                MessageBox.Show(" No Command ");
        //            //                break;
        //            //        }
        //            //    }
        //            //    catch (Exception ex)
        //            //    {
        //            //        MessageBox.Show(ex.Message);
        //            //    }

        //            //получаем имя пользователя
        //             NewUser.Login = await Reader.ReadLineAsync();

        //            TempMessage.TempMess = $"{NewUser.Login} вошел в чат";
        //            MessageBox.Show(TempMessage.TempMess);
        //            // посылаем сообщение о входе в чат всем подключенным пользователям
        //            await server.BroadcastMessageAsync(TempMessage.TempMess, Id);

        //                // в бесконечном цикле получаем сообщения от клиента
        //                while (true)
        //                {
        //                    try
        //                    {
        //                    TempMessage.TempMess = await Reader.ReadLineAsync();
        //                    if (TempMessage.TempMess == null) continue;
        //                    string SendMessage = $"{NewUser.Login}: {TempMessage.TempMess}";
        //                     await server.BroadcastMessageAsync(TempMessage.TempMess, Id);
        //                    }
        //                    catch
        //                    {
        //                    TempMessage.TempMess = $"{NewUser.Login} покинул чат";
        //                    await server.BroadcastMessageAsync(TempMessage.TempMess, Id);
        //                        break;
        //                    }
        //                }
        //        }
        //        //}

        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message);
        //        }
        //        finally
        //        {
        //            // в случае выхода из цикла закрываем ресурсы
        //            server.RemoveConnection(Id);
        //        }
        //    }
        //}
        //protected internal void Close()
        //{
        //    Writer.Close();
        //    Reader.Close();
        //    tcpClient.Close();
        //}
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
