using System;
using System.Collections.Generic;
using System.Linq;

namespace testlinq1
{
    internal class Program
    {
        public class Customer
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }
        }

        public class Order
        {
            public int OrderId { get; set; }
            public int CustomerId { get; set; }
            public string ProductName { get; set; }
        }

        static void Main(string[] args)
        {
            
            List<Customer> customers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "Alice" },
                new Customer { CustomerId = 2, Name = "Bob" },
                new Customer { CustomerId = 3, Name = "Charlie" }
            };

           
            List<Order> orders = new List<Order>
            {
                new Order { OrderId = 1, CustomerId = 1, ProductName = "Apple" },
                new Order { OrderId = 2, CustomerId = 1, ProductName = "Banana" },
                new Order { OrderId = 3, CustomerId = 1, ProductName = "Orange" },
                new Order { OrderId = 4, CustomerId = 1, ProductName = "Grape" },
                new Order { OrderId = 5, CustomerId = 1, ProductName = "Pear" },

                new Order { OrderId = 6, CustomerId = 2, ProductName = "Carrot" },
                new Order { OrderId = 7, CustomerId = 2, ProductName = "Potato" },
                new Order { OrderId = 8, CustomerId = 2, ProductName = "Lettuce" },
                new Order { OrderId = 9, CustomerId = 2, ProductName = "Cucumber" },
                new Order { OrderId = 10, CustomerId = 2, ProductName = "Tomato" },

                new Order { OrderId = 11, CustomerId = 3, ProductName = "Chicken" },
                new Order { OrderId = 12, CustomerId = 3, ProductName = "Beef" },
                new Order { OrderId = 13, CustomerId = 3, ProductName = "Pork" },
                new Order { OrderId = 14, CustomerId = 3, ProductName = "Fish" },
                new Order { OrderId = 15, CustomerId = 3, ProductName = "Lamb" }
            };

            // GROUP JOIN, et grupeerida tellimusi iga kliendi järgi
            var groupedOrders = from customer in customers
                                join order in orders on customer.CustomerId equals order.CustomerId into customerOrders
                                select new
                                {
                                    CustomerName = customer.Name,   
                                    Orders = customerOrders         
                                };

            //seda kasutatakse kahe andmekogumi ühendamiseks ja nende rühmitamiseks 
            //peamine eesmärk on siduda kaks erinevat andmekogumit 
            foreach (var group in groupedOrders)
            {
                Console.WriteLine($"Customer: {group.CustomerName}");

               
                foreach (var order in group.Orders)
                {
                    Console.WriteLine($" - Order: {order.ProductName}");
                }
            }
        }
    }
}
