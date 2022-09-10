using System;

namespace Project_14
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double rubMoney = 1000;
            double usdMoney = 100;
            double eurMoney = 100;
            double usdInRub = 60.37;
            double eurInRub = 60.22;
            double usdInEur = 0.99;
            string buy = "buy";
            string sell = "sell";
            string currencyUSD = "usd";
            string currencyEUR = "eur";
            string currencyRUB = "rub";
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
                Console.Write("вам купить или продать?(buy/seel) - ");
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
                Console.Write("какую валюту?(usd/eur/rub) - ");
                string buySeelCurrency = Console.ReadLine();

                while (isNotCorrect)
                {
                    if ((buySeelCurrency == currencyUSD) || (buySeelCurrency == currencyEUR) || (buySeelCurrency == currencyRUB))
                    {
                        isNotCorrect = false;
                    }
                    else
                    {
                        Console.Write("неверный ввод, выберите валюту(usd/eur/rub) - ");
                        buySeelCurrency = Console.ReadLine();
                    }
                }

                isNotCorrect = true;
                Console.Write("сколько? - ");

                while(isNotCorrect)
                {
                    float haveMany = Convert.ToSingle(Console.ReadLine());
                    if( (buyOrSeel == buy) && (buySeelCurrency == currencyUSD) && (rubMoney > usdInRub * haveMany))
                    {
                        rubMoney -= usdInRub * haveMany;
                        usdMoney += haveMany;
                        isNotCorrect = false;
                    }
                    else if((buyOrSeel == sell)&&(buySeelCurrency == currencyUSD) && (haveMany <= usdMoney))
                    {
                        rubMoney += usdInRub * haveMany;
                        usdMoney -= haveMany;
                        isNotCorrect = false;
                    }
                    else if ((buyOrSeel == buy) && (buySeelCurrency == currencyEUR) && (rubMoney > eurInRub * haveMany))
                    {
                        rubMoney -= eurInRub * haveMany;
                        eurMoney += haveMany;
                        isNotCorrect = false;
                    }
                    else if ((buyOrSeel == sell) && (buySeelCurrency == currencyEUR) && (haveMany <= eurMoney))
                    {
                        rubMoney += eurInRub * haveMany;
                        eurMoney -= haveMany;
                        isNotCorrect = false;
                    }
                    else if((buyOrSeel == buy) && ( buySeelCurrency == currencyRUB) && ( ))
                    {

                    }
                    else if (() && () && ())
                    else
                    {
                        Console.Write("не достаточно денег, сколько? - ");
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
