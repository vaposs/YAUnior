using System;

namespace Project_9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Сколько раз желаете запустить цикл? - ");
            int numberOfIterations = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= numberOfIterations; i++)
            {
                Console.WriteLine($"строка №{i}");
            }
        }
    }
}
