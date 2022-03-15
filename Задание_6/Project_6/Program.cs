using System;

namespace Project_6
{
    class Program
    {
        static void Main()
        {
            int picture = 52;
            int line;
            int extraPictures;

            line = picture / 3;
            extraPictures = picture % 3;

            Console.WriteLine("заполненые рядов - "+ line );
            Console.WriteLine("Лишние карты - " + extraPictures);
        }
    }
}
