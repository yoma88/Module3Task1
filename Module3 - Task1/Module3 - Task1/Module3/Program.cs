using System;
using System.IO;

namespace Module3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var visitor = new FileSystemVisitor(@"C:\Users\Yohana_Espinoza\Desktop\cv",
            path => Path.GetExtension(path) == ".doc"); // Change the directory path 

            foreach (var file in visitor.GetFiles())
            {
                Console.WriteLine(file);
            }

            Console.ReadKey();
        }
    }
}
