﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsServer
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
            server.ServerStart();
        }
        Server server = new Server(40);
        
    }
}
