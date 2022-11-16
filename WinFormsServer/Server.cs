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
        List<Client> clients; // все подключения
        const int port = 4000;
        static TcpClient tcpClient;
        
        public Server()
        {
            
            tcpClient = new TcpClient();
            clients = new List<Client>();
        }
        protected internal void AddConnection(Client client)//добавление клиента
        {
            clients.Add(client);
            
        }
        protected internal void RemoveConnection(string id)//удаление клиента
        {
            // получаем по id закрытое подключение
            Client client = clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
                clients.Remove(client);
        }

        protected internal async Task ListenAsync()// прослушивание входящих подключений
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                tcpListener.Start();
                MessageBox.Show("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                   tcpClient =await tcpListener.AcceptTcpClientAsync();
                    Client client = new Client(tcpClient, this);
                    clients.Add(client);
                    FormServer.temp.Name = client.NewUser.Login;
                    MessageBox.Show("Подключен новый клиент "+ client.NewUser.Login); 
                    await Task.Run(client.ProcessAsync);                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Disconnect();
            }
        }

        // трансляция сообщения подключенным клиентам
        protected internal async Task BroadcastMessageAsync(string message, string id)
        {
            foreach (var client in clients)
            {
                if (client.Id != id) // если id клиента не равно id отправителя
                {
                    await client.Writer.WriteLineAsync(message); //передача данных
                    await client.Writer.FlushAsync();
                    MessageBox.Show("Сообщение передано");
                }
            }
        }

        protected internal void Disconnect()// отключение всех клиентов
        {
            foreach (var client in clients)
            {
                client.Close(); //отключение клиента
            }
            tcpListener.Stop(); //остановка сервера
        }
        async public void StartServer()
        {
            await ListenAsync(); // запускаем сервер
        }
    }
}
    

