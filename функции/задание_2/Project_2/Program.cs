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
                while (int.TryParse(Console.ReadLine(), out damage) == false)
                {
                    Console.Write("Ошибка! Введите целое число: ");
                }

                Console.Write("введите количество хила - ");
                while (int.TryParse(Console.ReadLine(), out heal) == false)
                {
                    Console.Write("Ошибка! Введите целое число: ");
                }

                life = life - damage + heal;

                if (life > maxLife)
                {
                    life = maxLife;
                }

                Console.Write("Введите процент заполнения бара: ");
                int percent;
                while (int.TryParse(Console.ReadLine(), out percent) == false || percent < 0 || percent > 100)
                {
                    Console.Write("Ошибка! Введите целое число от 0 до 100: ");
                }

                Console.Write("Введите длину бара: ");
                int barLength;
                while (int.TryParse(Console.ReadLine(), out barLength) == false || barLength <= 0)
                {
                    Console.Write("Ошибка! Введите положительное целое число: ");
                }

                PrintLifeLine(percent, barLength);
                PrintLifeLine(life, maxLife, barLength);

                if (life <= 0)
                {
                    isWork = false;
                    Console.WriteLine("\nGame Over");
                }
            }
        }

        static void PrintLifeLine(int percent, int barLength)
        {
            char openBracket = '[';
            char closedBracket = ']';
            char occupiedCell = '#';
            char freeCell = '_';
            float maxPercent = 100f;

            Console.Write(openBracket);

            int filledCount = (int)Math.Round(barLength * percent / maxPercent);

            for (int i = 0; i < filledCount; i++)
            {
                Console.Write(occupiedCell);
            }

            for (int i = filledCount; i < barLength; i++)
            {
                Console.Write(freeCell);
            }

            Console.WriteLine(closedBracket);
            Console.WriteLine($"Заполнение: {percent}% ({filledCount}/{barLength} ячеек)");
        }

        static void PrintLifeLine(int currentLife, int maxLife, int barLength)
        {
            char openBracket = '[';
            char closedBracket = ']';
            char occupiedCell = '#';
            char freeCell = '_';

            Console.Write(openBracket);

            double healthPercent = (double)currentLife / maxLife;
            int filledCount = (int)Math.Round(barLength * healthPercent);

            for (int i = 0; i < filledCount; i++)
            {
                Console.Write(occupiedCell);
            }

            for (int i = filledCount; i < barLength; i++)
            {
                Console.Write(freeCell);
            }

            Console.WriteLine(closedBracket);
            Console.WriteLine($"Здоровье: {currentLife}/{maxLife} ({healthPercent:P0})");
        }
    }
}
