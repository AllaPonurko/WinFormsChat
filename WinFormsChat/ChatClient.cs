using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsChat
{
    public class ChatClient
    {
        static string userName { get; set; }
        private const string host = "127.0.0.1";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;
        public ChatClient()
        {
            client = new TcpClient();
        }
        public void Connection(string name)//соединение и подключение клиента
        {
            userName = name;
            try
            {
                client.ConnectAsync(host, port); //подключение клиента
                stream = client.GetStream(); // получаем поток
                string message = userName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.WriteAsync(data, 0, data.Length);
                
                // запускаем новый поток для получения данных
                Task receiveTask = new Task(ReceiveMessage);
                receiveTask.Start(); //старт потока
                MessageBox.Show("Добро пожаловать, {0}", userName);
                //Thread.Sleep(1000);
                //запускаем новый поток для отправка данных
                Task sendTask = new Task(SendMessage);
                sendTask.Start();
                //Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                Disconnect();
            }
        }
        
       public static void SendMessage()// отправка сообщений
        {
            while (true)
            {
                string message = FormChat.MyMess.ToString();
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.WriteAsync(data, 0, data.Length);
            }
        }    
        static void ReceiveMessage()// получение сообщений
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    Mess.mess=message;
                    //вывод сообщения
                    
                }
                catch
                {
                    MessageBox.Show("Подключение прервано!"); //соединение было прервано
                    Disconnect();
                }
            }
        }

        static void Disconnect()
        {
            if (stream != null)
                stream.Close();//отключение потока
            if (client != null)
                client.Close();//отключение клиента
            //Environment.Exit(0); //завершение процесса
        }
    

    }
}
