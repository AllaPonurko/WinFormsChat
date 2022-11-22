using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WinFormsChat
{
    public partial class Form_Chat : Form
    {
        const int port = 4000;
        const string host = "127.0.0.1";
        public static Mess MyMess = new Mess();
        public delegate void OnChangedMess(string msg);
        public static event OnChangedMess ChangeMess;
        StreamReader Reader = null;
        StreamWriter Writer = null;
        TcpClient tcpClient;
        string userName;
        public Form_Chat()
        {
            InitializeComponent();
        }
    }
}
