
using System;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var check = true;
            if (check)
            {
                Console.WriteLine("Item 1");
            }
            else
            {
                Console.WriteLine("Item 2");
            }

            if (!check)
            {
                Console.WriteLine("Item 3");
            }
            else
            {
                Console.WriteLine("Item 4");
            }

            if (1 == 1 + 2)
            {
                Console.WriteLine("Item 5");
            }

            if (1 == 2 - 1)
            {
                Console.WriteLine("Item 6");
            }
        }
    }
}