using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace fwfw
{
  /// <summary>
  /// Get options
  /// </summary>
  public static class Getopt
  {
    /// <summary>
    /// Do parse
    /// </summary>
    /// <param name="args">Command line argument</param>
    /// <param name="options">Result of options</param>
    /// <param name="arguments">Result of another args</param>
    public static void parse(string[] args,
      out Dictionary<string, string> options,
      out List<string> arguments)
    {
      options = new Dictionary<string, string>();
      arguments = new List<string>();
      if (args.Length > 0 && Regex.IsMatch(args[0], @"\.exe$", RegexOptions.IgnoreCase)) {
        var tmp = new List<string>(args);
        tmp.RemoveAt(0);
        args = tmp.ToArray();
      }
      foreach (string arg in args) {
        var maa = new Regex(@"^-(?<key>[a-zA-Z0-9])=(?<val>.*$)").Match(arg);
        if (maa.Success) {
          // Ex: -d=C:/Windows/Temp
          string key = maa.Groups["key"].Value;
          if (options.ContainsKey(key)) {
            options.Remove(key);
          }
          options.Add(key, maa.Groups["val"].Value);
        }
        else if (Regex.IsMatch(arg, @"^-[a-zA-Z0-9]+$")) {
          // Ex: -RIi, -R -I -i
          foreach (char c in arg.ToCharArray()) {
            string key = c.ToString();
            if (key != "-") {
              if (options.ContainsKey(key)) {
                options.Remove(key);
              }
              options.Add(key, null);
            }
          }
        }
        else if (Regex.IsMatch(arg, @"^--[a-zA-Z0-9\-]+$")) {
          // Ex: --no-retry
          string key = Regex.Replace(arg, @"^--", "");
          if (options.ContainsKey(key)) {
            options.Remove(key);
          }
          options.Add(key, null);
        }
        else {
          // Ex: --temp-directory=C:/Windows/Temp
          var ma = new Regex(@"^--(?<key>[a-zA-Z0-9\-]+)=(?<val>.*)$").Match(arg);
          if (ma.Success) {
            string key = ma.Groups["key"].Value;
            if (options.ContainsKey(key)) {
              options.Remove(key);
            }
            options.Add(key, ma.Groups["val"].Value);
          }
          else {
            // other
            arguments.Add(arg);
          }
        }
      }
      return;
    }
  }
}
