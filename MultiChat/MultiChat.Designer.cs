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
            this.IpTxtBox = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.ListenBtn = new System.Windows.Forms.Button();
            this.IpLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChatLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ServerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ConnectLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ChatLayout.SuspendLayout();
            this.ServerLayout.SuspendLayout();
            this.ConnectLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(3, 3);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(342, 221);
            this.ChatBox.TabIndex = 0;
            this.ChatBox.Text = "";
            // 
            // MessageTxtBox
            // 
            this.MessageTxtBox.Location = new System.Drawing.Point(3, 230);
            this.MessageTxtBox.Multiline = true;
            this.MessageTxtBox.Name = "MessageTxtBox";
            this.MessageTxtBox.Size = new System.Drawing.Size(342, 20);
            this.MessageTxtBox.TabIndex = 1;
            // 
            // SendMessageBtn
            // 
            this.SendMessageBtn.Location = new System.Drawing.Point(351, 230);
            this.SendMessageBtn.Name = "SendMessageBtn";
            this.SendMessageBtn.Size = new System.Drawing.Size(81, 20);
            this.SendMessageBtn.TabIndex = 2;
            this.SendMessageBtn.Text = "Send";
            this.SendMessageBtn.UseVisualStyleBackColor = true;
            // 
            // IpTxtBox
            // 
            this.IpTxtBox.Location = new System.Drawing.Point(3, 23);
            this.IpTxtBox.Name = "IpTxtBox";
            this.IpTxtBox.Size = new System.Drawing.Size(137, 20);
            this.IpTxtBox.TabIndex = 4;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(3, 48);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(137, 28);
            this.ConnectBtn.TabIndex = 6;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            // 
            // ListenBtn
            // 
            this.ListenBtn.Location = new System.Drawing.Point(3, 3);
            this.ListenBtn.Name = "ListenBtn";
            this.ListenBtn.Size = new System.Drawing.Size(83, 20);
            this.ListenBtn.TabIndex = 3;
            this.ListenBtn.Text = "Start";
            this.ListenBtn.UseVisualStyleBackColor = false;
            this.ListenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // IpLbl
            // 
            this.IpLbl.AutoSize = true;
            this.IpLbl.Location = new System.Drawing.Point(3, 0);
            this.IpLbl.Name = "IpLbl";
            this.IpLbl.Size = new System.Drawing.Size(73, 13);
            this.IpLbl.TabIndex = 5;
            this.IpLbl.Text = "ChatServer IP";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 26);
            this.label2.TabIndex = 13;
            this.label2.Text = "Server can only be started from one client";
            // 
            // ChatLayout
            // 
            this.ChatLayout.ColumnCount = 2;
            this.ChatLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.ChatLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ChatLayout.Controls.Add(this.ChatBox, 0, 0);
            this.ChatLayout.Controls.Add(this.SendMessageBtn, 1, 1);
            this.ChatLayout.Controls.Add(this.MessageTxtBox, 0, 1);
            this.ChatLayout.Location = new System.Drawing.Point(12, 10);
            this.ChatLayout.Name = "ChatLayout";
            this.ChatLayout.RowCount = 2;
            this.ChatLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.ChatLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ChatLayout.Size = new System.Drawing.Size(435, 253);
            this.ChatLayout.TabIndex = 14;
            // 
            // ServerLayout
            // 
            this.ServerLayout.ColumnCount = 1;
            this.ServerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ServerLayout.Controls.Add(this.ListenBtn, 0, 0);
            this.ServerLayout.Controls.Add(this.label2, 0, 1);
            this.ServerLayout.Location = new System.Drawing.Point(453, 10);
            this.ServerLayout.Name = "ServerLayout";
            this.ServerLayout.RowCount = 2;
            this.ServerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ServerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.ServerLayout.Size = new System.Drawing.Size(143, 100);
            this.ServerLayout.TabIndex = 15;
            // 
            // ConnectLayout
            // 
            this.ConnectLayout.ColumnCount = 1;
            this.ConnectLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConnectLayout.Controls.Add(this.IpLbl, 0, 0);
            this.ConnectLayout.Controls.Add(this.IpTxtBox, 0, 1);
            this.ConnectLayout.Controls.Add(this.ConnectBtn, 0, 2);
            this.ConnectLayout.Location = new System.Drawing.Point(453, 116);
            this.ConnectLayout.Name = "ConnectLayout";
            this.ConnectLayout.RowCount = 3;
            this.ConnectLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ConnectLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ConnectLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.ConnectLayout.Size = new System.Drawing.Size(143, 100);
            this.ConnectLayout.TabIndex = 16;
            // 
            // MultiChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 275);
            this.Controls.Add(this.ConnectLayout);
            this.Controls.Add(this.ServerLayout);
            this.Controls.Add(this.ChatLayout);
            this.Name = "MultiChat";
            this.Text = "MultiChat";
            this.ChatLayout.ResumeLayout(false);
            this.ChatLayout.PerformLayout();
            this.ServerLayout.ResumeLayout(false);
            this.ServerLayout.PerformLayout();
            this.ConnectLayout.ResumeLayout(false);
            this.ConnectLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.TextBox MessageTxtBox;
        private System.Windows.Forms.Button SendMessageBtn;
        private System.Windows.Forms.Button ListenBtn;
        private System.Windows.Forms.TextBox IpTxtBox;
        private System.Windows.Forms.Label IpLbl;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel ChatLayout;
        private System.Windows.Forms.TableLayoutPanel ServerLayout;
        private System.Windows.Forms.TableLayoutPanel ConnectLayout;
    }
}

