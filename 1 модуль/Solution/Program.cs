using System;

namespace ZD
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // мы используем for так как знаем начало и конец цикла

            int startNumber = 5;
            int endNumber = 103;
            int step = 7;

            for (int i = startNumber; i <= endNumber; i+= step)
            {
                Console.Write(i + " ");
            }
        }
    }
}
