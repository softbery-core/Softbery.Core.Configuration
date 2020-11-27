using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Softbery.Core.Configuration.Items
{
    public class Comment
    {
        private string[] commentsCharDefault = new string[] { ";", "#" };
        private static string newLine = "\n";
        public string[] CommentsChar { 
            get { return commentsCharDefault; } 
            set { commentsCharDefault = value; } 
        }
        public string NewLine = newLine;
        
        public Comment()
        {

        }

        public IEnumerable<string> RemoveComments(string config_string)
        {
            IEnumerable<string> txtLines = config_string.Split(NewLine);
            foreach (var item in CommentsChar)
            {
                txtLines = txtLines.Where(line => !line.StartsWith(item));
            }
            
            return txtLines;
        }

        public string ConfigWhitoutComments(string config_string)
        {
            return string.Join(NewLine, RemoveComments(config_string));
        }
    }
}
