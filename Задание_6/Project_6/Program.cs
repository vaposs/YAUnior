using System;

namespace Project_6
{
    class Program
    {
        static void Main()
        {
            int picture = 52;
            int linesPictute;
            int extraPictures;
            int pictureInLine = 3;

            linesPictute = picture / pictureInLine;
            extraPictures = picture % pictureInLine;

            Console.WriteLine("заполненые рядов - " + linesPictute);
            Console.WriteLine("Лишние карты - " + extraPictures);
        }
    }
}
