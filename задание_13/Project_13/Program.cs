using System;

namespace Project_13
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int minRandom = 1;
            int maxRandom = 100;
            Random random = new Random();
            int maxNumber = random.Next(minRandom,maxRandom);
            int summNumbers = 0;

            for(int i = 1; i <= maxNumber; i++)
            {
                if((i%3 == 0)||(i%5 == 0))
                {
                    summNumbers += i;
                }
            }
            Console.WriteLine($"Сумма всех натуральных числел от 1 до {maxNumber} которые кратны 3 или 5 равно - {summNumbers}");
        }
    }
}
