using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OptsType = System.Collections.Generic.Dictionary<System.String, System.String>;
using ArgsType = System.Collections.Generic.List<System.String>;

namespace fwfw
{
  static partial class Applet
  {
    public static int test(OptsType opts, ArgsType args)
    {
      foreach (var a in args) {
        Console.WriteLine(a);
      }
      return 0;
    }
  }
}
