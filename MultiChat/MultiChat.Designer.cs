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
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.MessageTxtBox = new System.Windows.Forms.TextBox();
            this.SendMessageBtn = new System.Windows.Forms.Button();
            this.ListenBtn = new System.Windows.Forms.Button();
            this.IpTxtBox = new System.Windows.Forms.TextBox();
            this.IpLbl = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(12, 12);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(523, 390);
            this.ChatBox.TabIndex = 0;
            this.ChatBox.Text = "";
            // 
            // MessageTxtBox
            // 
            this.MessageTxtBox.Location = new System.Drawing.Point(12, 419);
            this.MessageTxtBox.Name = "MessageTxtBox";
            this.MessageTxtBox.Size = new System.Drawing.Size(410, 20);
            this.MessageTxtBox.TabIndex = 1;
            // 
            // SendMessageBtn
            // 
            this.SendMessageBtn.Location = new System.Drawing.Point(428, 418);
            this.SendMessageBtn.Name = "SendMessageBtn";
            this.SendMessageBtn.Size = new System.Drawing.Size(107, 23);
            this.SendMessageBtn.TabIndex = 2;
            this.SendMessageBtn.Text = "Send";
            this.SendMessageBtn.UseVisualStyleBackColor = true;
            // 
            // ListenBtn
            // 
            this.ListenBtn.Location = new System.Drawing.Point(541, 22);
            this.ListenBtn.Name = "ListenBtn";
            this.ListenBtn.Size = new System.Drawing.Size(247, 70);
            this.ListenBtn.TabIndex = 3;
            this.ListenBtn.Text = "Listen";
            this.ListenBtn.UseVisualStyleBackColor = true;
            this.ListenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // IpTxtBox
            // 
            this.IpTxtBox.Location = new System.Drawing.Point(541, 173);
            this.IpTxtBox.Name = "IpTxtBox";
            this.IpTxtBox.Size = new System.Drawing.Size(247, 20);
            this.IpTxtBox.TabIndex = 4;
            // 
            // IpLbl
            // 
            this.IpLbl.AutoSize = true;
            this.IpLbl.Location = new System.Drawing.Point(538, 157);
            this.IpLbl.Name = "IpLbl";
            this.IpLbl.Size = new System.Drawing.Size(73, 13);
            this.IpLbl.TabIndex = 5;
            this.IpLbl.Text = "ChatServer IP";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(541, 199);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(247, 35);
            this.ConnectBtn.TabIndex = 6;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            // 
            // MultiChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.IpLbl);
            this.Controls.Add(this.IpTxtBox);
            this.Controls.Add(this.ListenBtn);
            this.Controls.Add(this.SendMessageBtn);
            this.Controls.Add(this.MessageTxtBox);
            this.Controls.Add(this.ChatBox);
            this.Name = "MultiChat";
            this.Text = "MultiChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.TextBox MessageTxtBox;
        private System.Windows.Forms.Button SendMessageBtn;
        private System.Windows.Forms.Button ListenBtn;
        private System.Windows.Forms.TextBox IpTxtBox;
        private System.Windows.Forms.Label IpLbl;
        private System.Windows.Forms.Button ConnectBtn;
    }
}

