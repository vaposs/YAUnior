using System;

namespace Project_9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Сколько раз желаете запустить цыкл? - ");
            int numberOfIterations = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; numberOfIterations > i; numberOfIterations--)
            {
                Console.WriteLine($"выведеая строка №{numberOfIterations}");
            }
        }
    }
}
