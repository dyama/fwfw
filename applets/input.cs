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
    public static int input(OptsType opts, ArgsType args)
    {
      const int m = 5; // margin

      Form f = new Form();
      f.Width = 480;
      f.Height = 110;
      f.FormBorderStyle = FormBorderStyle.FixedDialog;
      f.MaximizeBox = false;
      f.MinimizeBox = true;
      f.StartPosition = FormStartPosition.CenterScreen;
      f.TopMost = true;
      f.Text = opts.ContainsKey("caption") ? opts["caption"] : "fwfw";

      Label l = new Label();
      l.Left = m;
      l.Top = m;
      l.Text = opts.ContainsKey("message") ? opts["message"] : "Please input.";
      f.Controls.Add(l);

      TextBox t = new TextBox();
      t.Left = m;
      t.Top = l.Bottom;
      t.Width = f.ClientRectangle.Width - m;
      if (opts.ContainsKey("password")) {
        t.UseSystemPasswordChar = true;
      }
      f.Controls.Add(t);

      Button ok = new Button();
      ok.Width = 96;
      ok.Height = 24;
      ok.Left = t.ClientRectangle.Width - ok.Width;
      ok.Top = t.Bottom + m;
      ok.Text = "&OK";
      ok.Click += (s, e) => f.Close();
      f.Controls.Add(ok);
      f.AcceptButton = ok;

      f.ShowDialog();

      Console.Out.WriteLine(t.Text);
      return 0;
    }
  }
}
