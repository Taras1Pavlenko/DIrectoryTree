using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace DIrectoryTree
{
    class DirectoryProccesing
    {
        private StringBuilder tab = new StringBuilder();
        private string pathToWriting;
        private string pathForArchive;
        private StringBuilder output = new StringBuilder();

        public void GetStart()
        {
            SetPath();
            GetUser();
            WorkWithDirectory(GetPath(), true);
            WriteToFile();
            CreateArchive();
        }

        public void GetUser()
        {
            output.Append(Environment.UserName + ":\n");
        }

        public string GetPath()
        {
            string pathForScanning = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return pathForScanning;
        }

        public void SetPath()
        {
            pathToWriting = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Pavlenko.txt";
            pathForArchive = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Pavlenko.zip";
        }

        public void CreateArchive()
        {
            using (FileStream fileStream = File.Open(pathToWriting, FileMode.Open))
            {
                using (FileStream compressedFile = File.Create(pathForArchive))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFile, CompressionMode.Compress))
                    {
                        fileStream.CopyTo(compressionStream);
                    }
                }
            }
            File.Delete(pathToWriting);
        }

        public void WorkWithDirectory(string pathForScanning, bool flag)
        {
            try
            {
                if (Directory.Exists(pathForScanning))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(pathForScanning);
                    DirectoryInfo[] directories = directoryInfo.GetDirectories();
                    FileInfo[] files = directoryInfo.GetFiles();

                    foreach (var dir in directories)
                    {
                        Indent(true);
                        output.Append(tab + dir.Name + ":\n");
                        WorkWithDirectory(dir.FullName, true);
                        Indent(false);
                    }
                    foreach (var file in files)
                    {
                        Indent(true);
                        output.Append(tab + "-" + file + "\n");
                        Indent(false);
                    }
                }
                else
                {
                    output.Append("The path is not exist");
                }
            }
            catch (Exception e)
            {
            }
        }

        public void Indent(bool flag)
        {
            var app = "    ";
            if (flag)
            {
                tab.Append(app);
            }
            else
            {
                tab.Remove(0, app.Length);
            }
        }

        public void WriteToFile()
        {
            using (StreamWriter streamWriter = new StreamWriter(pathToWriting))
            {
                streamWriter.Write(output);
            }
        }

    }
}
