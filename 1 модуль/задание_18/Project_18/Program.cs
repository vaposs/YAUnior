using System;

namespace Project_18
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int minNumber = 1;
            int maxNumber = 28;
            Random number = new Random();
            int countNumber = 0;
            int minDigit = 0;
            int lowerBound = 99;
            int maxDiget = 999;

            int randomNumber = number.Next(minNumber, maxNumber);

            for (int i = minDigit; i <= maxDiget; i = i + randomNumber)
            {
                if(i > lowerBound)
                {
                    countNumber++;
                }
            }

            Console.WriteLine($"{countNumber} - столько трехзначных натуральных чисел кратно числу - {randNumber}");
            Console.ReadLine();
        }
    }
}
