using System;
using System.Diagnostics;

namespace Project_14
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double rubMoney = 1000;
            double usdMoney = 100;
            double eurMoney = 100;

            double usdInRub = 62.05;
            double usdInEur = 1.01;
            double eurInRub = 60.22;
            double eurInUsd = 0.99;
            double rubInUsd = 0.02;
            double rubInEur = 0.02;
            string buy = "buy";
            string sell = "sell";
            string currencyUSD = "usd";
            string currencyEUR = "eur";
            string currencyRUB = "rub";
            int howMany;
            bool isSell = true;
            bool isNotCorrect = true;
            bool oneMoreSell = true;
            char YesSell = 'Y';
            char yesSell = 'y';
            char NotSell = 'N';
            char notSell = 'n';

            while (isSell)
            {
                Console.WriteLine($"игрок имеет: рублей - {rubMoney}, доларов - {usdMoney}, евро - {eurMoney}");
                Console.WriteLine($"текущий курс долара - {usdInRub}, евро - {eurInRub}.");
                Console.Write("вам купить или продать?(buy/sell) - ");
                string buyOrSeel = Console.ReadLine();

                while (isNotCorrect)
                {
                    if ((buyOrSeel == buy) || (buyOrSeel == sell))
                    {
                        isNotCorrect = false;
                    }
                    else
                    {
                        Console.Write("неверный ввод, вам купить или продать?(buy/sell) - ");
                        buyOrSeel = Console.ReadLine();
                    }
                }

                isNotCorrect = true;
                Console.Write("какую валюту купить?(usd/eur/rub) - ");
                string firstCurrency = Console.ReadLine();

                while (isNotCorrect)
                {
                    if ((firstCurrency == currencyUSD) || (firstCurrency == currencyEUR) || (firstCurrency == currencyRUB))
                    {
                        isNotCorrect = false;
                    }
                    else
                    {
                        Console.Write("неверный ввод, выберите валюту(usd/eur/rub) - ");
                        firstCurrency = Console.ReadLine();
                    }
                }

                isNotCorrect = true;
                Console.Write("какую валюту продать?(usd/eur/rub) - ");
                string secondCurrency = Console.ReadLine();

                while (isNotCorrect)
                {
                    if ((secondCurrency == currencyUSD) || (secondCurrency == currencyEUR) || (secondCurrency == currencyRUB))
                    {
                        isNotCorrect = false;
                    }
                    else
                    {
                        Console.Write("неверный ввод, выберите валюту(usd/eur/rub) - ");
                        firstCurrency = Console.ReadLine();
                    }
                }

                isNotCorrect = true;
                Console.Write("сколько? - ");
                howMany = Convert.ToInt32(Console.ReadLine());

                if(buyOrSeel == buy && firstCurrency == currencyUSD && secondCurrency == currencyEUR)
                {
                    if (eurInUsd * howMany < eurMoney)
                    {
                        Console.WriteLine("не достаточно евро!");
                    }
                    else
                    {
                        usdMoney += howMany;
                        eurMoney -= eurInUsd * howMany;
                    }
                }
                else if(buyOrSeel == buy && firstCurrency == currencyUSD && secondCurrency == currencyRUB)
                {
                    if (rubInUsd * howMany < rubMoney)
                    {
                        Console.WriteLine("не достаточно рублей!");
                    }
                    else
                    {
                        usdMoney += howMany;
                        rubMoney -= usdInRub * howMany;
                    }
                }
                else if(buyOrSeel == sell && firstCurrency == currencyUSD && secondCurrency == currencyEUR)
                {
                    if(usdMoney < howMany)
                    {
                        Console.WriteLine("не достаточно доларов!");
                    }
                    else
                    {
                        usdMoney -= howMany;
                        eurMoney += usdInEur * howMany;
                    }
                }
                else if (buyOrSeel == sell && firstCurrency == currencyUSD && secondCurrency == currencyRUB)
                {
                    if (usdMoney < howMany)
                    {
                        Console.WriteLine("не достаточно доларов!");
                    }
                    else
                    {
                        usdMoney -= howMany;
                        rubMoney += usdInRub * howMany;
                    }

                }
                else if (buyOrSeel == buy && firstCurrency == currencyEUR && secondCurrency == currencyUSD)
                {
                    if (usdInEur * howMany < usdMoney)
                    {
                        Console.WriteLine("не достаточно доларов!");
                    }
                    else
                    {
                        eurMoney += howMany;
                        usdMoney -= usdInEur * howMany;
                    }
                }
                else if (buyOrSeel == buy && firstCurrency == currencyRUB && secondCurrency == currencyEUR)
                {
                    if (rubInEur * howMany < rubMoney)
                    {
                        Console.WriteLine("не достаточно рублей!");
                    }
                    else
                    {
                        eurMoney += howMany;
                        rubMoney -= eurInRub * howMany;
                    }
                }
                else if (buyOrSeel == sell && firstCurrency == currencyRUB && secondCurrency == currencyUSD)
                {
                    if (eurMoney < howMany)
                    {
                        Console.WriteLine("не достаточно евро!");
                    }
                    else
                    {
                        eurMoney -= howMany;
                        usdMoney += eurInUsd * howMany;
                    }
                }
                else if (buyOrSeel == sell && firstCurrency == currencyRUB && secondCurrency == currencyEUR)
                {
                    if (eurMoney < howMany)
                    {
                        Console.WriteLine("не достаточно евро!");
                    }
                    else
                    {
                        eurMoney -= howMany;
                        rubMoney += eurInRub * howMany;
                    }

                }
                else if (buyOrSeel == buy && firstCurrency == currencyRUB && secondCurrency == currencyUSD)
                {
                    if (usdInRub * howMany < usdMoney)
                    {
                        Console.WriteLine("не достаточно доларов!");
                    }
                    else
                    {
                        rubMoney += howMany;
                        usdMoney -= usdInRub * howMany;
                    }
                }
                else if (buyOrSeel == buy && firstCurrency == currencyEUR && secondCurrency == currencyRUB)
                {
                    if (rubInEur * howMany < rubMoney)
                    {
                        Console.WriteLine("не достаточно рублей!");
                    }
                    else
                    {
                        eurMoney += howMany;
                        rubMoney -= eurInRub * howMany;
                    }
                }
                else if (buyOrSeel == sell && firstCurrency == currencyEUR && secondCurrency == currencyUSD)
                {
                    if (eurMoney < howMany)
                    {
                        Console.WriteLine("не достаточно евро!");
                    }
                    else
                    {
                        eurMoney -= howMany;
                        usdMoney += eurInUsd * howMany;
                    }
                }
                else if (buyOrSeel == sell && firstCurrency == currencyEUR && secondCurrency == currencyRUB)
                {
                    if (eurMoney < howMany)
                    {
                        Console.WriteLine("не достаточно евро!");
                    }
                    else
                    {
                        eurMoney -= howMany;
                        rubMoney += eurInRub * howMany;
                    }

                }




                Console.WriteLine($"игрок имеет: рублей - {rubMoney}, доларов - {usdMoney}, евро - {eurMoney}");
                Console.Write("начать заново?(Y/N) - ");
                oneMoreSell = true;

                while (oneMoreSell)
                {
                    char exit = Convert.ToChar(Console.ReadLine());
                    if (exit == NotSell || exit == notSell)
                    {
                        isSell = false;
                        oneMoreSell = false;
                    }
                    else if (exit == yesSell || exit == YesSell)
                    {
                        oneMoreSell = false;
                    }
                    else
                    {
                        Console.Write("не верный ввод, начать заново(Y/N) - ");
                    }
                }
                Console.Clear();
            }
        }
    }
}
