using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool isWork = true;
            int life = 10;
            int maxLife = 10;
            int damage;
            int heal;
         
            while (isWork)
            {
                Console.Write("\nвведите количество урона - ");
                damage = Convert.ToInt32(Console.ReadLine());
                Console.Write("введите количество хила - ");
                heal = Convert.ToInt32(Console.ReadLine());

                life = life - damage + heal;

                if (life > maxLife)
                {
                    life = maxLife;
                }

                PrintLifeLine(life);

                if(life <= 0)
                {
                    isWork = false;
                    Console.WriteLine("\nGame Over");
                }
            }
        }

        static void PrintLifeLine(int life)
        {
            int arraySize = 12;
            char[] healtBar = new char[arraySize];
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
        }
    }
}
