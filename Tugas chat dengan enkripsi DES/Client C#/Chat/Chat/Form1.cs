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
        string key = "12345678";
        string key2 = null;
        string[] c = new string[16];
        string[] d = new string[16];
        string[] skey2 = new string[16];
        string skey = null;
        int connect = 1;
        char[] bin;
        string textbiner;
        string[] plainBlock = new string[50];
        string initialp = null;
        string datablock,r2,re,rs2,free,le,free2,data;
        string[] rs = new string[8];
        string[] rs3 = new string[8];
        string[] l = new string[17];
        string[] r = new string[17];
        int[] pc1 = { 57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18, 10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36, 63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4 };
        int[] pc2 = { 14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10, 23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2, 41, 52, 31, 37, 47, 55, 30, 40, 51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32 };
        int[] ip = { 58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4, 62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8, 57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3, 61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7 };
        int[] et = { 32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11, 12, 13, 12, 13, 14, 15, 16, 17, 16, 17, 18, 19, 20, 21, 20, 21, 22, 23, 24, 25, 24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1 };
        int[,] sb1 = { 
                     {14  ,4  ,13 , 1  , 2 ,15 , 11  ,8  , 3, 10 ,  6 ,12,   5  ,9  , 0 , 7},
                     {0, 15,   7,  4 , 14 , 2 , 13  ,1 , 10 , 6  ,12 ,11  , 9 , 5 ,  3 , 8},
                     {4 , 1 , 14 , 8  ,13 , 6  , 2 ,11 , 15 ,12  , 9  ,7  , 3, 10  , 5 , 0},
                     {15, 12  , 8,  2  , 4 , 9 ,  1  ,7  , 5 ,11  , 3 ,14  ,10 , 0  , 6, 13}
                     };
        int[] pt = { 16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26, 5, 18, 31, 10, 2, 8, 24, 1432, 27, 3, 919, 13, 30, 6, 22, 11, 4, 25 };
        public Form1()
        {
            InitializeComponent();
        }

        //Create 16 Subkeys
        public void CreateSubKeys()
        {
            string values = key.ToString();
            int p;
            c[0] = null;
            key = new string(StringToBinary(values).ToCharArray());
            //Permuted choice 1
            for (int i = 0; i < 56; i++)
            {
                p = pc1[i] - 1;
                key2 = key2 + key[p];
                if(i<28)
                    c[0] = c[0] + key[p];
                else
                    d[0] = d[0] + key[p];
            }
            //Left Circular Shift
            for (int i = 0; i < 16; i++)
            {
                c[i] = c[i-1];
                d[i] = d[i-1];
            }
            //Permuted Choice 2
            for (int j = 0; j < 16; j++)
            {
                skey = c[0] + d[0];
                skey2[j] = null;
                for (int i = 0; i < 48; i++)
                {
                    p = pc2[i] - 1;
                    skey2[j] = skey2[j] + skey[p];
                }
            }
            progressBox.Text = skey;
            progressBox2.Text = skey2[15];
        }
        //Encode 64 bit data
        public void DES()
        {
            //Initial Permutation
            datablock = plainBlock[0];
            for (int j=0; j < 64; j++)
            {
                int p = ip[j] - 1;
                initialp = initialp + datablock[p];
                if (j < 32)
                {
                    l[0] = l[0] + datablock[p];
                }
                else
                {
                    r[0] = r[0] + datablock[p];
                }
            }
            progressBox.Text = initialp;

            for (int i = 1; i <=16; i++)
            {
                l[i] = r[i - 1];
                r2=r[i-1];
                re=null;
                r[i] = null;
                //Expansion Permutation
                for (int j = 0; j < 48; j++)
                {
                    int p=et[j] - 1;
                    re = re + r2[p];
                }
                //XORkan re dengan subkey[i]
                free = null;
                for (int j = 0; j < 48; j++)
                {
                    free2 = skey2[i-1];
                    if (re[j] == free2[j])
                        free = free + "0";
                    else
                        free = free + "1";
                }
                re = free;
                //Substitution choice
                int cnt = 0;
                rs[0] = null;
                for (int x = 0; x < 48; x++)
                {
                    if (i+1 % 6 == 0 && i!=47)
                    {
                        cnt++;
                        rs[cnt] = null;
                    }
                    rs[cnt] = rs[cnt] + re[x];
                }
                for (int x = 0; x < 8; x++)
                {
                    rs2 = rs[x];
                    //rs2 = "010101";
                    int xi, yi,zi;
                    int a, b, c, d, e, f;
                    if (rs2[0] == '1')
                        a = 1;
                    else
                        a = 0;
                    if (rs2[1] == '1')
                        b = 1;
                    else
                        b = 0;
                    if (rs2[2] == '1')
                        c = 1;
                    else
                        c = 0;
                    if (rs2[3] == '1')
                        d = 1;
                    else
                        d = 0;
                    if (rs2[4] == '1')
                        e = 1;
                    else
                        e = 0;
                    if (rs2[5] == '1')
                        f = 1;
                    else
                        f = 0;

                    xi = a * 2 + f * 1;
                    yi = b * 8 + c * 4 + d * 2 + e * 1;
             
                    zi = sb1[xi,yi];
                    rs[x] = Convert.ToString(zi, 2); //Convert int to Binary
                    chatBox.Items.Add(Environment.NewLine + "-> " + rs[x] + "-" + zi + "-" + xi + "-" + yi+ "-" + rs[x]);
                }
                r[i] = null;
                for (int x = 0; x < 8; x++)
                {
                    r[i] = r[i] + rs[x];
                }
                //Permutation
                re = null;
                /*for (int a = 0; a < 32; a++)
                {
                    int p = pt[a] - 1;
                    re = re + r[p];
                }*/
                r[i] = re;

                //XORkan R dengan L
                free = null;
                //re = r[i];
                re = "01010101010101010101010101010101";
                le = l[i-1];
                for (int j = 0; j < 32; j++)
                {
                    if (re[j] == le[j])
                        free = free + "0";
                    else
                        free = free + "1";
                }
                le = free;
                r[i] = free;
            }
            progressBox2.Text = l[1]+r[1];
        }

        //Create Block
        public void CreateBlock()
        {
            int x = plainText.Length;
            int count = 0;
            plainBlock[0] = null;
            textbiner = null;
            for (int i = 0; i < x; i++)
            {
                if (i % 64==0 && i!=0)
                {
                    count++;
                    plainBlock[count] = null;
                }
                plainBlock[count] = plainBlock[count] + plainText[i];
            }
            //progressBox.Text = plainText;
            //progressBox2.Text = plainBlock[0];
        }
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();
            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }


        public void Encryption()
        {
            string values = plainText.ToString();
            //bin = StringToBinary(values).ToCharArray();
            bin = StringToBinary(values).ToCharArray();
            plainText = new string(bin);
            //plainText = plainText + "TelahDienkripsi";
            //Convert string to Hexa
            CreateSubKeys();
            //CreateBlock();
            //DES();
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
            plainText = txtPublicChat.Text;
            data = "send$" + myname + "$" + plainText;
            Encryption();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(data);
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
