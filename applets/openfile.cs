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
    public static int openfile(OptsType opts, ArgsType args)
    {
      OpenFileDialog d = new OpenFileDialog();

      // Fixed options
      d.AddExtension = true;
      d.CheckFileExists = true;
      d.CheckPathExists = true;
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

      d.Multiselect = opts.ContainsKey("multi");

      if (d.ShowDialog() != DialogResult.OK) {
        return 1;
      }

      if (d.Multiselect) {
        foreach (var file in d.FileNames) {
          Console.Out.WriteLine(file);
        }
      }
      else {
        Console.Out.WriteLine(d.FileName);
      }

      return 0;
    }
  }
}    
