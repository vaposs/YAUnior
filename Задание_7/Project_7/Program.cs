using System;

namespace Project_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int gold;
            int crystal;
            int crystalPrise;


            Console.WriteLine("Введите количество золота - ");
            gold = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Укажите цену кристала - ");
            crystalPrise = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("сколько кристалов вы хотите купить?");
            crystal = Convert.ToInt32(Console.ReadLine());

            if ((gold < crystalPrise) || (gold < (crystal*crystalPrise)))
            {
                Console.WriteLine("Не достаточно золота для покупки кристалов");
            }
            else
            {
                gold = gold - (crystal * crystalPrise);
                Console.WriteLine("У вас: " + crystal + " кристалов, и " + gold + " золота.");
            }
        }
    }
}
