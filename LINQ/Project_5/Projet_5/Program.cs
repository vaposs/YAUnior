using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Store store = new Store();

            store.Work();
            Console.WriteLine("конец");
            Console.ReadKey();
        }
    }

    class Store
    {
        private PackedRationsCreator _packedRationsCreator = new PackedRationsCreator();
        private List<PackedRations> _packedRations = new List<PackedRations>();

        public void Work()
        {
            CreatPackedRations();
            Show(_packedRations);
            int minData = GetMinData();
            int maxData = GetMaxData();

            Console.WriteLine("\nвыводим на екран всю просрочку");
            int years = GetSearchParameter(minData, maxData);
            Show(_packedRations.Where(packedRations => (packedRations.DateManufacture + packedRations.ProductExpirationDate) < years).ToList());
        }

        private void CreatPackedRations()
        {
            int minPackedRations = 5;
            int maxPackedRations = 7;

            int contPackedRations = UserUtils.GenerateRandomNumber(minPackedRations, maxPackedRations);

            for (int i = 0; i < contPackedRations; i++)
            {
                _packedRations.Add(_packedRationsCreator.Creator());
            }
        }

        private void Show(List<PackedRations> packedRations)
        {
            foreach (PackedRations packedRation in packedRations)
            {
                Console.WriteLine($"{packedRation.Name}, дата производства - {packedRation.DateManufacture}, срок хранения - {packedRation.ProductExpirationDate}");
            }
        }

        private int GetMaxData()
        {
            return _packedRations.Max(packedRations => packedRations.DateManufacture) + _packedRations.Max(packedRations => packedRations.ProductExpirationDate);
        }

        private int GetMinData()
        {
            return _packedRations.Min(packedRations => packedRations.DateManufacture);
        }

        private int GetSearchParameter(int minData, int maxData)
        {
            Console.Write($"укажите текущий год({minData}/{maxData}): ");
            int numbersPlayer = UserUtils.GetPositiveNumber();

            while (numbersPlayer < minData || numbersPlayer > maxData)
            {
                Console.WriteLine("неверный ввод");
                Console.Write($"укажите текущий год({minData}/{maxData}): ");
                numbersPlayer = UserUtils.GetPositiveNumber();
            }

            return numbersPlayer;
        }

    }

    class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
        {
            return s_random.Next(minRandomNumber, maxRandomNumber);
        }

        public static int GetPositiveNumber()
        {
            string readName;
            bool isConversionSucceeded = true;
            bool isCorrectNumber;
            int number = 0;

            while (isConversionSucceeded)
            {
                readName = Console.ReadLine();
                isCorrectNumber = int.TryParse(readName, out number);

                if (isCorrectNumber)
                {
                    if (number < 1)
                    {
                        Console.Write("Неверный ввод. Число меньше единици. Повторите ввод - ");
                    }
                    else
                    {
                        isConversionSucceeded = false;
                    }
                }
                else
                {
                    Console.Write("Неверный ввод. Повторите ввод - ");
                }
            }

            return number;
        }
    }

    class PackedRations
    {
        public PackedRations(string name, int dateManufacture, int productExpirationDate)
        {
            Name = name;
            DateManufacture = dateManufacture;
            ProductExpirationDate = productExpirationDate;
        }

        public string Name { get; private set; }
        public int DateManufacture { get; private set; }
        public int ProductExpirationDate { get; private set; }
    }

    class PackedRationsCreator
    {
        public PackedRations Creator()
        {
            return new PackedRations(GetName(), GetDate(), GetExpirationDate());
        }

        private string GetName()
        {
            string[] name = {"говяжья","свиная","куриная","утиная","гусиная","индюшиная","баранина","крольича" };

            return name[UserUtils.GenerateRandomNumber(0, name.Length)];
        }

        private int GetDate()
        {
            int minDate = 1900;
            int maxDate = 2000;

            return UserUtils.GenerateRandomNumber(minDate, maxDate);
        }

        private int GetExpirationDate()
        {
            int minExpirationDate = 30;
            int maxExpirationDate = 100;

            return UserUtils.GenerateRandomNumber(minExpirationDate, maxExpirationDate);
        }
    }
}



//Есть набор тушенки. У тушенки есть название, год производства и срок годности.
//Написать запрос для получения всех просроченных банок тушенки.
//Чтобы не заморачиваться, можете думать, что считаем только года, без месяцев.
