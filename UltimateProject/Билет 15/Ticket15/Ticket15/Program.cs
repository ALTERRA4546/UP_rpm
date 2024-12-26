using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket15
{
    internal class Program
    {
        /*public static void CalculateAndPrintPrice(decimal price, int quantity, decimal discountPercentage)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Количество должно быть больше нуля.");
                return;
            }
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                Console.WriteLine("Скидка должна быть от 0 до 100%.");
                return;
            }
            decimal totalPrice = price * quantity;
            if (discountPercentage > 0)
            {
                decimal discountAmount = totalPrice * (discountPercentage / 100);
                totalPrice -= discountAmount;
            }
            Console.WriteLine($"Итоговая цена: {totalPrice}");
            Console.ReadKey();
        }
        public static void Main(string[] args)
        {
            CalculateAndPrintPrice(100, 2, 10);      // Output: Итоговая цена: 180        CalculateAndPrintPrice(50, 0, 5);       // Output: Количество должно быть больше нуля.        CalculateAndPrintPrice(25, 3, 120);     // Output: Скидка должна быть от 0 до 100%.        CalculateAndPrintPrice(75, 1, 0);       // Output: Итоговая цена: 75    }}
        }*/

        public decimal CalculateTotalPrice(decimal price, int quantity, decimal discountPercentage)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Количество должно быть больше нуля.");
            }

            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Скидка должна быть от 0 до 100%.");
            }

            decimal totalPrice = price * quantity;
            if (discountPercentage > 0)
            {
                decimal discountAmount = totalPrice * (discountPercentage / 100);
                totalPrice -= discountAmount;
            }

            return totalPrice;
        }

        public static void Main(string[] args)
        {
            var priceCalculatorService = new Program();

            CalculateAndPrintPrice(priceCalculatorService, 100, 2, 10);
            CalculateAndPrintPrice(priceCalculatorService, 50, 0, 5);
            CalculateAndPrintPrice(priceCalculatorService, 25, 3, 120);
            CalculateAndPrintPrice(priceCalculatorService, 75, 1, 0);
            Console.ReadKey();
        }

        private static void CalculateAndPrintPrice(Program service, decimal price, int quantity, decimal discountPercentage)
        {
            try
            {
                decimal totalPrice = service.CalculateTotalPrice(price, quantity, discountPercentage);
                Console.WriteLine($"Итоговая цена: {totalPrice}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
