using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Softbery.Core.Configuration
{
    public class File
    {
        public static string Directory = AppDomain.CurrentDomain.BaseDirectory + @"config\";
        public static string Name = @"config.cfg";
        private string config;
        public string Config { get { return config; } set { config = value; } }

        public File()
        {
            this.config = this.Open();
        }
        /// <summary>
        /// Open default config file
        /// </summary>
        /// <returns>string</returns>
        public string Open()
        {
            string txt = "";
            StringReader stringReader;

            try
            {
                stringReader = new StringReader(Directory + Name);
                while (stringReader.ReadLine()!=null)
                {
                    txt += stringReader.ReadLine();
                }

            }
            catch (Exception)
            {

                throw;
            }
            
            this.config = txt;
            //txt = stringReader.ReadToEnd();
            return txt;
        }

    }
}
