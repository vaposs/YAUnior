using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Database database = new Database();

            database.Work();

            Console.WriteLine("Конец");
            Console.ReadKey();
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

    class Database
    {
        private List<Patient> _patients = new List<Patient>();
        private List<string> _disease = new List<string>();

        public void Work()
        {
            const int SortNameCommand = 1;
            const string SortNameString = "сортировать по имени";
            const int SortAgeCommand = 2;
            const string SortAgeString = "сортировать по воррасту";
            const int ShowPatientWithDiseaseCommand = 3;
            const string ShowPatientWithDiseaseString = "вывести список с болезнью - ";
            const int ExitCommand = 4;
            const string ExitString = "Выход";

            bool isFinish = true;

            CreateListPatient();
            CreateListDisease();

            while (isFinish)
            {
                Console.WriteLine($"\n{SortNameCommand}.{SortNameString}");
                Console.WriteLine($"{SortAgeCommand}.{SortAgeString}");
                Console.WriteLine($"{ShowPatientWithDiseaseCommand}.{ShowPatientWithDiseaseString}");
                Console.WriteLine($"{ExitCommand}.{ExitString}");
                Console.Write("Введите команду - ");
                int playerCommand = UserUtils.GetPositiveNumber();

                switch (playerCommand)
                {
                    case 1:
                        ShowPatientWithName();
                        break;
                    case 2:
                        ShowPatientWithAge();
                        break;
                    case 3:
                        ShowPatientWithDisease();
                        break;
                    case 4:
                        isFinish = false;
                        break;
                    default:
                        Console.WriteLine("неверная команда");
                        break;
                }
            }
        }

        private void CreateListDisease()
        {
            bool repick;

            foreach (Patient patient in _patients)
            {
                repick = false;

                if (_disease.Count < 1)
                {
                    _disease.Add(patient.Disease);
                    repick = true;
                }
                else
                {
                    foreach (string disease in _disease)
                    {
                        if (patient.Disease == disease)
                        {
                            repick = true;
                        }
                    }
                }

                if (repick == false)
                {
                    _disease.Add(patient.Disease);
                }
            }
        }

        private void ShowPatientWithName()
        {
            ShowPatient(_patients.OrderBy(patient => patient.Name).ToList());
        }

        private void ShowPatientWithAge()
        {
            ShowPatient(_patients.OrderBy(patient => patient.Age).ToList());
        }

        private void ShowPatientWithDisease()
        {
            string disease = GetSearchParameterDisease();
            ShowPatient(_patients.Where(patient => patient.Disease == disease).ToList());
        }

        private void CreateListPatient()
        {
            int minPatient = 100;
            int maxPatient = 150;

            for (int i = 0; i < UserUtils.GenerateRandomNumber(minPatient, maxPatient); i++)
            {
                _patients.Add(new Patient());
            }
        }
        
        private void ShowPatient(List<Patient> patients)
        {
            int index = 1;

            foreach (Patient patient in patients)
            {
                Console.WriteLine($"{index}.{patient.Name} - {patient.Age} - {patient.Disease}");
                index++;
            }
        }
        
        private string GetSearchParameterDisease()
        {
            string choceDisease = "";
            bool correctСhoice = false;

            while (!correctСhoice)
            {
                foreach (string disease in _disease)
                {
                    Console.Write(disease + ", ");
                }

                Console.Write("\nвведите болезнь из представленого списка:");
                choceDisease = Console.ReadLine();

                foreach (string disease in _disease)
                {
                    if (disease == choceDisease)
                    {
                        correctСhoice = true;
                        break;
                    }
                }
            }

            return choceDisease;
        }
    }

    class Patient
    {
        private int _minAge = 10;
        private int _maxAge = 60;

        public Patient()
        {
            Name = GetName();
            Disease = GetDiseaseName();
            Age = UserUtils.GenerateRandomNumber(_minAge, _maxAge);
        }

        public string Name { get; private set; }
        public string Disease { get; private set; }
        public int Age { get; private set; }

        private string GetName()
        {
            string[] names = new string[] { "Петя", "Филя", "Семен", "Вася", "Степа", };

            return names[UserUtils.GenerateRandomNumber(0, names.Length)];
        }

        private string GetDiseaseName()
        {
            string[] names = new string[] { "алергия", "ангина", "ожог", "гастрит", "тахикардия" };

            return names[UserUtils.GenerateRandomNumber(0, names.Length)];
        }
    }
}
