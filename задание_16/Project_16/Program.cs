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
            FrameSymvol(charToLine,frameSymbol);
            Console.WriteLine("");
            Console.Write($"{frameSymbol} {name} {frameSymbol}");
            Console.WriteLine("");
            FrameSymvol(charToLine, frameSymbol);
        }

        public static void FrameSymvol(int charToLine, char frameSymbol)
        {
            for (int i = 0; i < charToLine; i++)
            {
                Console.Write(frameSymbol);
            }
        }
    }
}
