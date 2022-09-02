using System;

namespace Project_11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool isActive = true;
            int numberOfIterations = 0;
            int conditionDigit = 7;
            int divisionRemainder = 5;
            int maxDigit = 100;

            Console.WriteLine($"Будем выводить числа с остатком от деления '{divisionRemainder}' и меньше чем '{maxDigit}'.");
            Console.WriteLine("Нажмите Enter для старта.");
            Console.WriteLine("Продолжить . . .");
            Console.ReadLine();

            while(isActive)
            {
                numberOfIterations++;
                if ((numberOfIterations%conditionDigit == divisionRemainder)&&(numberOfIterations < maxDigit))
                {
                    Console.WriteLine($" Число - {numberOfIterations} ");
                }
                if(numberOfIterations > 100)
                {
                    Console.WriteLine("Вывод чисел закончен.");
                    isActive = false;
                }
            }


        }
    }
}
