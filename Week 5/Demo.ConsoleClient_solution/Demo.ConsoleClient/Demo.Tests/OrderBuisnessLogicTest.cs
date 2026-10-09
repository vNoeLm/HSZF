using Demo.Logic;
using Demo.Models;
using Demo.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Tests
{
    public class OrderBuisnessLogicTest
    {
        private List<Order> orders;
        private List<Customer> customers;

        private Mock<IRepository<Customer>> customerRepo;
        private Mock<IRepository<Order>> orderRepo;

        // system under test
        private OrderBusinessLogic sut;

        [SetUp]
        public void SetUp()
        {
            orders = new List<Order>()
            {
                new Order(){ OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now, TotalAmount = 100m },
                new Order(){ OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now, TotalAmount = 200m }
            };

            customers = new List<Customer>()
            {
                new Customer(){ CustomerId = 1, Name = "Noel", Orders = new List<Order>{ orders[0] } },
                new Customer(){ CustomerId = 2, Name = "Noel2", Orders = new List<Order>{ orders[1] } }
            };

            customerRepo = new Mock<IRepository<Customer>>();
            orderRepo = new Mock<IRepository<Order>>();

            orderRepo.Setup(r => r.ReadAll()).Returns(orders.AsQueryable());
            customerRepo.Setup(r => r.ReadAll()).Returns(customers.AsQueryable());

            sut = new OrderBusinessLogic(customerRepo.Object, orderRepo.Object);
        }

        [Test]
        public void GetOrders_Something()
        {
            //Arrange

            //Act
            var res = sut.GetOrders();

            //Assert
            Assert.That(res, Is.Not.Empty);
            Assert.That(res[0].OrderDate, Is.LessThan(res[1].OrderDate));
            Assert.That(res[1].CustomerId, Is.EqualTo(2));
        }
    }
}
