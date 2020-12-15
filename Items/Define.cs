using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Softbery.Core.Configuration.Items
{
    public class Define
    {
        public Dictionary<string, string> Veriables(string config_string)
        {
            /*Comment comment = new Comment();
            //IEnumerable<string> txtLines = comment.RemoveComments(config_string);
            
            Dictionary<string, string> variables = txtLines.Where(line => line.StartsWith(@"#define"))
                                                           .Select(line => Regex.Match(line, @"#define ([^ ]*) (.*)"))
                                                           .ToDictionary(match => match.Groups[1].Value, match => match.Groups[2].Value);
            return variables;*/
            return null;
        }
    }
}
