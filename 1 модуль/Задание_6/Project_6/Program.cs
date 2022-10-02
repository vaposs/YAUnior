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

            linesPictute = picture / fullPictureLine;
            extraPictures = picture % fullPictureLine;

            Console.WriteLine("заполненые рядов - " + fullPictureLine);
            Console.WriteLine("Лишние карты - " + extraPictures);
        }
    }
}
