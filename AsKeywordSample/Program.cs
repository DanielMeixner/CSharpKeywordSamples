using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsKeywordSample
{
    class Program
    {
        static void Main(string[] args)
        {
            object someObject = GetSomeObject();

            Console.WriteLine($"{Environment.NewLine}Test 1: Valid classic cast with ()");
            // casting the classic way if you 're sure what you expect. We added try/catch to be safe. You never know.
            try
            {
                // Cast will work here
                MyParentClass parent1 = (MyParentClass)someObject;
                Console.WriteLine($"Great, the cast from 'object' to 'MyParentClass' cast did work.");
            }
            catch (InvalidCastException e)
            {
                // we won't get here
                Console.WriteLine($"Ooops. Exception! That's an invalid cast, dude.{Environment.NewLine + e.Message}");
            }

            Console.WriteLine($"{Environment.NewLine}Test 2: Invalid classic cast with ()");
            // invalid cast done in the classic way. Thank god we have that try/catch thing.
            try
            {
                // cast incompatible types
                MyOtherClass other = (MyOtherClass)someObject;

                // we won't see this line
                Console.WriteLine($"Great, the cast from 'object' to 'MyOtherClass' cast did work.");
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine($"Ooops. Exception! That's an invalid cast, dude.[{e.Message}]");
            }

            Console.WriteLine($"{Environment.NewLine}Test 3: Valid cast with 'as'");
            // cast with "as" 
            MyParentClass parent2 = someObject as MyParentClass;
            // check if cast was successfull
            if(parent2!=null)
            {
                Console.WriteLine("Cast from object to MyParentClass did work.");                
            }
            

            Console.WriteLine($"{Environment.NewLine}Test 4: Invalid cast with 'as'");
            // invalid cast with "as"
            MyOtherClass other1 = someObject as MyOtherClass;            
            // check if cast was UNsuccessfull (mind the == instead of the !=)
            if(other1 == null)
            {
                // This line will be printed.
                Console.WriteLine("Something went wrong. Seems like 'someObject' is not of type 'MyOtherClass'. "+
                    "However this isn't such a big deal. No Exception here. And we checked for null. Peeew.");
            }

            

            Console.ReadLine();
        }

        private static object GetSomeObject()
        {
            return new MyChildClass();
        }
    }
}
