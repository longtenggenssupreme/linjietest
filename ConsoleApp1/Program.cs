using System;
using EFCOREDB;
namespace ConsoleStaticRenference
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"{EFCOREDB.Program.x}");            
            Console.Read();
        }        
    }
}
