using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Chat
{
    public partial class Form1 : Form
    {
        public int BUFFSIZE = 1024;
        public int ALIASLEN = 32;
        public int OPTLEN = 16;
        public int LINEBUFF = 2048;

        struct PACKET {
            char[] option = new char[16];
            char[] alias = new char[ALIASLEN];
            char[] buff = new char[BUFFSIZE];
            //char option[OPTLEN]; // instruction
            //char alias[ALIASLEN]; // client's alias
            //char buff[BUFFSIZE]; // payload
        };
 
        struct USER {
                int sockfd; // user's socket descriptor
                char[] alias = new char[ALIASLEN];
                //char alias[ALIASLEN]; // user's name
        };
 
        struct THREADINFO {
            pthread_t thread_ID; // thread's pointer
            int sockfd; // socket file descriptor
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
            msg();
            clientSocket.Connect("127.0.0.1",8888);
            serverStream = clientSocket.GetStream();
            
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(txtAlias.Text + "$");
            serverStream.Write(outStream,0,outStream.Length);
            serverStream.Flush();

            alias = txtAlias.Text;
            lblMyName.Text = alias;

            Thread ctThread = new Thread(getPacket);
            ctThread.Start;
            
        }

        private void getPacket()
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

    }
}
