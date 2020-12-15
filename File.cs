using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Softbery.Core.Configuration
{
    public class File
    {
        public static string Directory = AppDomain.CurrentDomain.BaseDirectory + @"config\";
        public static string Name = @"config.cfg";
        private string config;
        public string Config { get { return config; } set { config = value; } }

        public enum ReturnFileSteps
        {
            CreateDefault,

        }

        public File()
        {
            this.config = this.Open();
        }

        internal static object ReadAllText(string file)
        {
            
            throw new NotImplementedException();
        }

        public bool CheckFile(string file_path)
        {
            FileInfo fi = new FileInfo(file_path);
            if (fi.Exists)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }

        /// <summary>
        /// Open default config file
        /// </summary>
        /// <returns>string</returns>
        public string Open()
        {
            string log = "";
            string txt = "";
            try
            {
                log = "Open file " + Directory + Name+".";
                StreamReader sr = new StreamReader(Directory + Name);
                log = "Set file to string variable txt.";
                txt = sr.ReadToEnd();
                
                log = String.Format("Time:{0} Action:{1}",DateTime.Now,"Set file config to text variable.");
                this.config = txt;
            }
            catch (Exception)
            {
                
            }
            
            return txt;
        }

        public List<string> GetAllFileConfig(string folder_path, Configuration.ConfigTypes types)
        {
            string sp = types.ToString();
            IEnumerable<string> getfiles = GetAllFiles(folder_path, types.ToString()).ToList();
            switch (types)
            {
                case Configuration.ConfigTypes.cfg:
                    return GetAllFiles(folder_path, "*." + types.ToString()).ToList();
                case Configuration.ConfigTypes.xml:
                    return GetAllFiles(folder_path, "*." + types.ToString()).ToList();
                case Configuration.ConfigTypes.list:
                    return null;
                case Configuration.ConfigTypes.sql:
                    return null;
                case Configuration.ConfigTypes.ftp:
                    return null;
                case Configuration.ConfigTypes.http:
                    return null;
                default:
                    return GetAllFiles(folder_path, "*.cfg").ToList();
            }
        }

        private static IEnumerable<string> GetAllFiles(string folder_path, string searchPattern)
        {
            List<string> list = new List<string>();
            DirectoryInfo di = new DirectoryInfo(folder_path);
            var df = di.GetFiles(searchPattern);
            foreach (var item in df)
            {
                list.Add(item.FullName);
            }
            //string[] list = new string[di.GetFiles()] { };
            foreach (var fi in di.EnumerateFiles())
            {
                
            }
            //IEnumerable<string> numerable = (IEnumerable<string>)ie.AsEnumerable<string>();
            IEnumerable<string> result = list.AsEnumerable<string>();
            return result;
        }

    }
}
