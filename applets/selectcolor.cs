using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OptsType = System.Collections.Generic.Dictionary<System.String, System.String>;
using ArgsType = System.Collections.Generic.List<System.String>;

namespace fwfw
{
  static partial class Applet
  {
    public static int selectcolor(OptsType opts, ArgsType args)
    {
      ColorDialog d = new ColorDialog();

      if (opts.ContainsKey("solid")) {
        d.SolidColorOnly = true;
      }
      if (opts.ContainsKey("full")) {
        d.AllowFullOpen = true;
      }
      else {
        d.AllowFullOpen = false;
      }

      if (d.ShowDialog() != DialogResult.OK) {
        return 1;
      }

      if (d.Color.IsKnownColor) {
        Console.Out.WriteLine(d.Color.ToString());
      }
      else {
        byte r = d.Color.R;
        byte g = d.Color.G;
        byte b = d.Color.B;
        Console.Out.WriteLine(String.Format("#{0,2:x2}{1,2:x2}{2,2:x2}", r, g, b));
      }

      return 0;
    }
  }
}