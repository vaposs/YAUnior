using System;
using System.Collections.Generic;

namespace Projekt_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string tempKey;
            string tempValue;
            bool collectionChanged = true;

            Dictionary<string, string> dosser = new Dictionary<string, string>();
            

            while (true)
            {
                tempKey = TextInput();
                foreach (var dos in dosser)
                {
                    if (dos.Key == tempKey)
                    {
                        Console.Write($"{dos.Key} - {dos.Value}");
                        collectionChanged = true;
                        break;
                    }
                    else
                    {
                        collectionChanged = false;
                    }
                }
                if (collectionChanged == false)
                {
                    collectionChanged = true; ;
                    Console.WriteLine("Такого слова нет, введите значение - ");

                    tempValue = TextInput();
                    dosser.Add(tempKey, tempValue);
                    Console.WriteLine("");


                }
                foreach (var cu in dosser)
                {
                    Console.WriteLine($"{cu.Key} - {cu.Value}");
                }
            }
        }

        static string TextInput()
        {
            string word;

            Console.Write("введите слово - ");
            word = Console.ReadLine();
            return word;
        }
    }
}
