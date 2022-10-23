using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool isWork = true;
            int life = 10;

            while (isWork)
            {
                Console.Write("\nвведите количество урона - ");
                int damage = Convert.ToInt32(Console.ReadLine());
                Console.Write("введите количество хила - ");
                int heal = Convert.ToInt32(Console.ReadLine());
                life = HealBar(damage, heal, life);
                if(life <= 0)
                {
                    isWork = false;
                    Console.WriteLine("\nGame Over");
                }
            }
        }

        static int HealBar(int damage, int heal, int life)
        {
            int arraySize = 12;
            char[] healtBar = new char[arraySize];
            life = life - damage + heal;
            if(life > 10)
            {
                life = 10;
            }

            Console.Write("[");

            for (int i = 1; i < healtBar.Length - 1; i++)
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
            Console.Write("]");
            return life;
        }
    }
}
