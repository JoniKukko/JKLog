using JKLog.Configuration;
using JKLog.Interface;
using System;
using System.IO;



namespace JKLog.Mapper
{
    class LogFile : IWritable
    {
        private static string staticPath = ConfigurationManager.GetValue(typeof(LogFile), "path");
        private static string staticFormatPath = ConfigurationManager.GetValue(typeof(LogFile), "formatPath");

        private static string staticFilename = ConfigurationManager.GetValue(typeof(LogFile), "filename");
        private static string staticFormatFilename = ConfigurationManager.GetValue(typeof(LogFile), "formatFilename");

        private static string staticExtension = ConfigurationManager.GetValue(typeof(LogFile), "extension");
        
        private string FullPath
        {
            get
            {
                string path = "JKLog";
                string filename = "JKLog";
                string extension = (staticExtension != null) ? staticExtension : "log";
                DateTime now = DateTime.Now;

                if (staticPath != null)
                    path = staticPath;
                else if (staticFormatPath != null)
                    path = now.ToString(staticFormatPath);

                if (staticFilename != null)
                    filename = staticFilename;
                else if (staticFormatFilename != null)
                    filename = now.ToString(staticFormatFilename);

                return Path.ChangeExtension(Path.Combine(path, filename), extension);
            }
        }



        public void WriteEntry(IEntry entry)
        {
            string fullPath = FullPath;
            string dir = Path.GetDirectoryName(fullPath);

            if (!String.IsNullOrWhiteSpace(dir))
                Directory.CreateDirectory(dir);
            
            using (StreamWriter file = new StreamWriter(fullPath, true))
            {
                file.WriteLine(string.Format(
                "{0} {1} {2}: {3} {4} in {5}:{6}:{7}",
                entry.Timestamp, entry.Type, entry.Category, entry.Message, entry.Context, entry.FilePath, entry.Caller, entry.LineNumber
                ));
            }
        }
    }
}
