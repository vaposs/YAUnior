using System;

namespace задание_16
{
    class MainClass
    {
        public static void Main(string[] args)
        {using System;

namespace задание_16
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите имя - ");
            string name = Console.ReadLine();

            Console.Write("Введите символ - ");
            char frameSymbol = Console.ReadKey(true).KeyChar;

            string middleLine = $"{frameSymbol}{name}{frameSymbol}";
            string borderLine = new string(frameSymbol, middleLine.Length);

            Console.WriteLine(borderLine);
            Console.WriteLine(middleLine);
            Console.WriteLine(borderLine);

            Console.ReadKey();
        }
    }
}
            const int firstAndLastChar = 2;
            Console.Write("Введите имя - ");
            string name = Console.ReadLine();
            Console.Write("Введите символ - ");
            char frameSymbol = Convert.ToChar(Console.ReadLine());

            int charToLine = name.Length + firstAndLastChar;

            for (int i = 0; i < charToLine; i++)
            {
                Console.Write(frameSymbol);
            }

            Console.Write($"\n{frameSymbol}{name}{frameSymbol}\n");

            for (int i = 0; i < charToLine; i++)
            {
                Console.Write(frameSymbol);
            }
            Console.ReadKey();
        }
    }
}
