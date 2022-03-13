using System;

namespace Projeсt_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var unknownType = 2356;
            int integerNumber = -347842;
            long veryBigNumber = 1234567891234567890;
            uint positiveNumber = 723654;
            float fractionalNumber = 0.1f;
            double oneMoreFractionalNumber = 0.001;
            bool stateTrue = true;
            bool stateFalse = false;
            char symbol = 'a';
            string line = "I to be coder!";
            object anObjectInt = 5;
            object anObjectFloat = 0.3f;
            object anObjectString = "строчка";

            Console.WriteLine(unknownType);
            Console.WriteLine(integerNumber);
            Console.WriteLine(veryBigNumber);
            Console.WriteLine(positiveNumber);
            Console.WriteLine(fractionalNumber);
            Console.WriteLine(oneMoreFractionalNumber);
            Console.WriteLine(stateTrue);
            Console.WriteLine(stateFalse);
            Console.WriteLine(symbol);
            Console.WriteLine(line);
            Console.WriteLine(anObjectInt);
            Console.WriteLine(anObjectFloat);
            Console.WriteLine(anObjectString);
        }
    }
}
