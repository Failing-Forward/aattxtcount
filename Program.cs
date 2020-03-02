using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System;

namespace aattxtcount
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            string text = File.ReadAllText(args[0]);
            Regex regex = new Regex(@"[а-яА-Я][.,~`!'@#№$;%:^?&*()-+\\/]");
            MatchCollection matches = regex.Matches(text);
            List<string> Variants = new List<string>();
            string dist = "";

            if (matches.Count > 0)
            {
                foreach(Match match in matches)
                {
                    if (!Variants.Contains(match.Value)) {
                        Variants.Add(match.Value);
                        dist += match.Value + Environment.NewLine;
                    }
                }
                File.WriteAllText(Path.GetFileNameWithoutExtension(args[0]) + "_list.txt", dist.Substring(0, dist.Length - 2));
            } else {
                Console.WriteLine("Not found.");
            }
        }
    }
}
