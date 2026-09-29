using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /*
    var myLittleOrder = new OrderClass();
    myLittleOrder.Id = 3
    */

    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string AddressType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
    }
    public class OrderClass
    {
        private int id; // Field 
        // Default value of int is -1 
        // public int id {get;set;} = 0
        public int Id { get { return id; } set { id = value; } } // Property

        public OrderClass(int id)
        {
            this.id = id;
        }
    }
    public class ProductOrder : OrderClass, IproductOrder, Iorder
    {
        private int productid;
        private decimal price2;
        public int productId { get { return productid; } set { productid = value; } }


        public decimal price{ get { return price2; } set { price2 = value; }}
        public string name { get; set; }


        public ProductOrder(int oid, int pid, decimal price, string name) : base(oid)
        {
            this.productId = pid;
            this.price = price;
            this.name = name;
        }
    }


    public class ServiceOrder : Iorder
    {
        private decimal price2;
        public decimal price { get { return price2; } set { price2 = value; } }
        public string name { get; set; }
        public ServiceOrder(int oid, decimal price, string name)
        {
            this.price = price;
            this.name = name;
        }
    }

    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int OrderId { get; set; }
        public string DeliveryStatus { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
    }

    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ServiceId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }

    }
    


}
