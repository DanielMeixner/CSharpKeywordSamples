using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutKeywordSample
{
    class Program
    {
        /// <summary>
        /// // This class doesn't compile. That's on purpose. Read the comments why.
        /// </summary>
        /// <param name="args"></param>
        public void Main(string[] args)
        {
            // When using ref you have to assign a value to the variable used as out parameter
            // The next two lines won't compile.
            SampleClass refSampleClass1;
            RefMethod(ref refSampleClass1);

            // This does work
            SampleClass refSampleClass2 = null;
            RefMethod(ref refSampleClass2);

            // When using OUT you can work with non assigned variables
            SampleClass outSampleClass1;
            OutMethod_AccessBeforeAssign(out outSampleClass1);

            // When using OUT you can work with assigned variables as well
            SampleClass outSampleClass2 = new SampleClass();
            OutMethod_AccessBeforeAssign(out outSampleClass2);

        }


        /// <summary>
        /// This method would't compile because sample has no value assigned before leaving. 
        /// </summary>
        /// <param name="sample"></param>
        public void OutMethod(out SampleClass sample)
        {
            // no value assigned
        }

        /// <summary>
        /// This method doesn't compile because I access sample before I assign a value
        /// </summary>
        /// <param name="sample"></param>
        public void OutMethod_AccessBeforeAssign (out SampleClass sample)
        {
            // access value
            int i = sample.myValue;

            // assignment
            sample = new SampleClass();
        }


        public void RefMethod (ref SampleClass sample)
        {
            // I can access sample here because I use ref instead of out
            int i = sample.myValue;
        }

    }
}
