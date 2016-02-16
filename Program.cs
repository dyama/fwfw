using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;  

using OptsType = System.Collections.Generic.Dictionary<System.String, System.String>;
using ArgsType = System.Collections.Generic.List<System.String>;

namespace fwfw
{
  class Program
  {
    [STAThread]
    static int Main(string[] args)
    {
      int exitcode = 0;
      init();
      if (args.Length > 0) {
        var ar = args.ToList();
        var apname = ar.First();
        ar.RemoveAt(0);
        if (applets.ContainsKey(apname)) {
          OptsType o;
          ArgsType a;
          Getopt.parse(ar.ToArray(), out o, out a);
          exitcode = applets[apname](o, a);
        }
        else {
          Console.Error.WriteLineAsync("No such applet: " + apname);
          exitcode = -1;
        }
      }
      else {
        usage();
      }
#if DEBUG
      Console.Write("?");
      Console.Read();
#endif
      return exitcode;
    }

    delegate int applet_method(OptsType opts, ArgsType args);
    static Dictionary<string, applet_method> applets;

    static void init()
    {
      applets = new Dictionary<string, applet_method>();
      foreach (MemberInfo m in typeof(Applet).GetMembers(BindingFlags.Static | BindingFlags.Public)) {
        var del = System.Delegate.CreateDelegate(typeof(applet_method), m as MethodInfo);
        applets.Add(m.Name, del as applet_method);
      }
      return;
    }

    static void usage()
    {
      Console.Out.WriteLineAsync("Usage:");
      return;
    }

  }
}
