using System;

namespace Project_9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Сколько раз желаете запустить цыкл? - ");
            int cycle = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; cycle > i; cycle--)
            {
                Console.WriteLine($"выведеая строка №{cycle}");
            }
        }
    }
}
