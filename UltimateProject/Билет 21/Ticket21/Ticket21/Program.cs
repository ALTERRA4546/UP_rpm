using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket21
{
    internal class Program
    {
        /*public static void Main()
        {
            List<int> numbers = new List<int>(); 
            for (int i = 0; i < 1000000; i++) 
            {
                numbers.Add(i);
            } 
            // Находим максимальное число
            int max = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }        
            // Вычисляем сумму четных чисел
            int sum = 0;
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    sum += number;
                }
            }  
            Console.WriteLine("Максимальное число: " + max);
            Console.WriteLine("Сумма четных чисел: " + sum);
            Console.ReadKey();
        }*/

        public static void Main()
        {
            List<int> numbers = Enumerable.Range(0, 1000000).ToList();
            int max = numbers.Max();
            long sum = numbers.Where(number => number % 2 == 0).Sum(n => (long)n);

            Console.WriteLine("Максимальное число: " + max);
            Console.ReadKey();
        }
    }
}
