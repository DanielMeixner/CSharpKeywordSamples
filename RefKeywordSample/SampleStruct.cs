using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefKeywordSample
{
    public struct SampleStruct
    {
        public int myInt;

        public void Print()
        {
            Console.WriteLine($"Outside: This instance of SampleStruct has {nameof(myInt)} value {myInt}.");
        }
    }
}
