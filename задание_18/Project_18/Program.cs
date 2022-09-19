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
            int minThreeDigit = 100;
            int maxThreeDiget = 999;
            int randNumber = number.Next(minNumber, maxNumber);

            for(int i = minThreeDigit; i <= maxThreeDiget; i ++)
            {
                int count = i;
                bool isNext = true;

                while(isNext)
                {   
                    if(count == 0)
                    {
                        countNumber++;
                    }
                    else if(count < 0)
                    {
                        isNext = false;
                    }
                    count -= randNumber;
                }
            }
            Console.WriteLine($"{countNumber} - столько трехзначных натуральных чисел кратно числу - {randNumber}");
            Console.ReadLine();
        }
    }
}
