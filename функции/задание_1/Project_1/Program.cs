using System;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddDossierCommand = "add";
            const string PrintDossierCommand = "print";
            const string DeleteDossierCommand = "delete";
            const string SearchDossierCommand = "search";
            const string ExitProgramCommand = "exit";

            string[] fullNames = new string[0];
            string[] professions = new string[0];
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"\nДоступные команды:");
                Console.WriteLine($"1. {AddDossierCommand} - добавить досье");
                Console.WriteLine($"2. {PrintDossierCommand} - вывести все досье");
                Console.WriteLine($"3. {DeleteDossierCommand} - удалить досье");
                Console.WriteLine($"4. {SearchDossierCommand} - поиск по фамилии");
                Console.WriteLine($"5. {ExitProgramCommand} - выход из программы");

                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case AddDossierCommand:
                        AddDossier(ref fullNames, ref professions);
                        break;

                    case PrintDossierCommand:
                        PrintDossier(fullNames, professions);
                        break;

                    case DeleteDossierCommand:
                        DeleteDossier(ref fullNames, ref professions);
                        break;

                    case SearchDossierCommand:
                        SearchDossier(fullNames, professions);
                        break;

                    case ExitProgramCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullNames, ref string[] professions)
        {
            Console.Write("Введите ФИО: ");
            AddElement(ref fullNames);

            Console.Write("Введите профессию: ");
            AddElement(ref professions);

            Console.WriteLine("Досье успешно добавлено!");
        }

        static void PrintDossier(string[] fullNames, string[] professions)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("Список досье пуст.");
                Console.ReadKey();
                return;
            }

            PrintHeader();

            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {fullNames[i]} - {professions[i]}");
            }

            Console.WriteLine($"\nВсего записей: {fullNames.Length}");
            Console.ReadKey();
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] professions)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("Список досье пуст. Нечего удалять.");
                Console.ReadKey();
                return;
            }

            PrintDossier(fullNames, professions);

            int dossierNumber = GetValidDossierNumber(fullNames.Length);

            if (dossierNumber == -1)
            {
                Console.WriteLine("Удаление отменено.");
                Console.ReadKey();
                return;
            }

            int indexToDelete = dossierNumber - 1;

            DeleteElement(ref fullNames, indexToDelete);
            DeleteElement(ref professions, indexToDelete);

            Console.WriteLine($"Досье №{dossierNumber} успешно удалено.");
            Console.ReadKey();
        }

        static int GetValidDossierNumber(int maxNumber)
        {
            int dossierNumber;
            string userInput;
            bool isValidNumber;

            while (true)
            {
                Console.Write($"\nВведите номер досье для удаления (1-{maxNumber}) или 0 для отмены: ");
                userInput = Console.ReadLine();

                isValidNumber = int.TryParse(userInput, out dossierNumber);

                if (!isValidNumber)
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                    continue;
                }

                if (dossierNumber == 0)
                {
                    return -1;
                }

                if (dossierNumber < 1 || dossierNumber > maxNumber)
                {
                    Console.WriteLine($"Ошибка: номер должен быть от 1 до {maxNumber}.");
                    continue;
                }

                return dossierNumber;
            }
        }

        static void SearchDossier(string[] fullNames, string[] professions)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("Список досье пуст.");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите фамилию для поиска: ");
            string searchLastName = Console.ReadLine();

            bool found = false;
            char lineDivider = ' ';

            PrintHeader();

            for (int i = 0; i < fullNames.Length; i++)
            {
                string[] nameParts = fullNames[i].Split(lineDivider);

                if (nameParts.Length > 0 && searchLastName.Equals(nameParts[0], StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{i + 1}. {fullNames[i]} - {professions[i]}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Фамилия '{searchLastName}' не найдена.");
            }

            Console.ReadKey();
        }

        static void PrintHeader()
        {
            Console.WriteLine("\n┌─────┬──────────────────────┬──────────────────────┐");
            Console.WriteLine("│  №  │         ФИО           │      Профессия        │");
            Console.WriteLine("├─────┼──────────────────────┼──────────────────────┤");
        }

        static void AddElement(ref string[] array)
        {
            string newValue = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newValue))
            {
                Console.WriteLine("Значение не может быть пустым. Операция отменена.");
                return;
            }

            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - 1] = newValue;
            array = tempArray;
        }

        static void DeleteElement(ref string[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне диапазона массива");
            }

            if(index >= 0 && index <= array.Length)
            {
                string[] tempArray = new string[array.Length - 1];

                for (int i = 0; i < index; i++)
                {
                    tempArray[i] = array[i];
                }

                for (int i = index; i < tempArray.Length; i++)
                {
                    tempArray[i] = array[i + 1];
                }

                array = tempArray;
            }
            else
            {
                Console.WriteLine("Неверный индекс");
            }
        }
    }
}
