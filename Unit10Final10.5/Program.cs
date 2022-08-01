using System;
using System.IO;


namespace Unit10Final10._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует I-Калькулятор");
            ILogger logger = new Calculator();
            Summator summator = new Summator(logger);
            while (true)
            {
                try
                {
                    Console.Write("Введите число  a: ");
                    int A;
                    while (!int.TryParse(Console.ReadLine(), out A))
                        Console.Write("Вы ввели неверное значение \n" + "Введите число a: ");

                    Console.Write("Введите число b: ");
                    int B;
                    while (!int.TryParse(Console.ReadLine(), out B))
                        Console.Write("Вы ввели неверное значение \n" + "Введите число b: ");
                    {
                        if (A == 0 && B == 0)
                            throw new MyExeptions("Сложение нулей бессмыслено");
                    }
                    int result = summator.CheckAndSum(A, B);
                    Console.WriteLine(result);
                }
                catch (MyExeptions ex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();

                }
            }

        }
        public class MyExeptions : ApplicationException
        {
            public string message;
            public MyExeptions(string message) : base(message)
            {
                this.message = message;
            }

        }
        internal class Summator : Calculator
        {
            ILogger logger;
            Calculator calc;
            public Summator(ILogger logger)
            {
                this.logger = logger;
                calc = new Calculator();
            }

            public int CheckAndSum(int a, int b)
            {

                if (a == 0 || b == 0)
                {
                    logger.Error("Прибавлять ноль смысла не имеет");
                    return calc.Sum(a, b);
                }
                logger.Event("Сумма чисел состовляет");
                return calc.Sum(a, b);
            }
        }
    }
}


