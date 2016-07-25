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
    public static int password(OptsType opts, ArgsType args)
    {
      if (!opts.ContainsKey("password")) {
        opts.Add("password", null);
      }
      return input(opts, args);
    }
  }
}
