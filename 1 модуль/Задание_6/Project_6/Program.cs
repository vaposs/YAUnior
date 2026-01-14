using System;

namespace Project_6
{
    class Program
    {
        static void Main()
        {
            int picture = 52;
            int fullPictureLine;
            int extraPictures;
            int pictureInLine = 3;

            fullPictureLine = picture / pictureInLine;
            extraPictures = picture % fullPictureLine;

            Console.WriteLine("заполненые рядов - " + fullPictureLine);
            Console.WriteLine("Лишние карты - " + extraPictures);
        }
    }
}
