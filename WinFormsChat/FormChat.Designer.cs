
namespace WinFormsChat
{
    partial class FormChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstChatOut = new System.Windows.Forms.ListBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteMessage = new System.Windows.Forms.Button();
            this.lstChatIn = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteContact = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnOpenChat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnEditContact = new System.Windows.Forms.Button();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstChatOut
            // 
            this.lstChatOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstChatOut.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstChatOut.FormattingEnabled = true;
            this.lstChatOut.ItemHeight = 15;
            this.lstChatOut.Location = new System.Drawing.Point(0, 3);
            this.lstChatOut.Name = "lstChatOut";
            this.lstChatOut.Size = new System.Drawing.Size(333, 240);
            this.lstChatOut.TabIndex = 0;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(-1, 269);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(104, 23);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "Отправить";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Location = new System.Drawing.Point(0, 245);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(438, 28);
            this.txtMessage.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnDeleteMessage);
            this.panel1.Controls.Add(this.lstChatIn);
            this.panel1.Controls.Add(this.lstChatOut);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Location = new System.Drawing.Point(218, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 321);
            this.panel1.TabIndex = 3;
            // 
            // btnDeleteMessage
            // 
            this.btnDeleteMessage.Location = new System.Drawing.Point(-1, 298);
            this.btnDeleteMessage.Name = "btnDeleteMessage";
            this.btnDeleteMessage.Size = new System.Drawing.Size(104, 23);
            this.btnDeleteMessage.TabIndex = 4;
            this.btnDeleteMessage.Text = "Удалить";
            this.btnDeleteMessage.UseVisualStyleBackColor = true;
            // 
            // lstChatIn
            // 
            this.lstChatIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstChatIn.FormattingEnabled = true;
            this.lstChatIn.ItemHeight = 15;
            this.lstChatIn.Location = new System.Drawing.Point(339, 3);
            this.lstChatIn.Name = "lstChatIn";
            this.lstChatIn.Size = new System.Drawing.Size(99, 240);
            this.lstChatIn.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDeleteContact);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.btnOpenChat);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.btnEditContact);
            this.panel2.Controls.Add(this.btnAddContact);
            this.panel2.Location = new System.Drawing.Point(12, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 321);
            this.panel2.TabIndex = 4;
            // 
            // btnDeleteContact
            // 
            this.btnDeleteContact.Location = new System.Drawing.Point(94, 298);
            this.btnDeleteContact.Name = "btnDeleteContact";
            this.btnDeleteContact.Size = new System.Drawing.Size(105, 23);
            this.btnDeleteContact.TabIndex = 4;
            this.btnDeleteContact.Text = "Удалить";
            this.btnDeleteContact.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Location = new System.Drawing.Point(0, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 16);
            this.txtName.TabIndex = 8;
            // 
            // btnOpenChat
            // 
            this.btnOpenChat.Location = new System.Drawing.Point(0, 298);
            this.btnOpenChat.Name = "btnOpenChat";
            this.btnOpenChat.Size = new System.Drawing.Size(88, 23);
            this.btnOpenChat.TabIndex = 3;
            this.btnOpenChat.Text = "Открыть";
            this.btnOpenChat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Список контактов";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 225);
            this.listBox1.TabIndex = 0;
            // 
            // btnEditContact
            // 
            this.btnEditContact.Location = new System.Drawing.Point(95, 269);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(105, 23);
            this.btnEditContact.TabIndex = 2;
            this.btnEditContact.Text = "Редактировать";
            this.btnEditContact.UseVisualStyleBackColor = true;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(0, 269);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(88, 23);
            this.btnAddContact.TabIndex = 1;
            this.btnAddContact.Text = "Добавить";
            this.btnAddContact.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Окно сообщений";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Добро пожаловать в чат";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(348, 298);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(657, 349);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormChat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstChatOut;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteMessage;
        private System.Windows.Forms.ListBox lstChatIn;
        private System.Windows.Forms.Button btnDeleteContact;
        private System.Windows.Forms.Button btnOpenChat;
        private System.Windows.Forms.Button btnEditContact;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnExit;
    }
}