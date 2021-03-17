using PizzaAPIv2.Models;
using PizzaAPIv2.Controllers;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetStatus_ReturnsStatus()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<PizzaContext>()
            .UseInMemoryDatabase(databaseName: "PizzaDataBase")
            .Options;
            //Mocked DB entry
            using (var context = new PizzaContext(options))
            {
                context.Orders.Add(new Order
                {
                    OrderId = 1,
                    OrderStatus = "Pending"
                });
                context.SaveChanges();
            }
            using (var context = new PizzaContext(options))
            {
                OrdersController controller = new(context);
                var result = controller.GetStatus(1).Result.Value;
                var actualResult = result.ToString();

                Assert.Equal("Pending", actualResult);
            }

        }
/*        [Fact]
        public void CheckCustomer_ReturnsCustomer()
        {
            var options = new DbContextOptionsBuilder<PizzaContext>()
           .UseInMemoryDatabase(databaseName: "PizzaDataBase")
           .Options;
            //Mocked DB entry
            using (var context = new PizzaContext(options))
            {
                context.Customers.Add(new Customer
                {
                    CustomerId = 1,
                    CustomerFname = "Test",
                    CustomerEmail = "test@email.com"
                });
                context.SaveChanges();
            }
            using (var context = new PizzaContext(options))
            {
                PController controller = new PController(context);
                Customer test = new()
                {
                    CustomerId = 1,
                    CustomerEmail = "test@email.com"
                };
                var result = controller.CheckCustomer(test);
                result.Wait();
                var actualResult = result.Result;;

                Assert.Equal(1, actualResult);
            }
        }*/
    }
}
