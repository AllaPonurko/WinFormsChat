
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
            this.lstChat = new System.Windows.Forms.ListBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstChat
            // 
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ItemHeight = 15;
            this.lstChat.Location = new System.Drawing.Point(0, 0);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(120, 199);
            this.lstChat.TabIndex = 0;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(0, 234);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(120, 23);
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
            this.txtMessage.Size = new System.Drawing.Size(120, 23);
            this.txtMessage.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstChat);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Location = new System.Drawing.Point(12, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 278);
            this.panel1.TabIndex = 3;
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormChat";
            this.Text = "FormChat";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel panel1;
    }
}