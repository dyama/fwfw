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
    public static int notice(OptsType opts, ArgsType args)
    {
      NotifyIcon n = new NotifyIcon();

      ToolTipIcon icon = ToolTipIcon.None;
      if (opts.ContainsKey("icon")) {
        switch (opts["icon"].ToLower()) {
        case "info":
          icon = ToolTipIcon.Info;
          break;
        case "error":
          icon = ToolTipIcon.Error;
          break;
        case "warning":
          icon = ToolTipIcon.Warning;
          break;
        default:
          icon = ToolTipIcon.None;
          break;
        }
      }
      n.BalloonTipIcon = icon;

      if (opts.ContainsKey("title")) {
        n.BalloonTipTitle = opts["title"];
      }

      int ms = 1000;
      if (opts.ContainsKey("time")) {
        int val;
        if (int.TryParse(opts["time"], out val)) {
          ms = val;
        }
      }

      n.BalloonTipText = string.Join("\n", args.ToArray());

      n.Visible = true;
      n.ShowBalloonTip(ms);

      return 0;
    }
  }
}