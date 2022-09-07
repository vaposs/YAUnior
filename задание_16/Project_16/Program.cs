using System;

namespace задание_16
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int constantChar = 4;
            Console.Write("Введите имя - ");
            string name = Console.ReadLine();
            Console.Write("Введите символ - ");
            char frameSymbol = Convert.ToChar(Console.ReadLine());

            int charToLine = constantChar + name.Length;

            for (int i = 0; i < charToLine; i++)
            {
                Console.Write(frameSymbol);
            }
            Console.WriteLine("");
            Console.Write($"{frameSymbol} {name} {frameSymbol}");
            Console.WriteLine("");
            for (int i = 0; i < charToLine; i++)
            {
                Console.Write(frameSymbol);
            }
        }
    }
}
