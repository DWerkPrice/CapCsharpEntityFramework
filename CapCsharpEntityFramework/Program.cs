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
            //Console.WriteLine($"Avg price is {context.Products.Average(x => x.Price)}");
            //AddOrderLine(context);
            //GetOrderLines(context);

        }

        
        static void AddOrderLine(AppDbContext context){

            /*          var order = context.Orders.SingleOrDefault(o => o.Description == "Order 1");// should have a try catch block here
                      var product = context.Products.SingleOrDefault(p => p.Code == "20");
                      var orderLine = new OrderLine {
                          Id = 0 , ProductId = product.Id , OrderId = order.Id , Quantity = 3
                      };
                      context.OrderLines.Add(orderLine);
                      var rowsAffected = context.SaveChanges();
                      if(rowsAffected !=1) throw new Exception("OrderLine Insert failed"); 
          */
            var order1 = context.Orders.SingleOrDefault(o => o.Description == "Order 1");// should have a try catch block here
            var product1 = context.Products.SingleOrDefault(p => p.Code == "20");
            var orderLine1 = new OrderLine {
                Id = 0 , ProductId = product1.Id , OrderId = order1.Id , Quantity = 1
            };
            //context.OrderLines.Add(orderLine1);
            var order2 = context.Orders.SingleOrDefault(o => o.Description == "Order 1");// should have a try catch block here
            var product2 = context.Products.SingleOrDefault(p => p.Code == "40");
            var orderLine2 = new OrderLine {
                Id = 0 , ProductId = product2.Id , OrderId = order2.Id , Quantity = 2
            };
            var order3 = context.Orders.SingleOrDefault(o => o.Description == "Order 2");// should have a try catch block here
            var product3 = context.Products.SingleOrDefault(p => p.Code == "30");
            var orderLine3 = new OrderLine {
                Id = 0 , ProductId = product3.Id , OrderId = order3.Id , Quantity = 3
            };
            var order4 = context.Orders.SingleOrDefault(o => o.Description == "Order 2");// should have a try catch block here
            var product4 = context.Products.SingleOrDefault(p => p.Code == "50");
            var orderLine4 = new OrderLine {
                Id = 0 , ProductId = product4.Id , OrderId = order4.Id , Quantity = 4
            };
            var order5 = context.Orders.SingleOrDefault(o => o.Description == "Order 3");// should have a try catch block here
            var product5 = context.Products.SingleOrDefault(p => p.Code == "10");
            var orderLine5 = new OrderLine {
                Id = 0 , ProductId = product5.Id , OrderId = order5.Id , Quantity = 5
            };
            var order6 = context.Orders.SingleOrDefault(o => o.Description == "Order 3");// should have a try catch block here
            var product6 = context.Products.SingleOrDefault(p => p.Code == "10");
            var orderLine6 = new OrderLine {
                Id = 0 , ProductId = product6.Id , OrderId = order6.Id , Quantity = 6
            };
            var order7 = context.Orders.SingleOrDefault(o => o.Description == "Order 4");// should have a try catch block here
            var product7 = context.Products.SingleOrDefault(p => p.Code == "40");
            var orderLine7 = new OrderLine {
                Id = 0 , ProductId = product7.Id , OrderId = order7.Id , Quantity = 7
            };
            var order8 = context.Orders.SingleOrDefault(o => o.Description == "Order 4");// should have a try catch block here
            var product8 = context.Products.SingleOrDefault(p => p.Code == "20");
            var orderLine8 = new OrderLine {
                Id = 0 , ProductId = product8.Id , OrderId = order8.Id , Quantity = 6
            };
            var order9 = context.Orders.SingleOrDefault(o => o.Description == "Order 5");// should have a try catch block here
            var product9 = context.Products.SingleOrDefault(p => p.Code == "20");
            var orderLine9 = new OrderLine {
                Id = 0 , ProductId = product9.Id , OrderId = order9.Id , Quantity = 5
            };
            var order10 = context.Orders.SingleOrDefault(o => o.Description == "Order 5");// should have a try catch block here
            var product10 = context.Products.SingleOrDefault(p => p.Code == "10");
            var orderLine10 = new OrderLine {
                Id = 0 , ProductId = product10.Id , OrderId = order10.Id , Quantity = 4
            };

            context.AddRange(orderLine1 , orderLine2 , orderLine3 , orderLine4 , orderLine5 , orderLine6 , orderLine7 , orderLine8 , orderLine9 , orderLine10);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 10) throw new Exception("OrderLine Insert failed");


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

        /* this will be in the capstone almost verbatum in requests quantity and you will have to do in controller
         * 
         *  this will be in the capstone almost verbatum in requests quantity and you will have to do in controller
         *  
         *   this will be in the capstone almost verbatum in requests quantity and you will have to do in controller
         *   
         *    this will be in the capstone almost verbatum in requests quantity and you will have to do in controller
         *    
         *     this will be in the capstone almost verbatum in requests quantity and you will have to do in controller
         */
        static void RecalcOrderAmount(int orderId, AppDbContext context) {
            var order = context.Orders.Find(orderId);// reads the order and the virtual has the price
            var total = order.OrderLines.Sum(ol => ol.Quantity * ol.Product.Price);
            order.Amount = total;
            var rc = context.SaveChanges();  
            if (rc != 1) throw new Exception("Order update of amount failed!");
        }
 // find all the orders that are out there and put them in an array
        static void ReCalcOrderAmounts(AppDbContext context){
            var orderIds = context.Orders.Select(x => x.Id).ToArray();
            foreach(var orderId in orderIds) {
                RecalcOrderAmount(orderId , context);
            }
        }
 /*  end will be on capstone
  *  
  *  
  *  
  *  
  *  
  *  
  *  
  *  
  *  
  * 
  */
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

        static void GetOrderLines(AppDbContext context) {
            var orderLines = context.OrderLines.ToList();  // most often should use to list, could use ToArray() would be used to pass to a method defined as an array of orderlines
            orderLines.ForEach(line =>
                Console.WriteLine($"{line.Quantity}/{line.Order.Description}/{line.Product.Name}"));  
            
        }


    }
    }
