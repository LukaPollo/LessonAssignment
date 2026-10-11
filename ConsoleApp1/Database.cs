using ClassLibrary1;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Database
    {
        public static void DatabaseConn(string connection, List<Users> users, List<ProductOrder> products, List<ServiceOrder> services, List<Address> addresses, List<OrderClass> orders, List<Delivery> deliveries, List<Payment> payments, List<Cart> carts)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                Console.WriteLine("Connection to the database successful.");
                string createUsers = "CREATE TABLE IF NOT EXISTS users (UserId INT PRIMARY KEY, Username VARCHAR(255), UserEmail VARCHAR(255), UserPassword VARCHAR(255))";
                string createProduct = "CREATE TABLE IF NOT EXISTS product (ProductId INT PRIMARY KEY, ProductPrice DECIMAL(10,0), ProductName VARCHAR(255))";
                string createService = "CREATE TABLE IF NOT EXISTS service (ServiceId INT PRIMARY KEY, ServicePrice DECIMAL(10,0), ServiceName VARCHAR(255))";
                string createAddress = "CREATE TABLE IF NOT EXISTS address (AddressId INT PRIMARY KEY, UserId INT, Address_Type ENUM('billing','homeaddress'), Country VARCHAR(255), City VARCHAR(255), PostalCode VARCHAR(255), StreetName VARCHAR(255), Building VARCHAR(255), Floor INT, Door INT, FOREIGN KEY (UserId) REFERENCES users(UserId))";
                string createOrders = "CREATE TABLE IF NOT EXISTS orders (OrderId INT PRIMARY KEY, UserId INT, OrderDate DATE, TotalAmount DECIMAL(10,0), AddressId INT, FOREIGN KEY (UserId) REFERENCES users(UserId), FOREIGN KEY (AddressId) REFERENCES address(AddressId))";
                string createDelivery = "CREATE TABLE IF NOT EXISTS delivery (DeliveryId INT PRIMARY KEY, OrderId INT, DeliveryStatus VARCHAR(255), TrackingNumber VARCHAR(255), EstimatedArrival DATE, FOREIGN KEY (OrderId) REFERENCES orders(OrderId))";
                string createPayment = "CREATE TABLE IF NOT EXISTS payment (PaymentId INT PRIMARY KEY, OrderId INT, PaymentDate DATE, PaymentMethod VARCHAR(255), PaymentStatus VARCHAR(255), Amount DECIMAL(10,0), FOREIGN KEY (OrderId) REFERENCES orders(OrderId))";
                string createCart = "CREATE TABLE IF NOT EXISTS cart (CartId INT PRIMARY KEY, UserId INT, ProductId INT NULL, ServiceId INT NULL, Quantity INT, AddedDate DATE, FOREIGN KEY (UserId) REFERENCES users(UserId), FOREIGN KEY (ProductId) REFERENCES product(ProductId), FOREIGN KEY (ServiceId) REFERENCES service(ServiceId))";

                using (MySqlCommand cmd = new MySqlCommand(createUsers, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(createProduct, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(createService, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(createAddress, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(createOrders, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(createDelivery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(createPayment, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(createCart, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    string dataLoadUsers = "INSERT INTO users (UserId, Username, UserEmail, UserPassword) VALUES (@UserId, @Username, @UserEmail, @UserPassword)";
                    string dataLoadProduct = "INSERT INTO product (ProductId, ProductPrice, ProductName) VALUES (@ProductId, @ProductPrice, @ProductName)";
                    string dataLoadService = "INSERT INTO service (ServiceId, ServicePrice, ServiceName) VALUES (@ServiceId, @ServicePrice, @ServiceName)";
                    string dataLoadAddress = "INSERT INTO address (AddressId, UserId, Address_Type, Country, City, PostalCode, StreetName, Building, Floor, Door) VALUES (@AddressId, @UserId, @Address_Type, @Country, @City, @PostalCode, @StreetName, @Building, @Floor, @Door)";
                    string dataLoadOrders = "INSERT INTO orders (OrderId, UserId, OrderDate, TotalAmount, AddressId) VALUES (@OrderId, @UserId, @OrderDate, @TotalAmount, @AddressId)";
                    string dataLoadDelivery = "INSERT INTO delivery (DeliveryId, OrderId, DeliveryStatus, TrackingNumber, EstimatedArrival) VALUES (@DeliveryId, @OrderId, @DeliveryStatus, @TrackingNumber, @EstimatedArrival)";
                    string dataLoadPayment = "INSERT INTO payment (PaymentId, OrderId, PaymentMethod, PaymentStatus, Amount, PaymentDate) VALUES (@PaymentId, @OrderId, @PaymentMethod, @PaymentStatus, @Amount, @PaymentDate)";
                    string dataLoadCart = "INSERT INTO cart (CartId, UserId, ProductId, ServiceId, Quantity, AddedDate) VALUES (@CartId, @UserId, @ProductId, @ServiceId, @Quantity, @AddedDate)";
                    //
                    // USERS
                    //
                    using (MySqlCommand cmd = new MySqlCommand(dataLoadUsers, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add("@UserId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@Username", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@UserEmail", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@UserPassword", MySqlDbType.VarChar);

                        foreach (var user in users)
                        {
                            cmd.Parameters["@UserId"].Value = user.UserId;
                            cmd.Parameters["@Username"].Value = user.Username;
                            cmd.Parameters["@UserEmail"].Value = user.UserEmail;
                            cmd.Parameters["@UserPassword"].Value = user.UserPassword;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //
                    // PRODUCTS
                    //
                    using (MySqlCommand cmd = new MySqlCommand(dataLoadProduct, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add("@ProductId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@ProductPrice", MySqlDbType.Decimal);
                        cmd.Parameters.Add("@ProductName", MySqlDbType.VarChar);

                        foreach (var product in products)
                        {
                            cmd.Parameters["@ProductId"].Value = product.productId;
                            cmd.Parameters["@ProductPrice"].Value = product.price;
                            cmd.Parameters["@ProductName"].Value = product.name;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //
                    // SERVICES
                    //
                    using (MySqlCommand cmd = new MySqlCommand(dataLoadService, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add("@ServiceId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@ServicePrice", MySqlDbType.Decimal);
                        cmd.Parameters.Add("@ServiceName", MySqlDbType.VarChar);

                        foreach (var service in services)
                        {
                            cmd.Parameters["@ServiceId"].Value = service.ServiceId;
                            cmd.Parameters["@ServicePrice"].Value = service.price;
                            cmd.Parameters["@ServiceName"].Value = service.name;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //
                    // ADDRESS
                    //
                    using (MySqlCommand cmd = new MySqlCommand(dataLoadAddress, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add("@AddressId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@UserId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@Address_Type", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@Country", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@City", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@PostalCode", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@StreetName", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@Building", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@Floor", MySqlDbType.Int32);
                        cmd.Parameters.Add("@Door", MySqlDbType.Int32);

                        foreach (var address in addresses)
                        {
                            cmd.Parameters["@AddressId"].Value = address.AddressId;
                            cmd.Parameters["@UserId"].Value = address.UserId;
                            cmd.Parameters["@Address_Type"].Value = address.AddressType;
                            cmd.Parameters["@Country"].Value = address.Country;
                            cmd.Parameters["@City"].Value = address.City;
                            cmd.Parameters["@PostalCode"].Value = address.PostalCode;
                            cmd.Parameters["@StreetName"].Value = address.Street;
                            cmd.Parameters["@Building"].Value = address.Building;
                            cmd.Parameters["@Floor"].Value = address.Floor;
                            cmd.Parameters["@Door"].Value = address.Door;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //
                    // ORDERS
                    //
                    using (MySqlCommand cmd = new MySqlCommand(dataLoadOrders, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add("@OrderId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@UserId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@OrderDate", MySqlDbType.Date);
                        cmd.Parameters.Add("@TotalAmount", MySqlDbType.Decimal);
                        cmd.Parameters.Add("@AddressId", MySqlDbType.Int32);

                        foreach (var order in orders)
                        {
                            cmd.Parameters["@OrderId"].Value = order.Id;
                            cmd.Parameters["@UserId"].Value = order.UserId;
                            cmd.Parameters["@OrderDate"].Value = order.OrderDate;
                            cmd.Parameters["@TotalAmount"].Value = order.TotalAmount;
                            cmd.Parameters["@AddressId"].Value = order.AddressId;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //
                    // DELIVERIES
                    //
                    using (MySqlCommand cmd = new MySqlCommand(dataLoadDelivery, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add("@DeliveryId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@OrderId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@DeliveryStatus", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@TrackingNumber", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@EstimatedArrival", MySqlDbType.Date);

                        foreach (var delivery in deliveries)
                        {
                            cmd.Parameters["@DeliveryId"].Value = delivery.DeliveryId;
                            cmd.Parameters["@OrderId"].Value = delivery.OrderId;
                            cmd.Parameters["@DeliveryStatus"].Value = delivery.DeliveryStatus;
                            cmd.Parameters["@TrackingNumber"].Value = delivery.TrackingNumber;
                            cmd.Parameters["@EstimatedArrival"].Value = delivery.EstimatedArrival;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //
                    // PAYMENT
                    //
                    using (MySqlCommand cmd = new MySqlCommand(dataLoadPayment, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add("@PaymentId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@OrderId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@PaymentMethod", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@PaymentStatus", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@Amount", MySqlDbType.Decimal);
                        cmd.Parameters.Add("@PaymentDate", MySqlDbType.Date);

                        foreach (var payment in payments)
                        {
                            cmd.Parameters["@PaymentId"].Value = payment.PaymentId;
                            cmd.Parameters["@OrderId"].Value = payment.OrderId;
                            cmd.Parameters["@PaymentMethod"].Value = payment.PaymentMethod;
                            cmd.Parameters["@PaymentStatus"].Value = payment.PaymentStatus;
                            cmd.Parameters["@Amount"].Value = payment.Amount;
                            cmd.Parameters["@PaymentDate"].Value = payment.PaymentDate;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //
                    // CART
                    //
                    using (MySqlCommand cmd = new MySqlCommand(dataLoadCart, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add("@CartId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@UserId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@ProductId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@ServiceId", MySqlDbType.Int32);
                        cmd.Parameters.Add("@Quantity", MySqlDbType.Int32);
                        cmd.Parameters.Add("@AddedDate", MySqlDbType.Date);

                        foreach (var cart in carts)
                        {
                            cmd.Parameters["@CartId"].Value = cart.CartId;
                            cmd.Parameters["@UserId"].Value = cart.UserId;
                            cmd.Parameters["@ProductId"].Value = (object)cart.ProductId;
                            cmd.Parameters["@ServiceId"].Value = (object)cart.ServiceId;
                            cmd.Parameters["@Quantity"].Value = cart.Quantity;
                            cmd.Parameters["@AddedDate"].Value = cart.AddedDate;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    Console.WriteLine("Data inserted successfully.");
                    Console.ReadKey();
                }
            }
        }
    }
}