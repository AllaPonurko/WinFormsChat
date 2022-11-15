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
            chatClient.userName = TempUser.Name;
            MessageBox.Show($"Приветствую, {TempUser.Name} ");
          
        }
        
        private async void btnEnter_Click(object sender, EventArgs e)
        { 
            
            if (txtMessage.Text.Length == 0)
                return;
            else
            {
                lstChatOut.Items.Add(txtMessage.Text.ToString());
                lstChatIn.Items.Add( DateTime.Now.ToLongTimeString());
                MyMess.mess = DateTime.Now.ToLongTimeString()+" "+
                    txtMessage.Text.ToString() + "\r\t\n ";
                txtMessage.Text = null;
                await chatClient.Connection(MyMess.mess);
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            FormClient.ActiveForm.Close();

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
                client.ConnectAsync(host, port);
            }

            public async Task Connection(string msg)//соединение и подключение клиента
            {
                try
                {
                   //await client.ConnectAsync(host, port); //подключение клиента
                    Reader = new StreamReader(client.GetStream());
                    Writer = new StreamWriter(client.GetStream());
                    if (Writer is null || Reader is null) return;
                    // запускаем новый поток для получения данных
                    await Task.Run(() => ReceiveMessageAsync());
                    ChangeMess?.Invoke(msg);
                    // запускаем ввод сообщений
                    if (msg == null) return;
                    await SendMessageAsync(Writer, msg);
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

           public async Task SendMessageAsync(StreamWriter writer,string msg)
            {
                try
                {  
                    // сначала отправляем имя
                    await Writer.WriteLineAsync(userName);
                    await Writer.FlushAsync();
                    while (true)
                    {
                        await Writer.WriteLineAsync(msg);
                        await Writer.FlushAsync();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Writer?.Close();
                    //Reader?.Close();
                }
            }
            // получение сообщений
            async Task ReceiveMessageAsync(/*StreamReader reader*/)
            {
                Reader = new StreamReader(client.GetStream());
                if (Reader is null) return;
                //Writer = new StreamWriter(client.GetStream());
                while (true)
                {
                    try
                    {
                        // считываем ответ в виде строки
                        string? message = await Reader.ReadLineAsync();
                        ChangeMess?.Invoke(message);
                        // если пустой ответ, ничего не выводим 
                        if (string.IsNullOrEmpty(message)) continue;
                        /*MyMess.mess = message;*///вывод сообщения
                       
                    }
                    catch
                    {

                        break;
                    }
                    finally
                    {
                        //Writer?.Close();
                        Reader?.Close();
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
