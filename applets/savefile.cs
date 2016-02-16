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
    public static int savefile(OptsType opts, ArgsType args)
    {
      SaveFileDialog d = new SaveFileDialog();

      // Fixed options
      d.AddExtension = true;
      d.CheckFileExists = false;
      d.CheckPathExists = false;
      d.DereferenceLinks = true;
      d.RestoreDirectory = true;
      d.SupportMultiDottedExtensions = true;
      d.FilterIndex = 0;

      d.DefaultExt = "";
      if (opts.ContainsKey("ext")) {
        d.DefaultExt = opts["ext"];
      }

      d.FileName = "";
      if (opts.ContainsKey("file")) {
        d.FileName = opts["file"];
      }

      d.Filter = "";
      if (opts.ContainsKey("filter")) {
        try {
          d.Filter = opts["filter"];
        }
        catch {
          Console.Error.WriteLine("Error: Incorrect filter specified: " + opts["filter"]);
          return 1;
        }
      }

      d.Title = "";
      if (opts.ContainsKey("title")) {
        d.Title = opts["title"];
      }

      d.InitialDirectory = "";
      if (opts.ContainsKey("init")) {
        d.InitialDirectory = opts["init"];
      }

      if (d.ShowDialog() != DialogResult.OK) {
        return 1;
      }

      Console.Out.WriteLine(d.FileName);

      return 0;
    }
  }
}    
