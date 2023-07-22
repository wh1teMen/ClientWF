using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWF
{
    public class SettingConnect
    {
        IPAddress ip;
        IPEndPoint endPoint;
        Socket socket;
        public SettingConnect() { }
        public SettingConnect(string ip, int port)
        {
            // Создание сокета 
            socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP);
            this.ip = IPAddress.Parse(ip);
            endPoint = new IPEndPoint(this.ip, port);
        }
        public Socket _socket { get { return socket; } }
        public EndPoint _endPoint { get { return endPoint; } }
        public static void GetIPv4(ComboBox box)
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip_addr in host.AddressList)
            {
                // Выводим только адреса ipV4
                if (ip_addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    box.Items.Add(ip_addr.ToString());
                }
            }
            //добавляем стандартный ip
            box.Items.Add("127.0.0.1");
        }

        public static void conClient(ComboBox b, MaskedTextBox m,TextBox txt,ComboBox size,ComboBox color,ComboBox font)
        {
            Form1 f1 = new Form1();
            var ip = b.SelectedItem.ToString();
            var port = int.Parse(m.Text);
            var SettingConnect = new SettingConnect(ip, port);
            string xml = string.Empty;
            xml = Serializer.XMLSerializerFile(txt,size, color,font);
            try
            {
                SettingConnect._socket.Connect(SettingConnect._endPoint);
                if (SettingConnect._socket.Connected)
                {
                    SettingConnect._socket.Send(Encoding.UTF8.GetBytes(xml));
                    byte[] buffer = new byte[1024];
                    int l;
                    do
                    {
                        l = SettingConnect._socket.Receive(buffer);

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
                SettingConnect._socket.Shutdown(SocketShutdown.Both);
                SettingConnect._socket.Close();
            }


        }
    }
}
