using JKLog.Interface;
using System;
using System.IO;
using System.Collections.Generic;



namespace JKLog.Mapper
{
    [JKMapper]
    public class LogFile : IWritable, IConfigurable
    {
        private Dictionary<string, string> configuration;
        public Dictionary<string, string> Configuration
        {
            set
            {
                if (this.configuration == null)
                    this.configuration = value;
            }
            private get
            {
                if (this.configuration == null)
                    this.configuration = new Dictionary<string, string>();
                return this.configuration;
            }
        }
        


        private string fullPath;
        private string FullPath
        {
            get
            {
                if (this.fullPath == null)
                {
                    string path, filename, extension;
                    DateTime time = DateTime.Now;

                    // jos pathiä ei löydy, mutta formatPath löytyy
                    if (!this.Configuration.TryGetValue("path", out path) && this.Configuration.TryGetValue("formatPath", out path))
                        path = time.ToString(path);

                    // jos filenameä ei löydy, mutta formatFilename löytyy
                    if (!this.Configuration.TryGetValue("filename", out filename) && this.Configuration.TryGetValue("formatFilename", out filename))
                        filename = time.ToString(filename);

                    // haetaan extension
                    this.Configuration.TryGetValue("extension", out extension);

                    // defaultit
                    if (path == null) path = "JKLog";
                    if (filename == null) filename = "JKLog";
                    if (extension == null) extension = "log";

                    this.fullPath = Path.ChangeExtension(Path.Combine(path, filename), extension);
                }
                
                return this.fullPath;
            }
        }



        public void WriteEntry(IEntry entry)
        {
            Directory.CreateDirectory( Path.GetDirectoryName(this.FullPath) );
            
            using (StreamWriter file = new StreamWriter(this.FullPath, true))
            {
                file.WriteLine(string.Format(
                "{0} {1} {2}: {3} {4} in {5}:{6}:{7}",
                entry.Timestamp, entry.Type, entry.Category, entry.Message, entry.Context, entry.FilePath, entry.Caller, entry.LineNumber
                ));
            }
        }
    }
}
