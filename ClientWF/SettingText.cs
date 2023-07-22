using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWF
{
   public class SettingText
    {
       public static void color_(ComboBox box)
        {
            List<string> colors = new List<string>();

            foreach (string colorName in Enum.GetNames(typeof(KnownColor)))
            {
                KnownColor knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), colorName);
                if (knownColor > KnownColor.Transparent)
                {

                    colors.Add(colorName);
                }
            }
            colors.ForEach(x => box.Items.Add(x));
        }
       public static void Font_(ComboBox box)
        {
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily font in fonts.Families)
            {
                box.Items.Add(font.Name);
            }
        }
       public static void SizeFont(ComboBox box)
        {

            for (int i = 8; i <= 100; i += 2)
            {
                box.Items.Add(i);

            }

        }
    }
}
