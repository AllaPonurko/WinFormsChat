using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsChat;

namespace WinFormsServer
{
    public class Server
    {
        int port;
        public Server(int port)
        {
            this.port = port;
        }
        Task task;
        public void ServerStart()
        {
            if (task != null)
                MessageBox.Show("Сервер уже запущен!");
            task = new Task(Run);
            task.Start();
        }
        public void Run()//делегат для инициализации новой задачи по запуску сервера
        {
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Any, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(iPEnd);//соединение с локальной точкой
                socket.Listen(10);//прослушивание порта
                while(true)
                {
                    Socket incoming = socket.Accept();//входящее соединение
                    Client client = new Client(incoming);//инициализируем клиента входящим соединением
                    Task task = new Task(client.run);//создаём новую задачу по обработке клиента
                    task.Start();//запускаем задачу
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
    }
}
