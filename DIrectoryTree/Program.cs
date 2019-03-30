using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIrectoryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryProccesing directory = new DirectoryProccesing();
            directory.WriteToFile();

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
