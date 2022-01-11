using System;
using ClassLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
{
            CoffeeMachine coffee_machine = new();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Write action (buy, fill, take, remaining, exit):");
                Console.ForegroundColor = ConsoleColor.Red;
                coffee_machine.GoverningMethod(Console.ReadLine());
            }
        }
    }
}
