using System;

namespace Project_7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string line = "Таким образом, сложившаяся структура организации обеспечивает широкому кругу специалистов участие в формировании системы обучения кадров, соответствующей насущным потребностям? ";

            string[] miniLine = line.Split(' ');

            foreach (string word in miniLine)
            {
                Console.WriteLine(word);
            }
        }
    }
}
