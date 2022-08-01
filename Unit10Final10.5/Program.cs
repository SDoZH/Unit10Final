using System;
using System.IO;


namespace Unit10Final10._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует I-Калькулятор");
            while (true)
            {
                ICalculator i = new Sumator();
                Console.Write("Введите число  a: ");
                int A;
                while (!int.TryParse(Console.ReadLine(), out A))
                    Console.Write("Вы ввели неверное значение \n" + "Введите a: ");

                Console.Write("Введите число b: ");
                int B;
                while (!int.TryParse(Console.ReadLine(), out B))
                    Console.Write("Вы ввели неверное значение \n" + "Введите b: ");
                try
                {
                    var C = i.Sum(A, B);
                    if (A == 0 && B == 0)
                        throw new MyExeptions("Сложение нулей");
                    if(A!=0 && B!=0)    
                    Console.WriteLine("{0}+{1}={2}", A, B, C);
                }
                catch (MyExeptions e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public interface ICalculator
        {
            int Sum(int a, int b);
        }

        public class Sumator : ICalculator
        {
            public int Sum(int a, int b)
            {
                int c = 0;
                while (true)
                {
                    try
                    {
                        c = a + b;
                    }
                    catch (MyExeptions e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    return c;
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
    }
}

