﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsServer.MyDbContext;


namespace FormsServer
{
        
    public class Temp
    {
        public string Name { get; set; }
        public bool flag;
        public Temp()
        {
            flag = false;
        }
    }
    
    public partial class FormServer : Form
    { 
        
        public FormServer()
        {
            InitializeComponent();   
            server = new Server(); // сервер
            server.ServerStart();
            ChangedConnect += AddListConnection;
            Controls.Add(new Button()
            {
                Name = "btnUpDate",
                Text = "Обновить",
                Left = 30, Top = 100,
                
            }
            );
            Controls.Add(new Button() {
                Name = "btnExit",
                Text = "Выйти",
                Left = 30,
                Top = 190,
            });
            txtAdress.Enabled = false;
            txtPort.Enabled = false;
            
            //dbChat = new DbChat();
        }
        internal delegate void  OnChangedConnect(string str);
        internal static event OnChangedConnect ChangedConnect;
        public static Temp temp = new Temp();
        Server server; // сервер
        public static DbChat dbChat;
        public void AddListConnection(string str)
        {
            lstConnection.Items.Add(DateTime.Now.ToShortTimeString()+" "+str + " is connected \n");
        }
        
        private void FormServer_Load(object sender, EventArgs e)
        {
            lstConnection.Items.Clear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {   if(temp.flag)             
            ChangedConnect?.Invoke(temp.Name+" is connected");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
