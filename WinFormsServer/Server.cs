using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormsServer
{
    public class Server
    {
        //    int port;
        //    public Server(int port)
        //    {
        //        this.port = port;
        //    }
        //    Task task;
        //    public void ServerStart()
        //    {
        //        if (task != null)
        //            MessageBox.Show("Сервер уже запущен!");
        //        task = new Task(Run);
        //        task.Start();
        //    }
        //    public void Run()//делегат для инициализации новой задачи по запуску сервера
        //    {
        //        IPEndPoint iPEnd = new IPEndPoint(/*IPAddress.Any*/IPAddress.Parse("127.0.0.1"), port);
        //        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        try
        //        {
        //            socket.Bind(iPEnd);//соединение с локальной точкой
        //            socket.Listen(10);//прослушивание порта
        //            while(true)
        //            {
        //                Socket incoming = socket.Accept();//входящее соединение
        //                Client client = new Client(incoming);//инициализируем клиента входящим соединением
        //                Task task = new Task(client.run_connect);//создаём новую задачу по обработке клиента
        //                task.Start();//запускаем задачу
        //            }
        //        }
        //        catch(Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }

        //    }
        static TcpListener tcpListener; // сервер для прослушивания
        List<Client> clients = new List<Client>(); // все подключения
        
        protected internal void AddConnection(Client clientObject)
        {
            clients.Add(clientObject);
        }
        protected internal void RemoveConnection(string id)
        {
            // получаем по id закрытое подключение
            Client client = clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
                clients.Remove(client);
        }
        
        protected internal void Listen()// прослушивание входящих подключений
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                MessageBox.Show("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    Client clientObject = new Client(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Disconnect();
            }
        }

        // трансляция сообщения подключенным клиентам
        protected internal void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id) // если id клиента не равно id отправляющего
                {
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных
                }
            }
        }
        // отключение всех клиентов
        protected internal void Disconnect()
        {
            tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }
    }
}
    

