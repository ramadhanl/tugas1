namespace RSAEncDec
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
            this.txtplain = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtencrypt = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtdecrypt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtplain
            // 
            this.txtplain.Location = new System.Drawing.Point(28, 71);
            this.txtplain.Name = "txtplain";
            this.txtplain.Size = new System.Drawing.Size(642, 76);
            this.txtplain.TabIndex = 0;
            this.txtplain.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(696, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 76);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtencrypt
            // 
            this.txtencrypt.Location = new System.Drawing.Point(28, 170);
            this.txtencrypt.Name = "txtencrypt";
            this.txtencrypt.Size = new System.Drawing.Size(642, 76);
            this.txtencrypt.TabIndex = 2;
            this.txtencrypt.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(696, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 76);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtdecrypt
            // 
            this.txtdecrypt.Location = new System.Drawing.Point(28, 268);
            this.txtdecrypt.Name = "txtdecrypt";
            this.txtdecrypt.Size = new System.Drawing.Size(743, 106);
            this.txtdecrypt.TabIndex = 4;
            this.txtdecrypt.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 394);
            this.Controls.Add(this.txtdecrypt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtencrypt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtplain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtplain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txtencrypt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox txtdecrypt;
    }
}

