using Lib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsChat
{
    public struct Mess
    {
        public  string mess { get; set; }
  
    }
    public partial class FormChat : Form
    {
        public FormChat()
        {
            InitializeComponent();      
            ChangeMess += AddListBox;
            chatClient = new ChatClient();
            chatClient.Connection(MyMess.mess);

        }
        public static Mess MyMess = new Mess();
        ChatClient chatClient;
        public delegate void OnChangedMess(string msg);
        public static event OnChangedMess ChangeMess;
        
        //chatClient.userName = TempUser.Name;
        public void AddListBox(string mess)
        {
            lstChatOut.Items.Add(mess);
        }
        
        private void FormChat_Load(object sender, EventArgs e)
        {
            txtName.Text = TempUser.Name;
            txtName.Enabled = false;

            MessageBox.Show($"Приветствую, {txtName.Text} ");

        }
        
        private void btnEnter_Click(object sender, EventArgs e)
        { 
            
            if (txtMessage.Text.Length == 0)
                return;
            else
            {          
                lstChatOut.Items.Add(txtMessage.Text.ToString() + "\r\t\n " + 
                    DateTime.Now.ToShortTimeString());
                MyMess.mess = txtMessage.Text.ToString() + "\r\t\n " +
                    DateTime.Now.ToShortTimeString();
                txtMessage.Text = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();

        }
        public class ChatClient
        {
            public string userName { get; set; }
            private const string host = "127.0.0.1";
            private const int port = 4000;
            static TcpClient client = null;
            StreamReader? Reader = null;
            StreamWriter? Writer = null;
            
            public ChatClient()
            {
                client = new TcpClient();
               
            }

            public async void Connection(string mess)//соединение и подключение клиента
            {
                try
                {
                    client.Connect(host, port); //подключение клиента
                    Reader = new StreamReader(client.GetStream());
                    Writer = new StreamWriter(client.GetStream());
                    if (Writer is null || Reader is null) return;
                    // запускаем новый поток для получения данных
                    await Task.Run(() => ReceiveMessageAsync(Reader));
                    // запускаем ввод сообщений
                    await SendMessageAsync(Writer,mess);
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

            async Task SendMessageAsync(StreamWriter writer,string msg)
            {
                // сначала отправляем имя
                await writer.WriteLineAsync(userName);
                await writer.FlushAsync();
                while (true)
                {
                    await writer.WriteLineAsync(msg);
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
                        ChangeMess?.Invoke(message);
                        // если пустой ответ, ничего не выводим 
                        if (string.IsNullOrEmpty(message)) continue;
                        /*MyMess.mess = message;*///вывод сообщения
                       
                    }
                    catch
                    {

                        break;
                    }
                }
            }

            public string Print(string message)
            {
                return message;
            }
     }
    }
}
