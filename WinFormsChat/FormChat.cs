﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsChat
{
    public struct Mess
    {
        public string mess { get; set; }

    }
    public partial class FormChat : Form
    {
        const int port = 4000;
        const string host = "127.0.0.1";
        public FormChat()
        {
            InitializeComponent();
            ChangeMess += AddListBox;
            tcpClient = new TcpClient();
            IPAddress iP = IPAddress.Parse(host);
            tcpClient.Connect(iP, port);//
        }

        public static Mess MyMess = new Mess();
        public delegate void OnChangedMess(string msg);
        public static event OnChangedMess ChangeMess;
        StreamReader Reader = null;
        StreamWriter Writer = null;
        TcpClient tcpClient;
        string userName;
        public void AddListBox(string mess)
        {
            lstChat.Items.Add(mess);
        }
        private async void btnSend_Click(object sender, EventArgs e)
        {

            if (txtMessage.Text.Length == 0)
                return;
            else
            {
                lstChat.Items.Add(txtMessage.Text.ToString());
                lstTime.Items.Add(DateTime.Now.ToLongTimeString());
                MyMess.mess = DateTime.Now.ToLongTimeString() + " " +
                txtMessage.Text.ToString();
                txtMessage.Text = null;
                //Sending(MyMess.mess);
                //if (Writer is null ) return;
                await SendMessageAsync(MyMess.mess);
                
            }
        }



        private void FormChat_Load(object sender, EventArgs e)
        {
            FormChat.ActiveForm.Name = $"Welcome to the chat!";
        }


        //class State
        //{
        //    public Socket senderSocket;
        //    public int data;
        //    public static int BUFFER_SIZE = 256;
        //    public byte[] buffer = new byte[BUFFER_SIZE];
        //    public StringBuilder sb = new StringBuilder();
        //}

        //void DoReceive(IAsyncResult ar)//получить сообщение от сервера
        //{
        //    try
        //    {
        //        State state;
        //        if (ar.AsyncState is State)
        //            state = ar.AsyncState as State;
        //        else return;
        //        int read = state.senderSocket.EndReceive(ar);

        //        if (read > 0)
        //        {
        //            state.sb.Append(Encoding.Unicode.GetString(state.buffer, 0, read));
        //            state.senderSocket.BeginReceive(state.buffer, 0, State.BUFFER_SIZE, 0,
        //                                     new AsyncCallback(DoReceive), state);
        //        }
        //        else
        //        {
        //            if (state.sb.Length > 1)
        //            {
        //                string strContent;
        //                strContent = state.sb.ToString();
        //                MessageBox.Show(String.Format($"Read {0} byte from socket" +
        //                                 "data = {1} ", strContent.Length, strContent)) ;
        //                ChangeMess?.Invoke(strContent);
        //            }
        //            state.senderSocket.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //void AfterConnect(IAsyncResult ar)//что делать после соединения
        //{
        //    State state;
        //    if (ar.AsyncState is State)
        //        state = ar.AsyncState as State;
        //    else
        //    {
        //        state = new State();
        //        state.senderSocket = s;
        //    }
        //    state.senderSocket.BeginReceive(state.buffer, 0, State.BUFFER_SIZE, 0,
        //                          new AsyncCallback(DoReceive), state);

        //}


        //private static void DoSend(IAsyncResult ar)//
        //{
        //    State state;
        //    if (ar.AsyncState is State)
        //        state = ar.AsyncState as State;
        //    else
        //    {
        //        state = new State();
        //        state.senderSocket = s;
        //    }
        //    state.senderSocket.EndSend(ar);
        //}
        //private void Sending(string str)
        //{
        //    State state=new State();
        //    state.senderSocket = s;
        //    state.buffer = Encoding.Unicode.GetBytes(str);
        //    state.senderSocket.BeginSend(state.buffer, 0, state.buffer.Length, SocketFlags.None,
        //        new AsyncCallback(DoSend), state);
        //}
        //private void AsyncConnect()//асинхронное соединение
        //{
        //    IPEndPoint ipEndPoint = new IPEndPoint(
        //        IPAddress.Parse(txtIpAdress.Text),
        //        Convert.ToInt32(txtPort.Text));
        //    Socket senderSocket = new Socket(AddressFamily.InterNetwork,
        //        SocketType.Stream, ProtocolType.Tcp);
        //    //senderSocket.ReceiveTimeout = 6000;

        //    s = senderSocket; 

        //    try
        //    {
        //        State state = new State();
        //        state.senderSocket = senderSocket;
        //        state.data = 42;
        //        senderSocket.BeginConnect(  ipEndPoint, 
        //            new AsyncCallback(AfterConnect),state);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Writer?.Close();
            Reader?.Close();
            Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0 & txtPass.Text.Length == 0)
                MessageBox.Show("fields are not filled!");
            else
            {
                ConnectToChat();
                lstChat.Visible = true;
                lstTime.Visible = true;
                txtMessage.Visible = true;
                btnSend.Visible = true;
                btnDelete.Visible = true;
                userName = txtName.Text;
                lstChat.Items.Add($"Welcome, {userName}");
                lstTime.Items.Add(DateTime.Now.ToLongTimeString());
            }
        }
        private async void ConnectToChat()
        {
            
            try
            {
                while (true)
                {
                    if (Reader is null) return;
                    await Task.Run(() => ReceiveMessageAsync(Reader));//
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ReceiveMessageAsync(StreamReader reader)
        {
            Reader = new StreamReader(tcpClient.GetStream());
            while (true)
            {
                try
                {
                    // считываем ответ в виде строки
                    string? message = await reader.ReadLineAsync();
                    // если пустой ответ, ничего не выводим на консоль
                    if (string.IsNullOrEmpty(message)) continue;
                    reader.Dispose();
                    ChangeMess.Invoke(message);//вывод сообщения

                }
                catch
                {
                    break;
                }
            }

        }
        async Task SendMessageAsync(string message)
        {
            Writer = new StreamWriter(tcpClient.GetStream());
            await Writer.WriteLineAsync(userName);
            await Writer.FlushAsync();
            while (true)
            {
                await Writer.WriteLineAsync(message);
                await Writer.FlushAsync();

            }
        }

    }
}
