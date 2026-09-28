using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp1
{
    internal class Program
    {
        public const float VAT = 0.27f; 
        public static decimal CalcVat(Iorder order)
        {
            return order.price * (decimal)VAT;
        }

        public static decimal CalcGross(Iorder order)
        {
            return order.price + CalcVat(order);
        }
        
        static void Main(string[] args)
        {      
            var myLittleOrder = new OrderClass(3);
            var myLittlePOrder = new ProductOrder(4, 6, 5765675764543, "termek");
            var myLittleSOrder = new ServiceOrder(5, 1000, "szolgaltatas");

            var second = (IproductOrder)myLittlePOrder;
            var third = (Iorder)myLittlePOrder;
            var fourth = (Iorder)myLittleSOrder;


            Console.WriteLine(myLittleOrder.Id);
            Console.WriteLine(myLittlePOrder.productId);
            Console.WriteLine(myLittlePOrder.Id);

            Console.WriteLine(second.Id);
            Console.WriteLine(second.productId);

            Console.WriteLine(third.name);
            Console.WriteLine(third.price);

            Console.WriteLine(CalcVat(third));
            Console.WriteLine(CalcGross(third));

            Console.WriteLine(CalcVat(fourth));
            Console.WriteLine(fourth.name);
            Console.WriteLine(CalcGross(fourth));

            Console.ReadKey();

            string dbPath = "server=localhost;port=3307;database=webaruhaz;uid=root";
            Database.DatabaseConn(dbPath);
        }
    }
}
