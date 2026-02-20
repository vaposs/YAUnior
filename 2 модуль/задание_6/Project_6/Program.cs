using System;

namespace Project_6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int startingPoint = 0;
            int previousNumber = 1;
            int temporaryVariable = 0;
            int arraySize = 10;
            int randomMax = 100;
            Random random = new Random();
            int[] numbers = new int[arraySize];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(randomMax);
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[i - previousNumber])
                {
                    temporaryVariable = numbers[i];
                    numbers[i] = numbers[i - previousNumber];
                    numbers[i - previousNumber] = temporaryVariable;
                    i = startingPoint;
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + ",");
            }
        }
    }
}
