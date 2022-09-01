using System;

namespace Project_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int cristalCost = 1;
            bool enoughtMoney;

            Console.Write("добрый день, сколько у вас золота? - ");
            int money = Convert.ToInt32(Console.ReadLine());
            Console.Write($"сегодня кристалы стоят по {cristalCost}, сколько желаете купить? - ");
            int cristalCount = Convert.ToInt32(Console.ReadLine());
            enoughtMoney = money >= cristalCost * cristalCount;
            cristalCount *= Convert.ToInt32(enoughtMoney);
            money -= cristalCost * cristalCount;
            Console.WriteLine($"куплено {cristalCount} кристалов, осталось {money} золота");
        }
    }
}
