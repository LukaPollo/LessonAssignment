using System;
using System.Collections.Generic;
using System.IO;
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
            
            //Console.WriteLine(myLittleOrder.Id);
            //Console.WriteLine(myLittlePOrder.productId);
            //Console.WriteLine(myLittlePOrder.Id);

            //Console.WriteLine(second.Id);
            //Console.WriteLine(second.productId);

            //Console.WriteLine(third.name);
            //Console.WriteLine(third.price);

            //Console.WriteLine(CalcVat(third));
            //Console.WriteLine(CalcGross(third));

            //Console.WriteLine(CalcVat(fourth));
            //Console.WriteLine(fourth.name);
            //Console.WriteLine(CalcGross(fourth));

            string csvFolder = @"C:\Users\podluk956\Downloads\LessonAssignment\ConsoleApp1\csvFiles\";

            List<Address> addresses = CsvReaderService.ReadAddresses(Path.Combine(csvFolder, "Address.csv"));
            List<Cart> carts = CsvReaderService.ReadCarts(Path.Combine(csvFolder, "Cart.csv"));
            List<Delivery> deliveries = CsvReaderService.ReadDeliveries(Path.Combine(csvFolder, "Delivery.csv"));
            List<OrderClass> orders = CsvReaderService.ReadOrders(Path.Combine(csvFolder, "Orders.csv"));
            List<Payment> payments = CsvReaderService.ReadPayments(Path.Combine(csvFolder, "Payment.csv"));
            List<ProductOrder> products = CsvReaderService.ReadProducts(Path.Combine(csvFolder, "Product.csv"));
            List<ServiceOrder> services = CsvReaderService.ReadServices(Path.Combine(csvFolder, "Service.csv"));
            List<Users> users = CsvReaderService.ReadUsers(Path.Combine(csvFolder, "Users.csv"));

            string dbPath = "server=localhost;port=3307;database=webaruhaz;uid=root";

            /*
             SELECT UserId, COUNT(UserId) AS db FROM `orders`
             GROUP BY UserId
             ORDER BY COUNT(UserId) DESC;
             */
            AddictedUser addictedUser = new AddictedUser();


            Database.DatabaseConn(dbPath, users, products, services, addresses, orders, deliveries, payments, carts, addictedUser);
            Console.WriteLine(addictedUser.UserId);
            Console.WriteLine(addictedUser.OrderCount);
            Console.ReadKey();

        }
    }
}