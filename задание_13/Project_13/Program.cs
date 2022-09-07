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
            int multepleThree = 3;
            int multepleFive = 5;

            for (int i = 1; i <= maxNumber; i++)
            {
                if((i%multepleThree == 0)||(i%multepleFive == 0))
                {
                    summNumbers += i;
                }
            }
            Console.WriteLine($"Сумма всех натуральных числел от 1 до {maxNumber} которые кратны 3 или 5 равно - {summNumbers}");
        }
    }
}
