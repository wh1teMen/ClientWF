using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWF
{
   public class SettingWindow
    {
        static public void sizeWindow(Form1 form)
        {
          form.Width = 550;
          form.Height = 255;
          form.MinimumSize = form.MaximumSize = form.Size;

        }
    }
}
