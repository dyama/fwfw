using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using OptsType = System.Collections.Generic.Dictionary<System.String, System.String>;
using ArgsType = System.Collections.Generic.List<System.String>;

namespace fwfw
{
  static partial class Applet
  {
    public static int calender(OptsType opts, ArgsType args)
    {
      Form f = new Form();

      Panel p = new Panel();
      p.Height = 24;
      p.Dock = DockStyle.Bottom;
      f.Controls.Add(p);

      Button b1 = new Button();
      b1.DialogResult = DialogResult.OK;
      b1.Dock = DockStyle.Fill;
      b1.Text = "&OK";
      p.Controls.Add(b1);

      int year = DateTime.Now.Year;
      if (opts.ContainsKey("year")) {
        int val;
        if (int.TryParse(opts["year"], out val)) {
          year = val;
        }
      }

      int month = DateTime.Now.Month;
      if (opts.ContainsKey("month")) {
        int val;
        if (int.TryParse(opts["month"], out val)) {
          month = val;
        }
      }

      int day = DateTime.Now.Day;
      if (opts.ContainsKey("day")) {
        int val;
        if (int.TryParse(opts["day"], out val)) {
          day = val;
        }
      }

      MonthCalendar mc = new MonthCalendar();
      mc.CalendarDimensions = new Size(1, 1);
      mc.MaxSelectionCount = 42;
      mc.SetDate(new DateTime(year, month, day));
      f.Controls.Add(mc);

      f.Text = "fwfw calender";
      if (opts.ContainsKey("title")) {
        f.Text = opts["title"];
      }
      f.MaximizeBox = false;
      f.FormBorderStyle = FormBorderStyle.FixedDialog;
      f.StartPosition = FormStartPosition.CenterScreen;
      f.ClientSize = mc.Size;
      f.Height = f.Height + p.Height;

      if (f.ShowDialog() != DialogResult.OK) {
        return 1;
      }

      var start = mc.SelectionStart.ToShortDateString().Replace('/', '-');
      var end = mc.SelectionEnd.ToShortDateString().Replace('/', '-');

      Console.Out.WriteLine(start);
      if (start != end) {
        Console.Out.WriteLine(end);
      }

      return 0;
    }
  }
}