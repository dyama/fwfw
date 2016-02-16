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
    public static int selectdir(OptsType opts, ArgsType args)
    {
      FolderBrowserDialog d = new FolderBrowserDialog();

      if (opts.ContainsKey("description")) {
        d.Description = opts["description"];
      }
      if (opts.ContainsKey("selecteddir")) {
        d.SelectedPath = opts["selecteddir"];
      }
      if (opts.ContainsKey("newdir")) {
        bool val;
        if (bool.TryParse(opts["newdir"], out val)) {
          d.ShowNewFolderButton = val;
        }
      }

      if (d.ShowDialog() != DialogResult.OK) {
        return 1;
      }

      Console.Out.WriteLine(d.SelectedPath);

      return 0;
    }
  }
}