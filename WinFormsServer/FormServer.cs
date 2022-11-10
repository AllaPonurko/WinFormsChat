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
            server.Start();
            //dbChat = new DbChat();
        }
         Server server=new Server(); // сервер
       
        public static DbChat dbChat;
    }
}
