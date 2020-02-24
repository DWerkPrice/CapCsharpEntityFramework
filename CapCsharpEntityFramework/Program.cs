using System;
using System.Linq;
using CapCSharpEFLibrary;
using CapCSharpEFLibrary.Models;

namespace CapCsharpEntityFramework
{
    class Program {
        static void Main(string[] args) {
            var context = new AppDbContext();
            var top2 = context.Products.Where(x => x.Id > 3).ToList();
            var actCust = context.Customers.Where(x => x.Active).ToList();// is same as (x=>x.Active = true) that a rookie would use

            //    AddCustomer(context);
            //    GetCustomerByPk(context);
            //          UpdateCustomer(context);
            //           DeleteCustomer(context);
            //          GetAllCustomers(context);
            //AddOrders(context);
            //          UpdateCustomerSales(context);
            //AddProducts(context);
            Console.WriteLine($"Avg price is {context.Products.Average(x => x.Price)}");
        }

        static void UpdateCustomer(AppDbContext context) {
            var custPk = 4;
            var cust = context.Customers.Find(custPk);
            if (cust == null) throw new Exception("Customer not found");
            cust.Name = "Microsoft";
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("failed to update customer");
            Console.WriteLine("Update Successful");
        }
        static void DeleteCustomer(AppDbContext context) {
            var keyToDelete = 1;
            var cust = context.Customers.Find(keyToDelete);
            if (cust == null) throw new Exception("Customer not found");
            context.Customers.Remove(cust);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("delete failed");
        }
        static void GetCustomerByPk(AppDbContext context) {
            var custPk = 3;
            var cust = context.Customers.Find(custPk);  // find is command to use when looking for data by primary key
            if (cust == null) { throw new Exception("Customer not found");// checks to make sure we customer with pk exists
            }
            Console.WriteLine(cust);

        }

        static void GetAllCustomers(AppDbContext context) {
            var custs = context.Customers.ToList();
            foreach (var c in custs) {
                Console.WriteLine(c);  // have to install public override in customer.cs for this to work
            }
        }

        static void AddCustomer(AppDbContext context) {
            var cust = new Customer {
                Id = 0 ,
                Name = "Amazon" ,
                Sales = 0 ,
                Active = true
            };
            context.Customers.Add(cust);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Add failed!");
            return;
        }
        static void UpdateCustomerSales(AppDbContext context) {
            var CustOrderJoin = from c in context.Customers
                                join o in context.Orders
                                on c.Id equals o.CustomerId
                                where c.Id == 2
                                select new {
                                    Amount = o.Amount ,
                                    Customer = c.Name ,
                                    Order = o.Description
                                };
            var orderTotal = CustOrderJoin.Sum(c=> c.Amount);
            var cust = context.Customers.Find(2);
            cust.Sales = orderTotal;
            context.SaveChanges();
        }


            static void AddOrders(AppDbContext context) {

                var order1 = new Order { Id = 0 , Description = "Order 1" , Amount = 100 , CustomerId = 2 };
                var order2 = new Order { Id = 0 , Description = "Order 2" , Amount = 200 , CustomerId = 2 };
                var order3 = new Order { Id = 0 , Description = "Order 3" , Amount = 400 , CustomerId = 2 };
                var order4 = new Order { Id = 0 , Description = "Order 4" , Amount = 600 , CustomerId = 2 };
                var order5 = new Order { Id = 0 , Description = "Order 5" , Amount = 800 , CustomerId = 2 };

                context.AddRange(order1 , order2 , order3 , order4 , order5);

                var rowsAffected = context.SaveChanges();
                if (rowsAffected != 5) throw new Exception("Five order did not add!");
                Console.WriteLine("added 5 orders");
            }
        static void AddProducts(AppDbContext context) {

            var Product1 = new Product { Id = 0 , Name = "product 1" , Code = "103", Price = 10 };
            var Product2 = new Product { Id = 0 , Name = "product 2" , Code = "20 " , Price = 20 };
            var Product3 = new Product { Id = 0 , Name = "product 3" , Code = "30 " , Price = 30 };
            var Product4 = new Product { Id = 0 , Name = "product 4" , Code = "40 " , Price = 40 };
            var Product5 = new Product { Id = 0 , Name = "product 5" , Code = "50 " , Price = 50 };

            context.AddRange(Product1 , Product2 , Product3 , Product4 , Product5);

            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 5) throw new Exception("Five products did not add!");
            Console.WriteLine("added 5 products");
        }


    }
    }
