using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;

namespace ClientWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void conClient()
        {
            IPAddress ip;
            ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, 7777);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                s.Connect(ep);
                if (s.Connected)
                {

                    s.Send(Encoding.UTF8.GetBytes(" "+textBox1.Text+" "));
                    byte[] buffer = new byte[1024];
                    int l;
                    do
                    {
                        l = s.Receive(buffer);                       

                    } while (l > 0);                   

                }
                else
                    MessageBox.Show("Error");

            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {                
            conClient();
        }
        private void size()
        {
            int x = this.Width = 500;
            int y = this.Height = 120;
            this.MinimumSize = this.MaximumSize = this.Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            size();
        }
    }
}
