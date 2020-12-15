using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Softbery.Core.Configuration;

namespace Softbery.Core.Configuration
{
    public class Configuration
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);

        private static string _configPath = AppDomain.CurrentDomain.BaseDirectory + @"config\";
        private static string _cfgFile = @"config.cfg";
        
        private string _configFile;
        
        public static List<Config> Configs; 

        public enum ConfigTypes
        {
            cfg,
            xml,
            list,
            sql,
            ftp,
            http
        }

        /// <summary>
        /// Default configuration settings
        /// </summary>
        public Configuration()
        {
            Configs = new List<Config>();
            _configFile = _configPath + _cfgFile;
            Execute();
        }

        public Configuration(string file_path, Configuration.ConfigTypes types)
        {
            Configs = new List<Config>();
            _configFile = file_path;
            Execute();
        }

        public Configuration(List<Config> configs)
        {

        }

        public Configuration(string folder_path, FileAttributes attributes)
        {
            
        }

        private bool CheckMandatoryArguments()
        {
            return false;
        }

        public int Count()
        {
            return Configs.Count();
        }

        private bool Status()
        {
            bool[] result = new bool[] { };

            return false;
        }

        public List<string> ReadConfigSection(string iniFilePath, string sectionName)
        {
            _configFile = iniFilePath;
            List<string> result = new List<string>();
            byte[] buffer = new byte[4096];
            GetPrivateProfileSection(sectionName, buffer, 4096, iniFilePath);
            String[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');
            foreach (String entry in tmp)
            {
                string[] parts = entry.Split('=');
                if (parts.Length == 2)
                {
                    result.Add(parts[0]);
                }
            }
            return result;
        }
        public Dictionary<string, string> Reader(string Section)
        {
            
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in ReadConfigSection(_configFile,Section))
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, item, "", temp, 255, _configFile);
                string[] idic = temp.ToString().Split('#');
                dic.Add(item, idic[0]);
                Config config = new Config();
                config.Section = Section;
                config.Key = item;
                config.Value = idic[0];
                Configs.Add(config);
            }

            return dic;
        }

        public void Execute()
        {
            
        }

        public void Execute(string file_path)
        {

        }

        private void DefaultConfig()
        {

        }
    }
}
