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
            this.listOnline = new System.Windows.Forms.ListBox();
            this.lblOnline = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMyName = new System.Windows.Forms.Label();
            this.listChat = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(26, 21);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(61, 13);
            this.lblAlias.TabIndex = 0;
            this.lblAlias.Text = "My Name : ";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(236, 15);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(93, 18);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(136, 20);
            this.txtAlias.TabIndex = 2;
            // 
            // txtPublicChat
            // 
            this.txtPublicChat.Location = new System.Drawing.Point(22, 279);
            this.txtPublicChat.Name = "txtPublicChat";
            this.txtPublicChat.Size = new System.Drawing.Size(193, 29);
            this.txtPublicChat.TabIndex = 4;
            this.txtPublicChat.Text = "";
            // 
            // btnPublicChat
            // 
            this.btnPublicChat.Location = new System.Drawing.Point(218, 279);
            this.btnPublicChat.Name = "btnPublicChat";
            this.btnPublicChat.Size = new System.Drawing.Size(103, 29);
            this.btnPublicChat.TabIndex = 5;
            this.btnPublicChat.Text = "Send To All";
            this.btnPublicChat.UseVisualStyleBackColor = true;
            // 
            // txtPrivateChat
            // 
            this.txtPrivateChat.Location = new System.Drawing.Point(22, 321);
            this.txtPrivateChat.Name = "txtPrivateChat";
            this.txtPrivateChat.Size = new System.Drawing.Size(193, 30);
            this.txtPrivateChat.TabIndex = 6;
            this.txtPrivateChat.Text = "";
            // 
            // btnPrivateChat
            // 
            this.btnPrivateChat.Location = new System.Drawing.Point(218, 321);
            this.btnPrivateChat.Name = "btnPrivateChat";
            this.btnPrivateChat.Size = new System.Drawing.Size(103, 27);
            this.btnPrivateChat.TabIndex = 7;
            this.btnPrivateChat.Text = "Send to My Friend";
            this.btnPrivateChat.UseVisualStyleBackColor = true;
            // 
            // txtFriend
            // 
            this.txtFriend.Location = new System.Drawing.Point(428, 18);
            this.txtFriend.Name = "txtFriend";
            this.txtFriend.Size = new System.Drawing.Size(139, 20);
            this.txtFriend.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "My Friend :";
            // 
            // lblChatBox
            // 
            this.lblChatBox.AutoSize = true;
            this.lblChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatBox.Location = new System.Drawing.Point(107, 56);
            this.lblChatBox.Name = "lblChatBox";
            this.lblChatBox.Size = new System.Drawing.Size(108, 25);
            this.lblChatBox.TabIndex = 10;
            this.lblChatBox.Text = "Chat Box";
            // 
            // listOnline
            // 
            this.listOnline.FormattingEnabled = true;
            this.listOnline.Location = new System.Drawing.Point(343, 86);
            this.listOnline.Name = "listOnline";
            this.listOnline.Size = new System.Drawing.Size(247, 173);
            this.listOnline.TabIndex = 11;
            // 
            // lblOnline
            // 
            this.lblOnline.AutoSize = true;
            this.lblOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnline.Location = new System.Drawing.Point(338, 58);
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.Size = new System.Drawing.Size(171, 25);
            this.lblOnline.TabIndex = 12;
            this.lblOnline.Text = "Who\'s Online ?";
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLogout.Location = new System.Drawing.Point(343, 279);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(247, 72);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 24);
            this.button1.TabIndex = 14;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "You logged in as :";
            // 
            // lblMyName
            // 
            this.lblMyName.AutoSize = true;
            this.lblMyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyName.Location = new System.Drawing.Point(118, 262);
            this.lblMyName.Name = "lblMyName";
            this.lblMyName.Size = new System.Drawing.Size(0, 15);
            this.lblMyName.TabIndex = 16;
            // 
            // listChat
            // 
            this.listChat.FormattingEnabled = true;
            this.listChat.Location = new System.Drawing.Point(22, 86);
            this.listChat.Name = "listChat";
            this.listChat.Size = new System.Drawing.Size(299, 173);
            this.listChat.TabIndex = 17;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(603, 363);
            this.Controls.Add(this.listChat);
            this.Controls.Add(this.lblMyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblOnline);
            this.Controls.Add(this.listOnline);
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
        private System.Windows.Forms.ListBox listOnline;
        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMyName;
        private System.Windows.Forms.ListBox listChat;
    }
}

