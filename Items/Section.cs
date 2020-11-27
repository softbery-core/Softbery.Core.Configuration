using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Softbery.Core.Configuration.Items
{
    public class Section
    {
        public Dictionary<string, string> GetSections(string config_string)
        {
            Dictionary<string, string> sections = Regex.Matches(new Comment().ConfigWhitoutComments(config_string), @"\[([\w]*)\]\n[^\[^\#]*)")
                                                       .Cast<Match>()
                                                       .ToDictionary(match => match.Groups[1].Value, match => match.Groups[2].Value);
            return sections;

        }
    }
}
