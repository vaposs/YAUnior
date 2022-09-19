using System;

namespace Project_19
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random randon = new Random();
            int minNumber = 1;
            int maxNumber = 999999999;
            int randomNumber = randon.Next(minNumber,maxNumber);
            int degreeNumber = 1;
            int degreeCount = 1;
            int square = 2;
            bool isBig = true;

            while(isBig)
            {
                
                if (degreeCount > randomNumber)
                {
                    isBig = false;
                }
                else
                {
                    degreeCount = degreeCount * square;
                }
                degreeNumber++;
            }
            Console.WriteLine($"2 в степени {degreeNumber} больше числа {randomNumber}");
        }
    }
}
