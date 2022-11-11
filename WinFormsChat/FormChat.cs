using Lib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            //ChangeMess += AddListBox;
        }
        public static Mess MyMess = new Mess();

        public delegate string OnChangedMess(string msg);
        public static event OnChangedMess ChangeMess;

        public void AddListBox(string mess)
        {
            lstChatOut.Items.Add(mess);
        }
        
        private void FormChat_Load(object sender, EventArgs e)
        {
            txtName.Text = TempUser.Name;
            txtName.Enabled = false;
            
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length == 0)
                return;
            else
            {
                ChatClient chatClient = new ChatClient();
                
                MyMess.mess = txtMessage.Text.ToString() + "\r\t\n " + DateTime.Now.ToShortTimeString();
                lstChatOut.Items.Add(MyMess.mess);
                chatClient.Connection(txtName.Text);
                //AddListBox(MyMess.mess);
                txtMessage.Text = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
