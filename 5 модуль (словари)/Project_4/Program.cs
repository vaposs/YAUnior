using System;
using System.Collections.Generic;

namespace Project_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddDossierCommand = "add";
            const string PrintDossierCommand = "print";
            const string DeleteDossierCommand = "delete";
            const string ExitProgramCommand = "exit";

            Dictionary<string, List<string>> positions = new Dictionary<string, List<string>>();
            List<string> allEmployees = new List<string>();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"\nВведите команду:");
                Console.WriteLine($"1. {AddDossierCommand} - добавить сотрудника");
                Console.WriteLine($"2. {PrintDossierCommand} - показать всех сотрудников");
                Console.WriteLine($"3. {DeleteDossierCommand} - удалить сотрудника");
                Console.WriteLine($"4. {ExitProgramCommand} - выход");
                Console.Write("\nВаша команда: ");

                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case AddDossierCommand:
                        AddEmployee(positions, allEmployees);
                        break;

                    case PrintDossierCommand:
                        PrintAllEmployees(positions);
                        break;

                    case DeleteDossierCommand:
                        DeleteEmployee(positions, allEmployees);
                        break;

                    case ExitProgramCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
        }

        static void AddEmployee(Dictionary<string, List<string>> positions, List<string> allEmployees)
        {
            Console.Write("Введите ФИО сотрудника: ");
            string fullName = Console.ReadLine();

            if (allEmployees.Contains(fullName))
            {
                Console.WriteLine("Сотрудник с таким ФИО уже существует!");
                return;
            }

            Console.Write("Введите название должности: ");
            string position = Console.ReadLine();

            if (!positions.ContainsKey(position))
            {
                positions[position] = new List<string>();
            }

            positions[position].Add(fullName);
            allEmployees.Add(fullName);

            Console.WriteLine("Сотрудник успешно добавлен!");
        }

        static void DeleteEmployee(Dictionary<string, List<string>> positions, List<string> allEmployees)
        {
            if (allEmployees.Count == 0)
            {
                Console.WriteLine("Список сотрудников пуст.");
                return;
            }

            Console.Write("Введите ФИО сотрудника для удаления: ");
            string fullName = Console.ReadLine();

            if (!allEmployees.Contains(fullName))
            {
                Console.WriteLine($"Сотрудник с ФИО '{fullName}' не найден!");
                return;
            }

            string positionToDelete = null;
            foreach (var position in positions)
            {
                if (position.Value.Contains(fullName))
                {
                    positionToDelete = position.Key;
                    break;
                }
            }

            if (positionToDelete != null)
            {
                positions[positionToDelete].Remove(fullName);
                allEmployees.Remove(fullName);

                if (positions[positionToDelete].Count == 0)
                {
                    positions.Remove(positionToDelete);
                    Console.WriteLine($"Должность '{positionToDelete}' удалена, так как на ней не осталось сотрудников.");
                }

                Console.WriteLine("Сотрудник успешно удален!");
            }
        }

        static void PrintAllEmployees(Dictionary<string, List<string>> positions)
        {
            if (positions.Count == 0)
            {
                Console.WriteLine("Список сотрудников пуст.");
                return;
            }

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("ШТАТНОЕ РАСПИСАНИЕ");
            Console.WriteLine(new string('=', 50));

            foreach (var position in positions)
            {
                Console.WriteLine($"\nДолжность: {position.Key}");
                Console.WriteLine("Сотрудники:");

                for (int i = 0; i < position.Value.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}. {position.Value[i]}");
                }
            }

            Console.WriteLine("\n" + new string('=', 50));

            int totalEmployees = 0;
            foreach (var position in positions)
            {
                totalEmployees += position.Value.Count;
            }
            Console.WriteLine($"Всего сотрудников: {totalEmployees}");
            Console.WriteLine($"Всего должностей: {positions.Count}");
        }
    }
}
