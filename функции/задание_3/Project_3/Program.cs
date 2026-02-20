using System;

class Program
{
    static void Main(string[] args)
    {
        int userNumber = GetNumberFromUser();
        Console.WriteLine($"Вы ввели число: {userNumber}");
    }

    static int GetNumberFromUser()
    {
        bool isParsingSuccessful = false;
        int number = 0;

        while (isParsingSuccessful == false)
        {
            Console.Write("Введите целое число: ");
            string userInput = Console.ReadLine();

            isParsingSuccessful = int.TryParse(userInput, out number);

            if (isParsingSuccessful == false)
            {
                Console.WriteLine("Ошибка! Введено некорректное число. Попробуйте снова.");
            }
        }

        return number;
    }
}
