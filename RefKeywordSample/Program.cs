using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefKeywordSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Environment.NewLine}CASE:Modify Value of ValueType");
            SampleStruct myValTypeSample1 = CreateNewSampleStruct(); // myRefTypeSample1.myInt is 42;
            ValueType_ModifyValue(myValTypeSample1); // value is modified to 13
            Console.WriteLine($"Outside: The instance of SampleStruct has value {myValTypeSample1.myInt}."); // myValTypeSample1.myInt will be 42

            Console.WriteLine($"{Environment.NewLine}CASE: Modify Value of ReferenceType");
            SampleClass myRefTypeSample1 = CreateNewSampleClass();  // myRefTypeSample1.myInt is 42;
            RefType_ModifyValue(myRefTypeSample1); // value is modified to 13
            Console.WriteLine($"Outside: The instance of SampleClass has value {myRefTypeSample1.myInt}."); // myRefTypeSample1.myInt will 13


            Console.WriteLine(Environment.NewLine);

            // create new instances 
            Console.WriteLine($"{Environment.NewLine}CASE:Change Instance of ValueType");
            SampleStruct myValTypeSample2 = CreateNewSampleStruct(); // myValTypeSample2.myInt is 42
            ValueType_CreateNewInstance(myValTypeSample2); // new instance created & assigned, myInt set to 13
            Console.WriteLine($"Outside: The instance of SampleStruct has value {myValTypeSample2.myInt}."); // myValTypeSample2.myInt will be 42

            Console.WriteLine($"{Environment.NewLine}CASE:Change Instance of ReferenceType");
            SampleClass myRefTypeSample2 = CreateNewSampleClass(); // myRefTypeSample2.myInt is 42;
            RefType_CreateNewInstance(myRefTypeSample2); // new instance created & assigned, myInt set to 13
            Console.WriteLine($"Outside: The instance of SampleClass has value {myRefTypeSample2.myInt}."); // myRefTypeSample2.myInt will be 42

            Console.WriteLine(Environment.NewLine);

            // Modify values w REF
            Console.WriteLine($"{Environment.NewLine}CASE:Modify Value of ReferenceType with REF");
            SampleClass myRefTypeSample3 = CreateNewSampleClass(); // myRefTypeSample3.myInt = 42;
            RefType_WithRef_ModifyValue(ref myRefTypeSample3);  // value is modified to 13 with REF
            Console.WriteLine($"Outside: The instance of SampleClass has value {myRefTypeSample3.myInt}."); // myRefTypeSample1.myInt will be 13

            Console.WriteLine($"{Environment.NewLine}CASE:Modify Value of ValueType with REF");
            SampleStruct myValTypeSample3 = CreateNewSampleStruct(); // myValTypeSample3.myInt = 42
            ValueType_WithRef__ModifyValue(ref myValTypeSample3); // value is modified to 13 with REF
            Console.WriteLine($"Outside: The instance of SampleStruct has value {myValTypeSample3.myInt}."); // myValTypeSample3.myInt will be 13

            Console.WriteLine(Environment.NewLine);

            // create new instances w REF
            Console.WriteLine($"{Environment.NewLine}CASE:Change Instance of ReferenceType with REF");
            SampleClass myRefTypeSample4 = CreateNewSampleClass(); //myRefTypeSample4.myInt = 42;
            RefType_WithRef_CreateNewInstance(ref myRefTypeSample4); // new instance is created & assigned with myInt = 13
            Console.WriteLine($"Outside: The instance of SampleClass has value {myRefTypeSample4.myInt}."); // myRefTypeSample4.myInt will be 13

            Console.WriteLine($"{Environment.NewLine}CASE:Change Instance of ValueType with REF");
            SampleStruct myValTypeSample4 = CreateNewSampleStruct(); // myValTypeSample4.myInt = 42;
            ValueType_WithRef_CreateNewInstance(ref myValTypeSample4); // new instance is created & assigned with myInt = 13
            Console.WriteLine($"Outside: The instance of SampleStruct has value {myValTypeSample4.myInt}."); // {myValTypeSample4.myInt will be 13

            Console.ReadLine();
        }

        private static SampleStruct CreateNewSampleStruct()
        {            
            SampleStruct myValTypeSample = new SampleStruct();
            myValTypeSample.myInt = 42;
            Console.WriteLine($"Created new Struct with inital value of {myValTypeSample.myInt}");
            return myValTypeSample;
        }

        private static SampleClass CreateNewSampleClass()
        {
            SampleClass myRefTypeSample = new SampleClass();
            myRefTypeSample.myInt = 42;
            Console.WriteLine($"Created new Class with inital value of {myRefTypeSample.myInt}");
            return myRefTypeSample;
        }

        private static void ValueType_WithRef_CreateNewInstance(ref SampleStruct sample)
        {
            Console.WriteLine("Inside: Set parameter to a new struct (value type) with int value 13.");
            sample = new SampleStruct();
            sample.myInt = 13;
            Console.WriteLine($"Inside: Value of SampleStruct.myInt is {sample.myInt}");
        }

        private static void RefType_WithRef_CreateNewInstance(ref SampleClass sample)
        {
            Console.WriteLine("Inside: Set parameter to a new class (reference type) with int value 13.");
            sample = new SampleClass();
            sample.myInt = 13;
            Console.WriteLine($"Inside: Value of SampleClass.myInt is {sample.myInt}");
        }

        private static void ValueType_CreateNewInstance(SampleStruct sample)
        {
            sample = new SampleStruct();
            sample.myInt = 13;
            Console.WriteLine($"Inside: Created a new instance of SampleStruct. Value of SampleStruct.myInt is set to {sample.myInt}");
        }

        private static void RefType_CreateNewInstance(SampleClass sample)
        {           
            sample = new SampleClass();
            sample.myInt = 13;
            Console.WriteLine($"Inside: Created a new instance of SampleClass. SampleClass.myInt is set to {sample.myInt}");
        }

        private static void ValueType_WithRef__ModifyValue(ref SampleStruct sample)
        {
            sample.myInt = 13;
            Console.WriteLine($"Inside: Change myInt to {sample.myInt}");
        }

        private static void RefType_WithRef_ModifyValue(ref SampleClass sample)
        {
            sample.myInt = 13;
            Console.WriteLine($"Inside: Change myInt to {sample.myInt}");
        }

        private static void ValueType_ModifyValue(SampleStruct sample)
        {
            sample.myInt = 13;
            Console.WriteLine($"Inside: Change myInt to {sample.myInt}");
        }     

        private static void RefType_ModifyValue(SampleClass sample)
        {
            sample.myInt = 13;
            Console.WriteLine($"Inside: Change myInt to {sample.myInt}");
        }
    }
}
