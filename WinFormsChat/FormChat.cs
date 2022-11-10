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
        public static string mess { get; set; }
        public override string ToString()
        {
            return mess;
        }

    }
    public partial class FormChat : Form
    {
        public FormChat()
        {
            InitializeComponent();
        }
        public static Mess MyMess=new Mess();
        delegate Mess OutMess() ;
        public static Mess OnChangedMess()
        {
            return MyMess;
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
                lstChatOut.Items.Add(txtMessage.Text.ToString()+"\t\n "+DateTime.Now.ToShortTimeString());
                Mess.mess = txtMessage.Text.ToString() + "\t\n " + DateTime.Now.ToShortTimeString();
                ChatClient chatClient = new ChatClient();
                chatClient.Connection(txtName.Text);
                
            }
        }
    }
}
