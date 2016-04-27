using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeywordSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read json file (you can view the content in the project folder)
            // make sure 'Copy to Output Directory' is set to 'Copy Always'
            string json = File.ReadAllText($@" {AppDomain.CurrentDomain.BaseDirectory}\json1.json");
            
            // create a dyamic object
            dynamic obi = JsonConvert.DeserializeObject<object>(json);

            // This will work
            Console.WriteLine(obi.resourceSets[0].resources[0].travelDistance.Value);
            
            try
            {
                // This won't work, but Intellisense won't complain
                var nope = obi.some.other.property.which.doesnt.exist;
            }
            catch (RuntimeBinderException e)
            {
                // we're expecting to run into this exception
                Console.WriteLine($"Sorry, this didn't work. {e.Message} ");
            }            
            Console.ReadLine();
        }      
    }
}
