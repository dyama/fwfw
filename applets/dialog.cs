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
    public static int dialog(OptsType opts, ArgsType args)
    {
      MessageBoxButtons buttons = MessageBoxButtons.OK;
      if (opts.ContainsKey("type")) {
        switch (opts["type"].ToLower()) {
        case "abortretryignore":
          buttons = MessageBoxButtons.AbortRetryIgnore;
          break;
        case "ok":
          buttons = MessageBoxButtons.OK;
          break;
        case "okcancel":
          buttons = MessageBoxButtons.OKCancel;
          break;
        case "retrycancel":
          buttons = MessageBoxButtons.RetryCancel;
          break;
        case "yesno":
          buttons = MessageBoxButtons.YesNo;
          break;
        case "yesnocancel":
          buttons = MessageBoxButtons.YesNoCancel;
          break;
        default:
          buttons = MessageBoxButtons.OK;
          break;
        }
      }

      MessageBoxIcon icon = MessageBoxIcon.None;
      if (opts.ContainsKey("icon")) {
        switch (opts["icon"].ToLower()) {
        case "asterisk":
          icon = MessageBoxIcon.Asterisk;
          break;
        case "error":
          icon = MessageBoxIcon.Error;
          break;
        case "exclamation":
          icon = MessageBoxIcon.Exclamation;
          break;
        case "hand":
          icon = MessageBoxIcon.Hand;
          break;
        case "information":
          icon = MessageBoxIcon.Information;
          break;
        case "none":
          icon = MessageBoxIcon.None;
          break;
        case "question":
          icon = MessageBoxIcon.Question;
          break;
        case "stop":
          icon = MessageBoxIcon.Stop;
          break;
        case "warning":
          icon = MessageBoxIcon.Warning;
          break;
        default:
          icon = MessageBoxIcon.None;
          break; 
        }
      }

      string caption = "";
      if (opts.ContainsKey("caption")) {
        caption = opts["caption"];
      }

      string text = "";
      text = string.Join("\n", args);

      DialogResult result = DialogResult.None;

      MessageBoxDefaultButton default_button = MessageBoxDefaultButton.Button1;
      if (opts.ContainsKey("default")) {
        switch (opts["default"].ToLower()) {
        case "1":
          default_button = MessageBoxDefaultButton.Button1;
          break;
        case "2":
          default_button = MessageBoxDefaultButton.Button2;
          break;
        case "3":
          default_button = MessageBoxDefaultButton.Button3;
          break;
        default:
          default_button = MessageBoxDefaultButton.Button1;
          break;
        }
        result = MessageBox.Show(text, caption, buttons, icon, default_button);
      }
      else {
        result = MessageBox.Show(text, caption, buttons, icon);
      }

      Console.Out.WriteLine(result.ToString().ToLower());

      return 0;
    }


  }
}
