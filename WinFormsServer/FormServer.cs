using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsServer.MyDbContext;

namespace FormsServer
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
            Start();
            //dbChat = new DbChat();
        }
        static Server server; // сервер
        static Task listenTask; // потока для прослушивания
        static void Start()
        {try
            {
                server = new Server();
                listenTask = new Task(server.Listen);
                listenTask.Start(); //старт потока
            }
            catch (Exception ex)
            {
                server.Disconnect();
                MessageBox.Show(ex.Message);
            }
        }
        public static DbChat dbChat;
    }
}
