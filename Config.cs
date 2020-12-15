using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Softbery.Core.Configuration
{
    public class Config
    {
        public string Section { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public Config()
        {
            
        }
    }
}
