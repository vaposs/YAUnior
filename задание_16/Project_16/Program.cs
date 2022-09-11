using System;

namespace задание_16
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int firstAndLastCharacterAndSpace = 4;
            Console.Write("Введите имя - ");
            string name = Console.ReadLine();
            Console.Write("Введите символ - ");
            char frameSymbol = Convert.ToChar(Console.ReadLine());

            int charToLine = firstAndLastCharacterAndSpace + name.Length;
            FillFrame(charToLine,frameSymbol);
            Console.WriteLine("");
            Console.Write($"{frameSymbol} {name} {frameSymbol}");
            Console.WriteLine("");
            FillFrame(charToLine, frameSymbol);
        }

        public static void FillFrame(int charToLine, char frameSymbol)
        {
            for (int i = 0; i < charToLine; i++)
            {
                Console.Write(frameSymbol);
            }
        }
    }
}
