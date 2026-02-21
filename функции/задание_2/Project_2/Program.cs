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
                while (!int.TryParse(Console.ReadLine(), out damage))
                {
                    Console.Write("Ошибка! Введите целое число: ");
                }

                Console.Write("введите количество хила - ");
                while (!int.TryParse(Console.ReadLine(), out heal))
                {
                    Console.Write("Ошибка! Введите целое число: ");
                }

                life = life - damage + heal;

                if (life > maxLife)
                {
                    life = maxLife;
                }

                Console.Write("Введите длину бара: ");
                int barLength;
                while (!int.TryParse(Console.ReadLine(), out barLength) || barLength <= 0)
                {
                    Console.Write("Ошибка! Введите положительное целое число: ");
                }

                PrintLifeLine(life, maxLife, barLength);

                if (life <= 0)
                {
                    isWork = false;
                    Console.WriteLine("\nGame Over");
                }
            }
        }

        static void PrintLifeLine(int currentLife, int maxLife, int barLength)
        {
            char openBracket = '[';
            char closedBracket = ']';
            char occupiedCell = '#';
            char freeCell = '_';


            Console.Write(openBracket);

            double percent = (double)currentLife / maxLife;
            int filledCount = (int)(barLength * percent);

            for (int i = 0; i < filledCount; i++)
            {
                Console.Write(occupiedCell);
            }

            for (int i = filledCount; i < barLength; i++)
            {
                Console.Write(freeCell);
            }

            Console.WriteLine(closedBracket);

            Console.WriteLine($"Здоровье: {currentLife}/{maxLife} ({percent:P0})");
        }
    }
}
