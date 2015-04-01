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
using System.Security.Cryptography;
//Enkripsi Simetris : DES
//Mode Operasi : CFB
//Key Exchange : RSA

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
        string plainText = null;
        int connect = 1;
        public Form1()
        {
            InitializeComponent();
        }

        

        public void Encryption()
        {
            
            //plainText = plainText + "TelahDienkripsi";
            //Convert string to Hexa
            char[] values = plainText.ToCharArray();
            string hexText=null;
            int count = 0,block=1;
            foreach (char letter in values)
            {
                // Get the integral value of the character. 
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form. 
                string hexOutput = String.Format("{0:X}", value);
                if (count % 8 == 0)
                {
                    chatBox.Items.Add("Block [" + block +"] : " + hexText);
                    block++;
                    hexText = null;
                }
                count++;
                hexText = hexText + "-" + hexOutput; 
                //chatBox.Items.Add("Hexadecimal value of {"+ letter + " }is {" + hexOutput + "} - " + value);
            }
        }

        public void Decryption()
        {
            readData = readData + "TelahDidekripsi";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            readData = "Connected to Chat Server . . .";
            lblStatus.Text = "Connecting to 127.0.0.1:8888";
            msg();
            int port;
            port = Convert.ToInt32(txtPort.Text);
            port = int.Parse(txtPort.Text);
            clientSocket.Connect(txtAddress.Text,port);
            serverStream = clientSocket.GetStream();
            
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("name$" + txtAlias.Text + "$");
            serverStream.Write(outStream,0,outStream.Length);
            serverStream.Flush();
            lblMyName.Text = txtAlias.Text;
            lblStatus.Text = "Connected";
            chatBox.Items.Add(Environment.NewLine + ">> " + readData);
            myname = txtAlias.Text;
            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
            
        }

        private void getMessage()
        {
            while(connect==1)
            {
                serverStream = clientSocket.GetStream();
                int buffsize = 256;
                byte[] inStream = new byte[10025];
                //buffsize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream,0,buffsize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
                Decryption();
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
                //chatBox.Items.Add(Environment.NewLine + "-> " + readData);
                string[] words = readData.Split('$');
                foreach (string word in words)
                {
                    if (count == 0)
                    {
                        option = "" + word;
                        count++;
                        //chatBox.Items.Add(Environment.NewLine + " >> " + option);
                    }
                    else if (count == 1)
                    {
                        alias = "" + word;
                        count++;
                        //chatBox.Items.Add(Environment.NewLine + " >> " + alias);
                    }
                    else if (count == 2)
                    {
                        buff = "" + word;
                        count++;
                        //chatBox.Items.Add(Environment.NewLine + "Buff >> " + buff);
                    }
                }

                if (option.Equals("list"))
                {
                    onlineBox.Items.Clear();
                    if (buff != null)
                    {
                        string[] words2 = buff.Split('%');
                        foreach (string word2 in words2)
                        {
                            onlineBox.Items.Add(word2);
                        }
                    }
                    else
                    {
                        onlineBox.Items.Add("Tidak ada user yang online");
                    }
                }
                if (option.Equals("pmpm"))
                {
                    chatBox.Items.Add(Environment.NewLine + "[PM][" + alias + "] >>  " + buff);
                }
                if (option.Equals("send"))
                {
                    chatBox.Items.Add(Environment.NewLine + "[" + alias + "] >>  " + buff);
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
            connect = 0;
            lblStatus.Text = "Disconnected";
        }

        private void btnPublicChat_Click(object sender, EventArgs e)
        {
            plainText = "send$" + myname + "$" + txtPublicChat.Text;
            Encryption();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(plainText);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            chatBox.Items.Add(Environment.NewLine + "Me >> " + plainText);
        }

        private void btnPrivateChat_Click(object sender, EventArgs e)
        {
            plainText = "pmpm$" + myname + "$" + txtFriend.Text + "%" + txtPrivateChat.Text;
            Encryption();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(plainText);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            chatBox.Items.Add(Environment.NewLine + "PM to " + txtFriend.Text +" >> " + plainText);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chatBox.Items.Clear();
        }


    }
}
