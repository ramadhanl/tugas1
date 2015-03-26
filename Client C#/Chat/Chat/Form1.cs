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
        struct PACKET {
            public string option;
            public string alias;
            public string buff;
        };
 
        struct USER {
             int sockfd; // user's socket descriptor
        };
 
        //Deklarasi variabel global
        string alias;

        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;

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
            alias = txtAlias.Text;
            listChat.Text = "Haloo";
            Thread ctThread = new Thread(getMessage);
            //ctThread.Start();
            
        }

        private void getMessage()
        {
            while(true)
            {
                serverStream = clientSocket.GetStream();
                int buffsize = 0;
                byte[] inStream = new byte[10025];
                buffsize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream,0,buffsize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
                msg();
            }
        }

        private void msg()
        {
            if(this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                listChat.Text = listChat.Text + Environment.NewLine + " >> " + readData;
        }

        private void btnCheckOnline_Click(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("list$" + alias + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("exit$" + alias + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            lblStatus.Text = "Disconnected";
        }


    }
}
