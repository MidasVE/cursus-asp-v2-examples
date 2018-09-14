using System;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = "Hello World with a variable!"; // string
            Console.WriteLine(hello);

            var number1 = 1; // integer 
            var number2 = 2.0; // double
            var number3 = 2; // integer
            Console.WriteLine(number1 / number2);
            Console.WriteLine(number1 / number3);

            var booll = true; // boolean (true of false)

            Console.WriteLine(booll);

            bool? nullable = null; // nullable
            Console.WriteLine(nullable);
            nullable = true;
            Console.WriteLine(nullable);

            // nullable = 1; // werkt niet, is een int in een nullable bool!
        }
    }
}