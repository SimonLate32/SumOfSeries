using System;

namespace SumOfSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число х, принадлежащее интервалу (-1;1): "); //Вводим х
            double x = Convert.ToDouble(Console.ReadLine());
            while (x > 1 | x < (-1)) //Проверяем, принадлежит ли х указанному интервалу
            {
                Console.Write("Введите число х, принадлежащее интервалу (-1;1): ");
                x = Convert.ToDouble(Console.ReadLine());
            }
            Console.Write("Введите число слагаемых: "); //Ввод n числа слагаемых
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число E: "); //Ввод эпсилона(точность)
            double e = Convert.ToDouble(Console.ReadLine());
            double SumOfSeries = 0; //Сумма ряда
            double Member = x; //Обозначение члена последовательности 
            
            bool GoToN = true; //Логическая переменная для суммы ряда н
            bool GoToE = true; //Логическая переменная для суммы ряда членов меньше е
            bool GoToE10 = true; //Логическая переменная для суммы ряда членов меньше 1/10
            int k = 0; //номер члена последовательности
            
            while (GoToN | GoToE | GoToE10)
            {
                SumOfSeries += Member;
                k++;
                Member *= Math.Pow(x, 2) * Math.Pow(k - 0.5, 2) / (k * (k + 0.5)); //Выражаем последующий член последовательности через предыдущий              
                if (k == n)
                {
                    GoToN = !GoToN;
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    Console.WriteLine($"Сумма {n} членов последовательности: {SumOfSeries}");             
                }
                if (GoToE)
                {
                    if (Math.Abs(Member) < e) //Вывод суммы членов больших е
                    {
                        Console.WriteLine($"Сумма слагаемых, которые больше {e}: {SumOfSeries}");
                        GoToE = !GoToE;
                    }
                }
                if (GoToE10)
                {
                    if (Math.Abs(Member) < e / 10) //Вывод суммы членов больших е/10
                    {
                        GoToE10 = !GoToE10;
                        Console.WriteLine($"Сумма слагаемых, которые больше E/10: {SumOfSeries}");
                    }
                }
            }
            double result = Math.Asin(x); //Вычисляем значение для х
            Console.WriteLine($"Значение x при {x}: {result}");
            Console.WriteLine("----------------------------------------------------------------------------------");
        }
    }
}