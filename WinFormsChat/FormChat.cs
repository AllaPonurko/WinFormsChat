using Lib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsServer.Entities;

namespace WinFormsChat
{
    public partial class FormChat : Form
    {
        public FormChat()
        {
            InitializeComponent();
        }
        User NewUser = new User(Form1.temp.Name,Form1.temp.Pass);
        MyMessage NewMessage = new MyMessage();
        Chat NewChat = new Chat();
        private void FormChat_Load(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length == 0)
                return;
            else
            {
                lstChat.Items.Add(txtMessage.Text.ToString()+"\n"+DateTime.Now.ToShortTimeString());
                NewMessage.Msg = txtMessage.Text.ToString();
                NewUser.Messages.Add(NewMessage);
                NewChat.Companions.Add(NewUser);
                NewChat.Correspondence.Add(NewMessage);
            }
        }
    }
}
