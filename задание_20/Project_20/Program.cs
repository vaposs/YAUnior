using System;

namespace Project_20
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("введите строку для проверки - ");
                string stringValidation = Console.ReadLine();

                Array str = new Array[stringValidation.Length];

                for (int i = 0; i < stringValidation.Length; i ++)
                {
                    str[i] = stringValidation[0];
                }                
            }
        }
    }
}
