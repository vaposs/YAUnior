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
            int tempNumber;


            int randomNumber = random.Next(10, 26);

            for (int i = lowerBound; i <= upperBound; i++)
            {
                tempNumber = i;

                while (tempNumber >= randomNumber)
                {
                    tempNumber -= randomNumber;
                }

                if (tempNumber == 0)
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество чисел от {lowerBound} до {upperBound}, кратных {randomNumber}: {count}");
        }
    }
}
