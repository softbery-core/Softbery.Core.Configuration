using System;
using System.Collections.Generic;
using System.Text;

namespace Softbery.Core.Configuration
{
    public class Configuration
    {
        public Dictionary<string, string> Variables { get; set; }
        public string Settings { get; set; }
        public Dictionary<string, Config> Sections { get; set; }

    }
}
