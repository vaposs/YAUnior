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

            int randomNumber = random.Next(10, 26);
            int tempNumber = randomNumber;

            while (tempNumber <= upperBound)
            {
                if (tempNumber >= lowerBound)
                {
                    count++;
                }
                tempNumber += randomNumber;
            }

            Console.WriteLine($"Количество чисел от {lowerBound} до {upperBound}, кратных {randomNumber}: {count}");
        }
    }
}
