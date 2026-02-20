using System;

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
