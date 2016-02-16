using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using OptsType = System.Collections.Generic.Dictionary<System.String, System.String>;
using ArgsType = System.Collections.Generic.List<System.String>;

namespace fwfw
{
  static partial class Applet
  {
    public static int drawer(OptsType opts, ArgsType args)
    {
      string[] commands = Regex.Split(Console.In.ReadToEnd(), @"\r?\n");

      System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
      List<PointF> pts = new List<PointF>();
      foreach (var line in commands) {
        var items = Regex.Split(line, @"\s+");
        if (items.Length != 2) {
          if (pts.Count > 0) {
            if (pts.Count == 1) {
              gp.AddLine(pts.First(), pts.First());
            }
            else {
              gp.AddLines(pts.ToArray());
            }
            pts.Clear();
          }
          continue;
        }
        float x, y;
        if (float.TryParse(items[0], out x) && float.TryParse(items[1], out y)) {
          pts.Add(new PointF(x, y));
        }
      }

      Color bgcolor = Color.Black;
      if (opts.ContainsKey("bgcolor")) {
        bgcolor = Color.FromName(opts["bgcolor"]);
      }

      Color fgcolor = Color.White;
      if (opts.ContainsKey("fgcolor")) {
        fgcolor = Color.FromName(opts["fgcolor"]);
      }

      float pensize = 1.0f;
      if (opts.ContainsKey("pensize")) {
        float val;
        if (float.TryParse(opts["pensize"], out val)) {
          pensize = val;
        }
      }

      string title = "fwfw drawer";
      if (opts.ContainsKey("title")) {
        title = opts["title"];
      }

      int width = 512;
      if (opts.ContainsKey("width")) {
        int val;
        if (int.TryParse(opts["width"], out val)) {
          width = val;
        }
      }
      int height = 512;
      if (opts.ContainsKey("height")) {
        int val;
        if (int.TryParse(opts["height"], out val)) {
          height = val;
        }
      }

      Form f = new Form();
      f.Text = title;
      f.StartPosition = FormStartPosition.CenterScreen;
      f.Size = new Size(width, height);

      f.Resize += (s, e) => {
        Bitmap bitmap = new Bitmap(f.ClientRectangle.Width, f.ClientRectangle.Height);
        Graphics g = Graphics.FromImage(bitmap);
        g.FillRectangle(new SolidBrush(bgcolor), f.ClientRectangle);
        g.DrawPath(new Pen(fgcolor, pensize), gp);
        g.Dispose();
        f.BackgroundImage = bitmap;
      };

      f.MouseClick += (s, e) => {
        var loc = f.PointToClient(e.Location);
        Console.Out.WriteLine($"{e.Location.X}\t{e.Location.Y}");
      };

      f.ShowDialog();

      return 0;
    }

  }
}