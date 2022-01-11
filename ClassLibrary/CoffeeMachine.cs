using System;
using System.Threading;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrary
{
    public class CoffeeMachine
    {
        private int money;
        private int water;
        private int milk;
        private int grams_coffee;
        private int cups;
        public CoffeeMachine(int money = 550, int water = 400, int milk = 540, int grams_coffee = 120, int cups = 9)
        {
            this.money = money;
            this.water = water;
            this.milk = milk;
            this.grams_coffee = grams_coffee;
            this.cups = cups;
        }
        public void GoverningMethod(string value)
        {
            switch (value)
            {
                case "buy":
                    Console.WriteLine("What do you want to buy? \n 1 - espresso \n 2 - latte \n 3 - cappuccino \n 4 - back to main menu");
                    int.TryParse(Console.ReadLine(), out int type_coffe);
                    BuyCoffe(type_coffe);
                    break;
                case "fill":
                    FillCoffeMachine();
                    break;
                case "take":
                    TakeMoney();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "remaining":
                    FillingCoffeMachine();
                    break;
                default:
                    Console.WriteLine("Unknown Action!");
                    Thread.Sleep(2500);
                    break;
            }
        }
        private void FillingCoffeMachine()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The coffee machine has:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {water} of water");
            Console.WriteLine($" {milk} of milk");
            Console.WriteLine($" {grams_coffee} of coffee beans");
            Console.WriteLine($" {cups} of disposable cups");
            Console.WriteLine($" {money} of money");
            Console.WriteLine("Press Any Key!");
            Console.ReadKey();
        }
        private void MakingCoffee()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Starting to make a coffee");
            Thread.Sleep(1000);
            Console.WriteLine("Grinding coffee beans");
            Thread.Sleep(1000);
            Console.WriteLine("Boiling water");
            Thread.Sleep(2000);
            Console.WriteLine("Mixing boiled water with crushed coffee beans");
            Thread.Sleep(2000);
            Console.WriteLine("Pouring coffee into the cup");
            Thread.Sleep(2000);
            Console.WriteLine("Pouring some milk into the cup");
            Thread.Sleep(2000);
            Console.WriteLine("Coffee is ready!");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Red;
        }
        private string MissingIngredient()
        {
            if (water < 200)
                return "water";
            else if (cups < 0)
                return "disposable cups";
            else if (grams_coffee < 12)
                return "coffee beans";
            else if (milk < 75)
                return "milk";
            else
                return "";
        }
        private void BuyCoffe(int type_coffe)
        {
            if (type_coffe == 1 && water >= 250 && grams_coffee >= 16 && cups > 0)
                ChangeTheData(250, 16, 4);
            else if (type_coffe == 2 && water >= 350 && milk >= 75 && grams_coffee >= 20 && cups > 0)
                ChangeTheData(350, 20, 7, 75);            
            else if (type_coffe == 3 && water >= 200 && milk >= 100 && grams_coffee >= 12 && cups > 0)
                ChangeTheData(200, 12, 6, 100);
            else if (type_coffe == 4)
                return;
            else
            {
                if (MissingIngredient() == "")
                    Console.WriteLine($"Incorrect choice!");
                else
                    Console.WriteLine($"Sorry, not enough {MissingIngredient()}!");
                Thread.Sleep(2500);
            }

        }
        private void ChangeTheData(int water, int grams_coffee, int money, int milk = 0)
        {
            this.water -= water;
            this.grams_coffee -= grams_coffee;
            this.milk -= milk;
            this.cups -= 1;
            this.money += money;
            MakingCoffee();
        }
        private void TakeMoney()
        {
            Console.Write("Enter password: ");
            Console.ForegroundColor = ConsoleColor.Black;
            if (MD5Hash(Console.ReadLine()) == "827ccb0eea8a706c4c34a16891f84e7b") //PASSWORD - 12345
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"I gave you {money}");
                money = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(2500);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid password!");
                Thread.Sleep(2500);
            }
        }       
        private void FillCoffeMachine()
        {
            Console.Write("Enter password: ");
            Console.ForegroundColor = ConsoleColor.Black;
            if (MD5Hash(Console.ReadLine()) == "21232f297a57a5a743894a0e4a801fc3") //PASSWORD - admin
            {
                Console.ForegroundColor = ConsoleColor.Red;
                try
                {
                    Console.WriteLine("Write how many ml of water you want to add:");
                    water += Math.Abs(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Write how many ml of milk you want to add:");
                    milk += Math.Abs(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Write how many grams of coffee beans you want to add:");
                    grams_coffee += Math.Abs(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Write how many disposable coffee cups you want to add:");
                    cups += Math.Abs(int.Parse(Console.ReadLine()));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ingredients added successfully!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(2000);
                }
                catch
                {
                    Console.WriteLine("Incorrect input of ingredients!");
                    Thread.Sleep(2500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid password!");
                Thread.Sleep(2500);
            }
        }
        private static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new
            MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new
            UTF8Encoding().GetBytes(input));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
