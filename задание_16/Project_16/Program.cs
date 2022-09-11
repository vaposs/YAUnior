using System;

namespace задание_16
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const int firstAndLastChar = 4;
            Console.Write("Введите имя - ");
            string name = Console.ReadLine();
            Console.Write("Введите символ - ");
            char frameSymbol = Convert.ToChar(Console.ReadLine());

            int charToLine = name.Length + firstAndLastChar;

            for (int i = 0; i < charToLine; i++)
            {
                Console.Write(frameSymbol);
            }

            Console.Write($"\n{frameSymbol} {name} {frameSymbol}\n");

            for (int i = 0; i < charToLine; i++)
            {
                Console.Write(frameSymbol);
            }
        }
    }
}
