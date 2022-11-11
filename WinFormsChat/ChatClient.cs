using System;
using System.Collections.Generic;
using System.IO;
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
        static TcpClient client=null;
        StreamReader? Reader = null;
        StreamWriter? Writer = null;
        string greetings = $"Приветствую, {userName} ";
        public ChatClient()
        {
            client = new TcpClient();
        }
        
        public async void Connection(string name)//соединение и подключение клиента
        {
            userName = name;
            try
            {
                client.Connect(host, port); //подключение клиента
                Reader = new StreamReader(client.GetStream());
                Writer = new StreamWriter(client.GetStream());
                if (Writer is null || Reader is null) return;
                MessageBox.Show(greetings);
                // запускаем новый поток для получения данных
                await Task.Run(() => ReceiveMessageAsync(Reader));
                // запускаем ввод сообщений
                await SendMessageAsync(Writer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Writer?.Close();
                Reader?.Close();
            }
        }

        async Task SendMessageAsync(StreamWriter writer)
        {
            // сначала отправляем имя
            await writer.WriteLineAsync(userName);
            await writer.FlushAsync();
            

            while (true)
            {
                string? message = Console.ReadLine();
                await writer.WriteLineAsync(message);
                await writer.FlushAsync();
            }
        }
        // получение сообщений
        async Task ReceiveMessageAsync(StreamReader reader)
        {
            while (true)
            {
                try
                {
                    // считываем ответ в виде строки
                    string? message = await reader.ReadLineAsync();
                    // если пустой ответ, ничего не выводим 
                    if (string.IsNullOrEmpty(message)) continue;
                    FormChat.MyMess.mess =Print(message);//вывод сообщения
                    //FormChat.ChangeMess+= Print(message);
                }
                catch
                {
                    break;
                }
            }
        }

        public string Print(string message)
        {
          return  message;
        }



    }
}
