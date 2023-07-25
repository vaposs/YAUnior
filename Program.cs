using System;

namespace Exs_5;

class Program
{
    static void Main(string[] args)
    {
        float rubToUsd = 0.01f;
        float usdToRub = 90.49f;
        float rubToYuan = 0.08f;
        float yuanToRub = 12.55f;
        float usdToYuan = 7.21f;
        float yuanToUsd = 0.13f;
        float currencyCount;
        const string wayOut = "exit";
        bool next = true;

        Console.WriteLine("Добрый день! В нашем обменнике вы можете поменять доллары, юани и рубли на соответсвующие валюты. " +
            "Для начала давайте узнаем сколько у вас денег и в какой валюте.");
        Console.Write("Введите баланс рублей:");
        float rub = Convert.ToSingle(Console.ReadLine());
        Console.Write("Введите баланс долларов:");
        float usd = Convert.ToSingle(Console.ReadLine());
        Console.Write("Введите баланс юаней:");
        float yuan = Convert.ToSingle(Console.ReadLine());

        while (next)
        {
            Console.WriteLine("Выбирете, какой обмен вы хотите произвести: 1- Рубли в доллары. 2- Доллары в рубли. 3- Рубли в юани. " +
           "4- Юани в рубли. 5- Доллары в юани. 6- Юани в доллары.");
            string userInput = Console.ReadLine();
            Console.ReadKey();

            switch (userInput)
            {
                case "1":
                    {
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
                            break;
                        }
                        break;
                    }
                case "2":
                    {
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
                    }
                case "3":
                    {
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
                    }
                case "4":
                    {
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
                    }
                case "5":
                    {
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
                    }
                case "6":
                    {
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
            }

            Console.WriteLine("Ваш баланс " + rub + " рублей , " + usd + " долларов и " + yuan + " юаней.");
            Console.WriteLine("Повторить операцию?");

            if (Console.ReadLine() == wayOut)
            {
                next = false;
            }
                
            Console.ReadKey();
        }


        }
    }



