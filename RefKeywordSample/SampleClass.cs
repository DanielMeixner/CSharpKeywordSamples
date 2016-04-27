using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefKeywordSample
{
    public class SampleClass
    {
        public int myInt;

        public void Print()
        {
            Console.WriteLine($"Outside: This instance of SampleClass has {nameof(myInt)} value {myInt}.");

        }
    }    
}
