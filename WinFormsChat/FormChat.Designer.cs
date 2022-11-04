
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstChatIn = new System.Windows.Forms.ListBox();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnEditContact = new System.Windows.Forms.Button();
            this.btnOpenChat = new System.Windows.Forms.Button();
            this.btnDeleteContact = new System.Windows.Forms.Button();
            this.btnDeleteMessage = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstChatOut
            // 
            this.lstChatOut.FormattingEnabled = true;
            this.lstChatOut.ItemHeight = 15;
            this.lstChatOut.Location = new System.Drawing.Point(0, 3);
            this.lstChatOut.Name = "lstChatOut";
            this.lstChatOut.Size = new System.Drawing.Size(104, 199);
            this.lstChatOut.TabIndex = 0;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(0, 234);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(104, 23);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "Отправить";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(0, 205);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(200, 23);
            this.txtMessage.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeleteMessage);
            this.panel1.Controls.Add(this.lstChatIn);
            this.panel1.Controls.Add(this.lstChatOut);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Location = new System.Drawing.Point(273, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 268);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDeleteContact);
            this.panel2.Controls.Add(this.btnOpenChat);
            this.panel2.Controls.Add(this.btnEditContact);
            this.panel2.Controls.Add(this.btnAddContact);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Location = new System.Drawing.Point(23, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 267);
            this.panel2.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 199);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Список контактов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Окно сообщений";
            // 
            // lstChatIn
            // 
            this.lstChatIn.FormattingEnabled = true;
            this.lstChatIn.ItemHeight = 15;
            this.lstChatIn.Location = new System.Drawing.Point(101, 3);
            this.lstChatIn.Name = "lstChatIn";
            this.lstChatIn.Size = new System.Drawing.Size(99, 199);
            this.lstChatIn.TabIndex = 3;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(0, 204);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(88, 23);
            this.btnAddContact.TabIndex = 1;
            this.btnAddContact.Text = "Добавить";
            this.btnAddContact.UseVisualStyleBackColor = true;
            // 
            // btnEditContact
            // 
            this.btnEditContact.Location = new System.Drawing.Point(94, 204);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(105, 23);
            this.btnEditContact.TabIndex = 2;
            this.btnEditContact.Text = "Редактировать";
            this.btnEditContact.UseVisualStyleBackColor = true;
            // 
            // btnOpenChat
            // 
            this.btnOpenChat.Location = new System.Drawing.Point(0, 233);
            this.btnOpenChat.Name = "btnOpenChat";
            this.btnOpenChat.Size = new System.Drawing.Size(88, 23);
            this.btnOpenChat.TabIndex = 3;
            this.btnOpenChat.Text = "Открыть";
            this.btnOpenChat.UseVisualStyleBackColor = true;
            // 
            // btnDeleteContact
            // 
            this.btnDeleteContact.Location = new System.Drawing.Point(94, 233);
            this.btnDeleteContact.Name = "btnDeleteContact";
            this.btnDeleteContact.Size = new System.Drawing.Size(105, 23);
            this.btnDeleteContact.TabIndex = 4;
            this.btnDeleteContact.Text = "Удалить";
            this.btnDeleteContact.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMessage
            // 
            this.btnDeleteMessage.Location = new System.Drawing.Point(110, 235);
            this.btnDeleteMessage.Name = "btnDeleteMessage";
            this.btnDeleteMessage.Size = new System.Drawing.Size(90, 23);
            this.btnDeleteMessage.TabIndex = 4;
            this.btnDeleteMessage.Text = "Удалить";
            this.btnDeleteMessage.UseVisualStyleBackColor = true;
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormChat";
            this.Text = "FormChat";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
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
    }
}