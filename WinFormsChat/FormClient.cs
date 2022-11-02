using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsServer.MyDbContext;

namespace WinFormsChat
{
    public struct TempUser
    {
        public string Name;
        public string Pass;
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
       public static TempUser temp = new TempUser();
        private void btnEnter_Click(object sender, EventArgs e)
        {
            
            if(txtLogin.Text.Length==0)
            {
                MessageBox.Show("Не заполнен логин");
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Не заполен пароль");
            }
            if(txtLogin.Text.Length != 0 & txtPassword.Text.Length != 0)
            { 
                //if(dbChat.Users!=null)
                //{
                //    var log = (from users in dbChat.Users
                //               where users.Login == txtLogin.Text & users.Password== txtPassword.Text
                //               select users).First().ToString();
                //    var pass=(from users in dbChat.Users
                //              where users.Login == txtLogin.Text & users.Password == txtPassword.Text
                //              select users.Password).First().ToString();
                //    temp.Name = log;
                //    temp.Pass = pass;
                    FormChat chat = new FormChat();
                    chat.Show();   
                }
                
            }

        }
    }
}
