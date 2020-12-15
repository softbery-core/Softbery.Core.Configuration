using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Softbery.Core.Configuration.Items
{
    class Comment
    {
        public Comment()
        {
            
        }

        public string ConfigWhitoutComments(string config_string)
        {
            config_string = RemoveComments(config_string);

            return config_string;
        }

        private string RemoveComments(string config_string)
        {
            string pattern = @"(.*)(\#.*)";
            //Match match = Regex.Match(config_string, pattern);
            try
            {
                config_string = Regex.Replace(config_string, pattern, "");
                return config_string;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
