using System;

namespace Project_18
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int lowerBound = 50;
            int upperBound = 150;
            int count = 0;

            int minValue = 10;
            int maxValue = 25;
            int randomNumber = random.Next(minValue, maxValue + 1);

            for (int i = randomNumber; i <= upperBound; i += randomNumber)
            {
                if (i >= lowerBound)
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество чисел от {lowerBound} до {upperBound}, кратных {randomNumber}: {count}");
        }
    }
}
