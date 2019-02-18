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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(4, 5);
            this.ChatBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(506, 194);
            this.ChatBox.TabIndex = 0;
            this.ChatBox.Text = "";
            // 
            // MessageTxtBox
            // 
            this.MessageTxtBox.Location = new System.Drawing.Point(4, 242);
            this.MessageTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MessageTxtBox.Multiline = true;
            this.MessageTxtBox.Name = "MessageTxtBox";
            this.MessageTxtBox.Size = new System.Drawing.Size(323, 35);
            this.MessageTxtBox.TabIndex = 1;
            // 
            // SendMessageBtn
            // 
            this.SendMessageBtn.Location = new System.Drawing.Point(4, 294);
            this.SendMessageBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SendMessageBtn.Name = "SendMessageBtn";
            this.SendMessageBtn.Size = new System.Drawing.Size(160, 35);
            this.SendMessageBtn.TabIndex = 2;
            this.SendMessageBtn.Text = "Send";
            this.SendMessageBtn.UseVisualStyleBackColor = true;
            // 
            // ListenBtn
            // 
            this.ListenBtn.Location = new System.Drawing.Point(518, 5);
            this.ListenBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListenBtn.Name = "ListenBtn";
            this.ListenBtn.Size = new System.Drawing.Size(370, 108);
            this.ListenBtn.TabIndex = 3;
            this.ListenBtn.Text = "Listen";
            this.ListenBtn.UseVisualStyleBackColor = true;
            this.ListenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // IpTxtBox
            // 
            this.IpTxtBox.Location = new System.Drawing.Point(812, 266);
            this.IpTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IpTxtBox.Name = "IpTxtBox";
            this.IpTxtBox.Size = new System.Drawing.Size(368, 26);
            this.IpTxtBox.TabIndex = 4;
            // 
            // IpLbl
            // 
            this.IpLbl.AutoSize = true;
            this.IpLbl.Location = new System.Drawing.Point(807, 242);
            this.IpLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IpLbl.Name = "IpLbl";
            this.IpLbl.Size = new System.Drawing.Size(108, 20);
            this.IpLbl.TabIndex = 5;
            this.IpLbl.Text = "ChatServer IP";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(812, 306);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(370, 54);
            this.ConnectBtn.TabIndex = 6;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ChatBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ListenBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.MessageTxtBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SendMessageBtn, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(85, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1029, 501);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // MultiChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 702);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.IpLbl);
            this.Controls.Add(this.IpTxtBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MultiChat";
            this.Text = "MultiChat";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

