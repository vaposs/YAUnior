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
            bool isSeel = true;
            
            while(isSeel)
            {
                Console.WriteLine($"игрок имеет: рублей - {rubMoney}, доларов - {usdMoney}, евро - {eurMoney}");
                Console.WriteLine($"текущий курс долара - {usdInRub}, евро - {eurInRub}.");
                Console.Write("вам купить или продать?(buy/seel) - ");
                string buyOrSeel = Console.ReadLine();

                while (!((buyOrSeel == "buy") || (buyOrSeel == "seel")))
                {
                    Console.Write("неверный ввод, вам купить или продать?(buy/seel) - ");
                    buyOrSeel = Console.ReadLine();
                }

                Console.Write("какую валюту?(usd/eur) - ");
                string buySeelCurrency = Console.ReadLine();

                while (!((buySeelCurrency == "usd") || (buySeelCurrency == "eur")))
                {
                    Console.Write("неверный ввод, выберите валюту(usd/eur) - ");
                    buySeelCurrency = Console.ReadLine();
                }

                Console.Write("сколько? - ");

                while(true)
                {
                    float haveMany = Convert.ToSingle(Console.ReadLine());

                    if( (buyOrSeel == "buy") && (buySeelCurrency == "usd") && (rubMoney > usdInRub * haveMany))
                    {
                        rubMoney -= usdInRub * haveMany;
                        usdMoney += haveMany;
                        break;
                    }
                    else if((buyOrSeel == "seel")&&(buySeelCurrency == "usd") && (haveMany <= usdMoney))
                    {
                        rubMoney += usdInRub * haveMany;
                        usdMoney -= haveMany;
                        break;
                    }
                    else if ((buyOrSeel == "buy") && (buySeelCurrency == "eur") && (rubMoney > eurInRub * haveMany))
                    {
                        rubMoney -= eurInRub * haveMany;
                        eurMoney += haveMany;
                        break;
                    }
                    else if ((buyOrSeel == "seel") && (buySeelCurrency == "eur") && (haveMany <= eurMoney))
                    {
                        rubMoney += eurInRub * haveMany;
                        eurMoney -= haveMany;
                        break;
                    }
                    Console.Write("не достаточно денег, сколько? - ");
                }

                Console.WriteLine($"игрок имеет: рублей - {rubMoney}, доларов - {usdMoney}, евро - {eurMoney}");
                Console.Write("начать заново?(Y/N) - ");

                while (true)
                {
                    string exit = Console.ReadLine();
                    if (exit == "N" || exit == "n")
                    {
                        isSeel = false;
                        break;
                    }
                    if (exit == "y" || exit == "Y")
                    {
                        break;
                    }
                    Console.Write("не верный ввод, начать заново(Y/N) - ");
                }
                Console.Clear();
            }
        }
    }
}
