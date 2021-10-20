using System.Collections.Generic;

namespace ConsoleUtils.Management
{
    public static class ArgumentsParser
    {
        public static Dictionary<string, string> Parse(string[] args)
        {
            Dictionary<string, string> parsed = new Dictionary<string, string>();
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if (arg.StartsWith("--"))
                {
                    string value = i == args.Length - 1 ? null : (args[i + 1].StartsWith("-") ? null : args[i+=1]);
                    parsed.Add(arg, value);
                    continue;
                }

                if (arg.StartsWith("-"))
                    parsed.Add(arg, null);
            }

            return parsed;
        }
    }
}
