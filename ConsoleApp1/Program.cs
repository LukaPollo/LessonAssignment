using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using MySqlX.XDevAPI;

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


            string addresscsv = "C:\\Users\\podluk956\\source\\repos\\ConsoleApp1\\ConsoleApp1\\csvFiles\\Address.csv";
            string cartcsv = "C:\\Users\\podluk956\\source\\repos\\ConsoleApp1\\ConsoleApp1\\csvFiles\\Cart.csv";
            string deliverycsv = "C:\\Users\\podluk956\\source\\repos\\ConsoleApp1\\ConsoleApp1\\csvFiles\\Delivery.csv";
            string orderscsv = "C:\\Users\\podluk956\\source\\repos\\ConsoleApp1\\ConsoleApp1\\csvFiles\\Orders.csv";
            string paymentcsv = "C:\\Users\\podluk956\\source\\repos\\ConsoleApp1\\ConsoleApp1\\csvFiles\\Payment.csv";
            string servicecsv = "C:\\Users\\podluk956\\source\\repos\\ConsoleApp1\\ConsoleApp1\\csvFiles\\Service.csv";
            string userscsv = "C:\\Users\\podluk956\\source\\repos\\ConsoleApp1\\ConsoleApp1\\csvFiles\\Users.csv";

            List<Address> addresses = CsvReaderService.ReadCsv<Address>(addresscsv);
            List<Cart> carts = CsvReaderService.ReadCsv<Cart>(cartcsv);
            List<Delivery> deliveries = CsvReaderService.ReadCsv<Delivery>(deliverycsv);   
            List<OrderClass> orders = CsvReaderService.ReadCsv<OrderClass>(orderscsv);
            List<Payment> payments = CsvReaderService.ReadCsv<Payment>(paymentcsv);
            List<ServiceOrder> serivces = CsvReaderService.ReadCsv<ServiceOrder>(servicecsv);
            List<Users> users = CsvReaderService.ReadCsv<Users>(userscsv);

            Console.WriteLine(string.Join(", ", addresses));
            Console.WriteLine(string.Join (", ", carts));   
            Console.WriteLine(string.Join(", ", deliveries));
            Console.WriteLine(string.Join(", ", orders));
            Console.WriteLine(string.Join(", ", payments));
            Console.WriteLine(string.Join(", ", serivces));
            Console.WriteLine(string.Join(", ", users));
            Console.ReadKey();

            string dbPath = "server=localhost;port=3307;database=webaruhaz;uid=root";
            Database.DatabaseConn(dbPath);
        }
    }
}
