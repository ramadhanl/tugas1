using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Chat
{
    public partial class Form1 : Form
    {
        
        //Deklarasi variabel global
        
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        string option = null;
        string alias = null;
        string buff = null;
        string myname;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            readData = "Connected to Chat Server . . .";
            lblStatus.Text = "Connecting to 127.0.0.1:8888";
            msg();
            clientSocket.Connect("127.0.0.1",8888);
            serverStream = clientSocket.GetStream();
            
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("name$" + txtAlias.Text + "$");
            serverStream.Write(outStream,0,outStream.Length);
            serverStream.Flush();
            lblMyName.Text = txtAlias.Text;
            lblStatus.Text = "Connected";
            myname = txtAlias.Text;
            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
            
        }

        private void getMessage()
        {
            while(true)
            {
                serverStream = clientSocket.GetStream();
                int buffsize = 256;
                byte[] inStream = new byte[10025];
                //buffsize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream,0,buffsize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
                msg();
            }
        }

        private void msg()
        {
            option = null;
            alias = null;
            buff = null;
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
            {
                int count=0;
                string[] words = readData.Split('$');
                foreach (string word in words)
                {
                    if (count == 0)
                    {
                        option = "" + word;
                        count++;
                        chatBox.Items.Add(Environment.NewLine + " >> " + option);
                    }
                    else if (count == 1)
                    {
                        alias = "" + word;
                        //chatBox.Items.Add(Environment.NewLine + " >> " + alias);
                    }
                    else if (count == 2)
                    {
                        buff = "" + word;
                        chatBox.Items.Add(Environment.NewLine + "Buff >> " + buff);
                    }
                }

                if (option.Equals("list"))
                {
                    if (buff != null)
                    {
                        chatBox.Items.Add("masuk");
                        string[] words2 = buff.Split('%');
                        foreach (string word2 in words2)
                        {
                            onlineBox.Items.Add("haloo");
                        }
                    }
                    
                }
                if (option.Equals("pmpm"))
                {
                    chatBox.Items.Add(Environment.NewLine + "PM - [" + alias + "]>>  " + buff);
                }
                if (option.Equals("send"))
                {
                    chatBox.Items.Add(Environment.NewLine + "]>>  " + buff);
                }
            }

            
        }

        private void btnCheckOnline_Click(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("list$" + myname + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("exit$" + myname + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            serverStream.Close();
            lblStatus.Text = "Disconnected";
        }

        private void btnPublicChat_Click(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("send$" + myname + "$" + txtPublicChat.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            chatBox.Items.Add(Environment.NewLine + "Me : " + txtPublicChat.Text);
        }

        private void btnPrivateChat_Click(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("pmpm$" + myname + "$" + txtFriend.Text + "%" + txtPrivateChat.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }


    }
}
