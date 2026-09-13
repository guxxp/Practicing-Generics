using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using example_with_Generics.Entities;

namespace example_with_Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintService <int> printService = new PrintService<int>();

            Console.WriteLine("How many values?");
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                printService.AddValue(x);
            }

            
            printService.Print();
            Console.WriteLine("First: " + printService.First());

            Console.ReadLine();
        }
    }
}
