using System;

namespace DIrectoryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryProccesing directory = new DirectoryProccesing();
            directory.GetStart();

            Console.WriteLine("Process is done!");
            Console.ReadKey();
        }
    }
}
