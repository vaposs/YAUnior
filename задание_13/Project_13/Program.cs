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
            Console.WriteLine(maxNumber);
            for(int i = 1; i <= maxNumber; i++)
            {
                if((i%3 == 0)||(i%5 == 0))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
