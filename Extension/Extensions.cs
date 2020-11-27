using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Softbery.Core.Configuration.Extension
{
    public static class Extensions
    {
        public static string RemoveWhiteSpace(this string text)
        {
            var lines = text.Split('\n');
            return string.Join("\n", lines.Select(str => str.Trim()));
        }
    }
}
