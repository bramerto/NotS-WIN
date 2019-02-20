namespace MultiChat
{
    partial class MultiChat
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
            this.btnListen = new System.Windows.Forms.Button();
            this.listChats = new System.Windows.Forms.ListBox();
            this.txtMessageToBeSend = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtChatServerIP = new System.Windows.Forms.TextBox();
            this.btnConnectWithServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListen.Location = new System.Drawing.Point(872, 38);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(276, 44);
            this.btnListen.TabIndex = 0;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // listChats
            // 
            this.listChats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listChats.FormattingEnabled = true;
            this.listChats.ItemHeight = 25;
            this.listChats.Location = new System.Drawing.Point(53, 38);
            this.listChats.Name = "listChats";
            this.listChats.Size = new System.Drawing.Size(777, 604);
            this.listChats.TabIndex = 1;
            // 
            // txtMessageToBeSend
            // 
            this.txtMessageToBeSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageToBeSend.Location = new System.Drawing.Point(53, 715);
            this.txtMessageToBeSend.Name = "txtMessageToBeSend";
            this.txtMessageToBeSend.Size = new System.Drawing.Size(666, 30);
            this.txtMessageToBeSend.TabIndex = 2;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.Location = new System.Drawing.Point(738, 709);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(92, 42);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtChatServerIP);
            this.groupBox1.Controls.Add(this.btnConnectWithServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(872, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 250);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect to Server";
            // 
            // txtChatServerIP
            // 
            this.txtChatServerIP.Location = new System.Drawing.Point(43, 101);
            this.txtChatServerIP.Name = "txtChatServerIP";
            this.txtChatServerIP.Size = new System.Drawing.Size(209, 30);
            this.txtChatServerIP.TabIndex = 2;
            this.txtChatServerIP.Text = "127.0.0.1";
            // 
            // btnConnectWithServer
            // 
            this.btnConnectWithServer.Location = new System.Drawing.Point(44, 178);
            this.btnConnectWithServer.Name = "btnConnectWithServer";
            this.btnConnectWithServer.Size = new System.Drawing.Size(208, 41);
            this.btnConnectWithServer.TabIndex = 1;
            this.btnConnectWithServer.Text = "Connect";
            this.btnConnectWithServer.UseVisualStyleBackColor = true;
            this.btnConnectWithServer.Click += new System.EventHandler(this.btnConnectWithServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chat Server IP";
            // 
            // MultiChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 793);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessageToBeSend);
            this.Controls.Add(this.listChats);
            this.Controls.Add(this.btnListen);
            this.Name = "MultiChat";
            this.Text = "MultiChat";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ListBox listChats;
        private System.Windows.Forms.TextBox txtMessageToBeSend;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtChatServerIP;
        private System.Windows.Forms.Button btnConnectWithServer;
        private System.Windows.Forms.Label label1;
    }
}

