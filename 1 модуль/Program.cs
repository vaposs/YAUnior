using System;

namespace Exs_5;

class Program
{
    static void Main(string[] args)
    {
        const string CommandRubToUsd = "1";
        const string CommandUsdToRub = "2";
        const string CommandRubToYuan = "3";
        const string CommandYuanToRub = "4";
        const string CommandUsdToYuan = "5";
        const string CommandYuanToUsd = "6";
        const string WayOut = "exit";

        float rubToUsd = 0.01f;
        float usdToRub = 90.49f;
        float rubToYuan = 0.08f;
        float yuanToRub = 12.55f;
        float usdToYuan = 7.21f;
        float yuanToUsd = 0.13f;
        float currencyCount;
        bool isConverterActive = true;

        Console.WriteLine("Добрый день! В нашем обменнике вы можете поменять доллары, юани и рубли на соответсвующие валюты. " +
            "Для начала давайте узнаем сколько у вас денег и в какой валюте.");
        Console.Write("Введите баланс рублей:");
        float rub = Convert.ToSingle(Console.ReadLine());
        Console.Write("Введите баланс долларов:");
        float usd = Convert.ToSingle(Console.ReadLine());
        Console.Write("Введите баланс юаней:");
        float yuan = Convert.ToSingle(Console.ReadLine());

        while (isConverterActive)
        {
            Console.WriteLine("Выбирете, какой обмен вы хотите произвести:" + CommandRubToUsd + "- Рубли в доллары." + CommandUsdToRub + "- Доллары в рубли." + CommandRubToYuan + "- Рубли в юани." +
           CommandYuanToRub + "- Юани в рубли." + CommandUsdToYuan + "- Доллары в юани." + CommandYuanToUsd + "- Юани в доллары.");
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case CommandRubToUsd:
                        Console.WriteLine("Обмен рублей на доллары.");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            usd += currencyCount * rubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег.");
                        }
                        break;
                    
                case CommandUsdToRub:
                        Console.WriteLine("Обмен долларов на рубли.");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            rub += currencyCount * usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег.");
                        }
                        break;

                case CommandRubToYuan:
                        Console.WriteLine("Обмен рублей на юани.");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            yuan += currencyCount * rubToYuan;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег.");
                        }
                        break;

                case CommandYuanToRub:
                        Console.WriteLine("Обмен юаней на рубли.");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (yuan >= currencyCount)
                        {
                            yuan -= currencyCount;
                            rub += currencyCount * yuanToRub;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег.");
                        }
                        break;

                case CommandUsdToYuan:
                        Console.WriteLine("Обмен долларов на юани.");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            yuan += currencyCount * usdToYuan;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег.");
                        }
                        break;

                case CommandYuanToUsd:
                        Console.WriteLine("Обмен юаней на доллары.");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (yuan >= currencyCount)
                        {
                            yuan -= currencyCount;
                            usd += currencyCount * yuanToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег.");
                        }
                        break;
            }

            Console.WriteLine("Ваш баланс " + rub + " рублей , " + usd + " долларов и " + yuan + " юаней.");
            Console.WriteLine("Повторить операцию?");

            if (Console.ReadLine() == WayOut)
            {
                isConverterActive = false;
            }

            Console.ReadKey();
        }
    }
}
