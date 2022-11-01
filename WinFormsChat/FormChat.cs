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
        User NewUser = new User(Form1.temp.Name,Form1.temp.Pass);
        private void FormChat_Load(object sender, EventArgs e)
        {

        }
    }
}
