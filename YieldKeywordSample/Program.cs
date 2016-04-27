using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldKeywordSample
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            foreach (var item in MyFiboIterator())
            {
                if (count++ > 10)
                {
                    break;
                }
                Console.WriteLine(item);
            }
           
            Console.WriteLine(ComputeFibo(10));
        }

        /// <summary>
        /// computes the nth fibonacci number
        /// </summary>
        /// <param name="n">the index of the number to compute</param>
        /// <returns>the nth fibonacci number </returns>
        static int ComputeFibo(int n)
        {            
            if (n == 0 || n == 1)
                return 1;
            return ComputeFibo(n - 1) + ComputeFibo(n - 2);
        }

        /// <summary>
        /// Iterates over a bunch of Fibo Numbers
        /// </summary>
        /// <returns></returns>
        static IEnumerable<int> MyFiboIterator()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                yield return ComputeFibo(i);
            }
        }
    }
}
