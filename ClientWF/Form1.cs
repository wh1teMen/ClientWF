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
using System.Xml.Serialization;
using System.Drawing.Text;

namespace ClientWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            SettingWindow.sizeWindow(this);
            SettingConnect.GetIPv4(comboBox_ip);
            SettingText.color_(comboBox_color);
            SettingText.Font_(comboBox_font);
            SettingText.SizeFont(comboBox_size);
        }      

            private void button1_Click(object sender, EventArgs e)
            {
            SettingConnect.conClient(comboBox_ip,maskedTextBox_port,textBox_msg,comboBox_size,comboBox_color,comboBox_font);
            }           
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                SettingConnect.conClient(comboBox_ip, maskedTextBox_port, textBox_msg, comboBox_size, comboBox_color, comboBox_font);
                }
            }
       
    }
}
