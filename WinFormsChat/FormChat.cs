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
    public partial class FormChat : Form
    {
        public FormChat()
        {
            InitializeComponent();
        }
        
        private void FormChat_Load(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length == 0)
                return;
            else
            {
                lstChatOut.Items.Add(txtMessage.Text.ToString()+"\n"+DateTime.Now.ToShortTimeString());
               
            }
        }
    }
}
