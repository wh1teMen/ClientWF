using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ClientWF
{
    public class Serializer
    {
        public static string XMLSerializerFile(TextBox txt,ComboBox size,ComboBox color,ComboBox font)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Message));
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                Message m = new Message
                {
                    text = txt.Text,
                    size = int.Parse(size.SelectedItem.ToString()),
                    color = color.SelectedItem.ToString(),
                    font = font.SelectedItem.ToString(),
                };
                serializer.Serialize(stringWriter, m);
                xml = stringWriter.ToString();
            }
            return xml;
        }
    }
}
