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
                        AddEmployee(positions);
                        break;

                    case PrintDossierCommand:
                        PrintAllEmployees(positions);
                        break;

                    case DeleteDossierCommand:
                        DeleteEmployee(positions);
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

        static void AddEmployee(Dictionary<string, List<string>> positions)
        {
            Console.Write("Введите ФИО сотрудника: ");
            string fullName = Console.ReadLine();

            bool employeeExists = false;
            string existingPosition = null;

            foreach (var employeePosition in positions)
            {
                if (employeePosition.Value.Contains(fullName))
                {
                    employeeExists = true;
                    existingPosition = employeePosition.Key;
                    break;
                }
            }

            if (employeeExists == true)
            {
                Console.WriteLine($"Сотрудник с таким ФИО уже существует на должности '{existingPosition}'!");
                return;
            }

            Console.Write("Введите название должности: ");
            string position = Console.ReadLine();

            if (positions.ContainsKey(position) == false)
            {
                positions[position] = new List<string>();
            }

            positions[position].Add(fullName);

            Console.WriteLine("Сотрудник успешно добавлен!");
        }

        static void DeleteEmployee(Dictionary<string, List<string>> positions)
        {
            if (positions.Count == 0)
            {
                Console.WriteLine("Список сотрудников пуст.");
                return;
            }

            Console.Write("Введите должность сотрудника: ");
            string targetPosition = Console.ReadLine();

            if (positions.ContainsKey(targetPosition) == false)
            {
                Console.WriteLine($"Должность '{targetPosition}' не найдена!");
                return;
            }

            List<string> employeesOnPosition = positions[targetPosition];

            if (employeesOnPosition.Count == 0)
            {
                Console.WriteLine("На этой должности нет сотрудников.");
                return;
            }

            Console.WriteLine($"\nСотрудники на должности '{targetPosition}':");
            for (int i = 0; i < employeesOnPosition.Count; i++)
            {
                Console.WriteLine($"{i}. {employeesOnPosition[i]}");
            }

            Console.Write("\nВведите индекс сотрудника для удаления: ");
            string input = Console.ReadLine();
            int index;

            if (int.TryParse(input, out index) == false)
            {
                Console.WriteLine("Ошибка: введите число!");
                return;
            }

            if (index < 0 || index >= employeesOnPosition.Count)
            {
                Console.WriteLine("Ошибка: индекс вне диапазона!");
                return;
            }

            string deletedEmployee = employeesOnPosition[index];
            employeesOnPosition.RemoveAt(index);

            Console.WriteLine($"Сотрудник '{deletedEmployee}' успешно удален!");

            if (employeesOnPosition.Count == 0)
            {
                positions.Remove(targetPosition);
                Console.WriteLine($"Должность '{targetPosition}' удалена, так как на ней не осталось сотрудников.");
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
