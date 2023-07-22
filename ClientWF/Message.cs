using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ClientWF
{
    [Serializable]
    public class Message
    {

        [XmlAttribute]
        public string text;
        [XmlAttribute]
        public int size;
        [XmlAttribute]
        public string color;

        [XmlAttribute]
        public string font;

        public Message() { }

        public Message(string text, int size, string font, string color)
        {
            this.text = text;
            this.size = size;
            this.color = color;
            this.font = font;
        }
        public void Serealize_it(Message message, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Message));
            using (Stream fStream = new FileStream(filename,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlSerializer.Serialize(fStream, message);
            }
        }        
    }
}
