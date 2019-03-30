using System;
using System.IO;
using System.Text;

namespace DIrectoryTree
{
    class DirectoryProccesing
    {
        private StringBuilder tab = new StringBuilder();
        private string pathToWriting;
        private StringBuilder output = new StringBuilder();

        public DirectoryProccesing()
        {
            SetPath();
            GetUser();
            WorkWithDirectory(GetPath(), true);
        }

        public void GetUser()
        {
             output.Append(Environment.UserName+":\n");
        }
        public string GetPath()
        {
            string pathForScanning = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //string pathForScanning = @"C:\Users\Taras\Desktop\Tree";
            return pathForScanning;
        }
        public void SetPath()
        {
            pathToWriting = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\DirectoryTree.txt";
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
                        //Console.WriteLine(tab + dir.Name + ":");
                        output.Append(tab + dir.Name + ":\n");
                        WorkWithDirectory(dir.FullName, true);
                        Indent(false);
                    }
                    foreach (var file in files)
                    {
                        Indent(true);
                        //Console.WriteLine(tab + "-" + file);
                        output.Append(tab + "-" + file + "\n");
                        Indent(false);
                    }
                }
                else
                {
                    //Console.WriteLine("The path is not exist");
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
            StreamWriter streamWriter = new StreamWriter(pathToWriting);
            streamWriter.Write(output);
            streamWriter.Close();
        }
    }
}