using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\nвведите количество урона - ");
                int damage = Convert.ToInt32(Console.ReadLine());
                Console.Write("введите количество хила - ");
                int heal = Convert.ToInt32(Console.ReadLine());
                HealBar(damage, heal);
            }
        }

        static void HealBar(int damage, int heal)
        {
            int life = 10;
            int arraySize = 12;
            char[] healtBar = new char[arraySize];
            life = life - damage + heal;

            for (int i = 0; i < healtBar.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write("[");
                }
                else if (i == healtBar.Length - 1)
                {
                    Console.Write("]");
                }
                else
                {
                    if (i <= life)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
            }
        }
    }
}
