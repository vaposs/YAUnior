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
            int randNumber = number.Next(minNumber, maxNumber);

            for(int i = 100; i <= 999; i ++)
            {
                int count = i;
                while(true)
                {   
                    if(count == 0)
                    {
                        Console.WriteLine(i);
                        countNumber++;
                        break;
                    }
                    else if(count < 0)
                    {
                        break;
                    }
                    count -= randNumber;
                }
            }
            Console.WriteLine($"{countNumber} - столько трехзначных натуральных чисел кратно числу - {randNumber}");
            Console.ReadLine();
        }
    }
}
