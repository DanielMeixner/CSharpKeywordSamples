using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckedKeywordSample
{
    class Program
    {
        private static int aInt;
        private static int bInt;

        static void Main(string[] args)
        {
            Console.WriteLine("Add two numbers. Try to add something to 2147483647 (Int.MaxValue) to find why to use 'checked'.");
            AddTwoNumbers();
        }

        private static void AddTwoNumbers()
        {
            // ask for first int
            AskForInt(out aInt);

            // ask for second int
            AskForInt(out bInt);

            // won't throw an exception but might show wrong result
            Console.WriteLine($"Non-checked result is {(aInt + bInt)}.");

            // might throw overflow exception
            try
            {
                Console.WriteLine($"Checked result is {checked(aInt + bInt)}.");
            }
            catch(OverflowException e)
            {
                Console.WriteLine($"Sorry, checked result can't be provided. {e.Message}");
            }

            // start over
            AddTwoNumbers();
            return;
        }

        private static void AskForInt(out int i)
        {
            Console.WriteLine("Provide INT value.");
            string a = Console.ReadLine();
            if (!int.TryParse(a, out i))
            {
                AddTwoNumbers();
            }
        }
    }
}
