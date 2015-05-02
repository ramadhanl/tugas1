namespace Chat
{
    partial class Form1
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
            this.lblAlias = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.txtPublicChat = new System.Windows.Forms.RichTextBox();
            this.btnPublicChat = new System.Windows.Forms.Button();
            this.txtPrivateChat = new System.Windows.Forms.RichTextBox();
            this.btnPrivateChat = new System.Windows.Forms.Button();
            this.txtFriend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblChatBox = new System.Windows.Forms.Label();
            this.lblOnline = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCheckOnline = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMyName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chatBox = new System.Windows.Forms.ListBox();
            this.onlineBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.progressBox = new System.Windows.Forms.RichTextBox();
            this.progressBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(9, 14);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(61, 13);
            this.lblAlias.TabIndex = 0;
            this.lblAlias.Text = "My Name : ";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogin.Location = new System.Drawing.Point(516, 8);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 24);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Connect";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(64, 11);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(136, 20);
            this.txtAlias.TabIndex = 2;
            // 
            // txtPublicChat
            // 
            this.txtPublicChat.Location = new System.Drawing.Point(9, 279);
            this.txtPublicChat.Name = "txtPublicChat";
            this.txtPublicChat.Size = new System.Drawing.Size(193, 29);
            this.txtPublicChat.TabIndex = 4;
            this.txtPublicChat.Text = "";
            // 
            // btnPublicChat
            // 
            this.btnPublicChat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPublicChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicChat.Location = new System.Drawing.Point(205, 279);
            this.btnPublicChat.Name = "btnPublicChat";
            this.btnPublicChat.Size = new System.Drawing.Size(119, 29);
            this.btnPublicChat.TabIndex = 5;
            this.btnPublicChat.Text = "Send To All";
            this.btnPublicChat.UseVisualStyleBackColor = false;
            this.btnPublicChat.Click += new System.EventHandler(this.btnPublicChat_Click);
            // 
            // txtPrivateChat
            // 
            this.txtPrivateChat.Location = new System.Drawing.Point(9, 341);
            this.txtPrivateChat.Name = "txtPrivateChat";
            this.txtPrivateChat.Size = new System.Drawing.Size(193, 30);
            this.txtPrivateChat.TabIndex = 6;
            this.txtPrivateChat.Text = "";
            // 
            // btnPrivateChat
            // 
            this.btnPrivateChat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPrivateChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrivateChat.Location = new System.Drawing.Point(205, 341);
            this.btnPrivateChat.Name = "btnPrivateChat";
            this.btnPrivateChat.Size = new System.Drawing.Size(119, 30);
            this.btnPrivateChat.TabIndex = 7;
            this.btnPrivateChat.Text = "Send to My Friend";
            this.btnPrivateChat.UseVisualStyleBackColor = false;
            this.btnPrivateChat.Click += new System.EventHandler(this.btnPrivateChat_Click);
            // 
            // txtFriend
            // 
            this.txtFriend.Location = new System.Drawing.Point(66, 314);
            this.txtFriend.Name = "txtFriend";
            this.txtFriend.Size = new System.Drawing.Size(136, 20);
            this.txtFriend.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "My Friend :";
            // 
            // lblChatBox
            // 
            this.lblChatBox.AutoSize = true;
            this.lblChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatBox.Location = new System.Drawing.Point(12, 42);
            this.lblChatBox.Name = "lblChatBox";
            this.lblChatBox.Size = new System.Drawing.Size(108, 25);
            this.lblChatBox.TabIndex = 10;
            this.lblChatBox.Text = "Chat Box";
            // 
            // lblOnline
            // 
            this.lblOnline.AutoSize = true;
            this.lblOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnline.Location = new System.Drawing.Point(349, 42);
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.Size = new System.Drawing.Size(171, 25);
            this.lblOnline.TabIndex = 12;
            this.lblOnline.Text = "Who\'s Online ?";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Gray;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(344, 299);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(247, 72);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCheckOnline
            // 
            this.btnCheckOnline.BackColor = System.Drawing.Color.Blue;
            this.btnCheckOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOnline.ForeColor = System.Drawing.Color.White;
            this.btnCheckOnline.Location = new System.Drawing.Point(516, 42);
            this.btnCheckOnline.Name = "btnCheckOnline";
            this.btnCheckOnline.Size = new System.Drawing.Size(75, 25);
            this.btnCheckOnline.TabIndex = 20;
            this.btnCheckOnline.Text = "Check";
            this.btnCheckOnline.UseVisualStyleBackColor = false;
            this.btnCheckOnline.Click += new System.EventHandler(this.btnCheckOnline_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "You logged in as :";
            // 
            // lblMyName
            // 
            this.lblMyName.AutoSize = true;
            this.lblMyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyName.Location = new System.Drawing.Point(105, 262);
            this.lblMyName.Name = "lblMyName";
            this.lblMyName.Size = new System.Drawing.Size(0, 15);
            this.lblMyName.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(51, 374);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(33, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "None";
            // 
            // chatBox
            // 
            this.chatBox.FormattingEnabled = true;
            this.chatBox.Location = new System.Drawing.Point(9, 71);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(315, 186);
            this.chatBox.TabIndex = 21;
            // 
            // onlineBox
            // 
            this.onlineBox.FormattingEnabled = true;
            this.onlineBox.Location = new System.Drawing.Point(349, 67);
            this.onlineBox.Name = "onlineBox";
            this.onlineBox.Size = new System.Drawing.Size(242, 212);
            this.onlineBox.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(238, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 25);
            this.button1.TabIndex = 23;
            this.button1.Text = "Clear Chat";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(202, 15);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 24;
            this.lblAddress.Text = "Address :";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(254, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(110, 20);
            this.txtAddress.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Port :";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(406, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(103, 20);
            this.txtPort.TabIndex = 27;
            // 
            // progressBox
            // 
            this.progressBox.Location = new System.Drawing.Point(11, 396);
            this.progressBox.Name = "progressBox";
            this.progressBox.Size = new System.Drawing.Size(580, 81);
            this.progressBox.TabIndex = 28;
            this.progressBox.Text = "";
            // 
            // progressBox2
            // 
            this.progressBox2.Location = new System.Drawing.Point(13, 510);
            this.progressBox2.Name = "progressBox2";
            this.progressBox2.Size = new System.Drawing.Size(578, 75);
            this.progressBox2.TabIndex = 29;
            this.progressBox2.Text = "";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(603, 597);
            this.Controls.Add(this.progressBox2);
            this.Controls.Add(this.progressBox);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.onlineBox);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheckOnline);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblOnline);
            this.Controls.Add(this.lblChatBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFriend);
            this.Controls.Add(this.btnPrivateChat);
            this.Controls.Add(this.txtPrivateChat);
            this.Controls.Add(this.btnPublicChat);
            this.Controls.Add(this.txtPublicChat);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblAlias);
            this.Name = "Form1";
            this.Text = "Chat Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_alias;
        private System.Windows.Forms.Label lbl_alias;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.RichTextBox txtPublicChat;
        private System.Windows.Forms.Button btnPublicChat;
        private System.Windows.Forms.RichTextBox txtPrivateChat;
        private System.Windows.Forms.Button btnPrivateChat;
        private System.Windows.Forms.TextBox txtFriend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblChatBox;
        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCheckOnline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox chatBox;
        private System.Windows.Forms.ListBox onlineBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.RichTextBox progressBox;
        private System.Windows.Forms.RichTextBox progressBox2;
    }
}

