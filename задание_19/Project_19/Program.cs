using System;

namespace Project_19
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random randon = new Random();
            int randomNumber = randon.Next(1,999999999);
            int degreeNumber = 0;
            int degreeCount = 1;
            int square = 2;

            while(true)
            {
                if(degreeCount > randomNumber)
                {
                    break;
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
