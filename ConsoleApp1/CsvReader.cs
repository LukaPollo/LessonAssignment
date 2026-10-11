using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ClassLibrary1;

namespace ConsoleApp1
{
    public static class CsvReaderService
    {
        public static List<Users> ReadUsers(string filePath)
        {
            List<Users> users = new List<Users>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    string[] data = line.Split(';');

                    users.Add(new Users
                    {
                        UserId = int.Parse(data[0]),
                        Username = data[1],
                        UserEmail = data[2],
                        UserPassword = data[3]
                    });
                }
            }

            return users;
        }

        public static List<ProductOrder> ReadProducts(string filePath)
        {
            List<ProductOrder> products = new List<ProductOrder>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); 
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] data = line.Split(';');

                    int productId = int.Parse(data[0]);
                    decimal productPrice = decimal.Parse(data[1], CultureInfo.InvariantCulture);
                    string productName = data[2];
                    products.Add(
                        new ProductOrder(
                            0, //kell orderid
                            productId,
                            productPrice,
                            productName
                        )
                    );
                }
            }
            return products;
        }

        public static List<ServiceOrder> ReadServices(string filePath)
        {
            List<ServiceOrder> services = new List<ServiceOrder>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); 

                string line;
                while ((line = reader.ReadLine()) != null) // != mert boolerteknek kene lennie
                {
                    string[] data = line.Split(';');

                    services.Add(
                        new ServiceOrder(
                            int.Parse(data[0]),
                            decimal.Parse(data[1], CultureInfo.InvariantCulture),
                            data[2]
                        )
                    );
                }
            }

            return services;
        }

        public static List<Address> ReadAddresses(string filePath)
        {
            List<Address> addresses = new List<Address>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    addresses.Add(new Address
                    {
                        AddressId = int.Parse(data[0]),
                        UserId = int.Parse(data[1]),
                        AddressType = data[2],
                        Country = data[3],
                        City = data[4],
                        PostalCode = data[5],
                        Street = data[6],
                        Building = data[7],
                        Floor = int.Parse(data[8]),
                        Door = int.Parse(data[9])
                    });
                }
            }
            return addresses;
        }

        public static List<OrderClass> ReadOrders(string filePath)
        {
            List<OrderClass> orders = new List<OrderClass>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); 

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] data = line.Split(';');

                    orders.Add(
                        new OrderClass(
                            int.Parse(data[0]),
                            int.Parse(data[1]),
                            DateTime.Parse(data[2], CultureInfo.InvariantCulture),
                            decimal.Parse(data[3], CultureInfo.InvariantCulture),
                            int.Parse(data[4])
                        )
                    );
                }
            }

            return orders;
        }

        public static List<Delivery> ReadDeliveries(string filePath)
        {
            List<Delivery> deliveries = new List<Delivery>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); 

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] data = line.Split(';');

                    deliveries.Add(new Delivery
                    {
                        DeliveryId = int.Parse(data[0]),
                        OrderId = int.Parse(data[1]),
                        DeliveryStatus = data[2],
                        TrackingNumber = data[3],
                        EstimatedArrival = DateTime.Parse(data[4], CultureInfo.InvariantCulture)
                    });
                }
            }

            return deliveries;
        }

        public static List<Payment> ReadPayments(string filePath)
        {
            List<Payment> payments = new List<Payment>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); 

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] data = line.Split(';');

                    payments.Add(new Payment
                    {
                        PaymentId = int.Parse(data[0]),
                        OrderId = int.Parse(data[1]),
                        PaymentDate = DateTime.Parse(data[2], CultureInfo.InvariantCulture),
                        PaymentMethod = data[3],
                        PaymentStatus = data[4],
                        Amount = decimal.Parse(data[5], CultureInfo.InvariantCulture)
                    });
                }
            }

            return payments;
        }

        public static List<Cart> ReadCarts(string filePath)
        {
            List<Cart> carts = new List<Cart>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); 

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    int? productId; //? = lehet null is 

                    if (string.IsNullOrWhiteSpace(data[2]))
                    {
                        productId = null;
                    }
                    else
                    {
                        productId = int.Parse(data[2]);
                    }

                    int? serviceId;

                    if (string.IsNullOrWhiteSpace(data[3]))
                    {
                        serviceId = null;
                    }
                    else
                    {
                        serviceId = int.Parse(data[3]);
                    }
                    carts.Add(new Cart
                    {
                        CartId = int.Parse(data[0]),
                        UserId = int.Parse(data[1]),
                        ProductId = productId,
                        ServiceId = serviceId,
                        Quantity = int.Parse(data[4]),
                        AddedDate = DateTime.Parse(data[5], CultureInfo.InvariantCulture)
                    });
                }
            }
            return carts;
        }
    }
}