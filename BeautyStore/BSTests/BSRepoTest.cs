using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using BeautyStoreDL;
using BeautyStore.BeautyStoreModels;
using Microsoft.EntityFrameworkCore;

namespace BSTests
{
    public class BSRepoTest
    {
        private readonly DbContextOptions<BeautyStoreDBContext> options;

        public BSRepoTest()
        {
            options = new DbContextOptionsBuilder<BeautyStoreDBContext>()
                .UseSqlite("Filename=Test.db")
                .Options;
        }
        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                IBeautyStoreRepo repo = new BSRepoDB(context);
                repo.AddCustomer
                (
                    new Customer
                    {
                        CustomerName = "Angela",
                        HomeAddress = "123 um rd",
                        PhoneNumber = "1236549870",
                        EmailAddress= "testing@um.com"
                    }
                );
            }

            using (var assertContext = new BeautyStoreDBContext(options))
            {
                var result = assertContext.Customers.FirstOrDefault(c => c.CustomerName.Equals("testname"));
                Assert.NotNull(result);
                Assert.Equal("testname", result.CustomerName);
            }
        }

        [Fact]
        public void GetCustomersShouldReturnAllCustomers()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var customers = repo.GetCustomers();
                Assert.Equal(3, customers.Count);
            }
        }

        [Fact]
        public void GetCustomerByNameReturnsCorrectCustomer()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var customer = repo.GetCustomerByName("Weston");
                Assert.Equal(1, customer.CustomerID);
            }
        }

        [Fact]
        public void GetCustomerByEmailReturnsCorrectCustomer()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var customer = repo.GetCustomerByEmail("Calvin@um.com");
                Assert.Equal(1, customer.CustomerID);
            }
        }

        [Fact]
        public void GetOrdersReturnsAllOrders()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var orders = repo.GetOrders();
                Assert.Equal(6, orders.Count);
            }
        }

        [Fact]
        public void GetOrdersByLocationReturnsCorrectOrder()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var orders = repo.GetOrdersByLocation("CA");

                Assert.NotNull(orders);
                Assert.Equal(2, orders.Count);
            }
        }

        [Fact]
        public void GetOrdersByCustomerReturnsCorrectOrder()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var orders = repo.GetOrdersByCustomer("Calvin");

                Assert.NotNull(orders);
                Assert.Single(orders);
            }
        }
        //
        // [Fact]
        // public void AddOrderShouldAddOrder()
        // {
        //     using (var context = new BeautyStoreDBContext(options))
        //     {
        //         IBeautyStoreRepo repo = new BSRepoDB(context);
        //         repo.AddOrder
        //         (
        //             new Order
        //             {
        //                 CustomerId = 2,
        //                 LocationId = 1,
        //                 OrderDate = new DateTime(2025),
        //                 Total = 420
        //             }
        //         );
        //     }
        //
        //     using (var assertContext = new BeautyStoreDBContext(options))
        //     {
        //         var result = assertContext.Orders.FirstOrDefault(c => c.Total.Equals(420));
        //         Assert.NotNull(result);
        //         Assert.Equal(420, result.Total);
        //     }
        // }

        [Fact]
        public void GetItemsReturnsAllItems()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var items = repo.GetItems();
                Assert.Equal(12, items.Count);
            }
        }

        // [Fact]
        // public void AddItemShouldAddItem()
        // {
        //     using (var context = new BeautyStoreDBContext(options))
        //     {
        //         IBeautyStoreRepo repo = new BSRepoDB(context);
        //         repo.AddItem
        //         (
        //             new Item
        //             {
        //                 OrderId = 6,
        //                 ProductId = 2,
        //                 Quantity = 18
        //             }
        //         );
        //     }

        //    using (var assertContext = new BeautyStoreDBContext(options))
        //    {
        //        var result = assertContext.Items.FirstOrDefault(c => c.Quantity == 69);
        //        Assert.NotNull(result);
        //        Assert.Equal(18, result.Quantity);
        //    }
        //}

        [Fact]
        public void GetLocationsReturnsAllLocations()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var locations = repo.GetLocations();
                Assert.Equal(3, locations.Count);
            }
        }

        [Fact]
        public void GetProductsReturnsAllProjects()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var products = repo.GetProducts();
                Assert.Equal(3, products.Count);
            }
        }

        [Fact]
        public void GetProductByIdReturnsCorrectProduct()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                var product = repo.GetProductByID(1);
                Assert.Equal("6", product.ProductName);
            }
        }

        //[Fact]
        //public void GetInventoriesReturnsAllInventories()
        //{
        //    using (var context = new BeautyStoreDBContext(options))
        //    {
        //        //Arrange
        //        IBeautyStoreRepo repo = new BSRepoDB(context);

        //        //Act
        //        var inv = repo.GetInventories();
        //        Assert.Equal(5, inv.Count);
        //    }
        //}

        [Fact]
        public void UpdateInventoryShouldUpdateInventory()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);
                Inventory inventory = new Inventory()
                {
                    InventoriesId = 1,
                    Quantity = 10,
                    LocationId = 1,
                   // ProductId = 1
                };

                //Act
                repo.ReplenishInventory(inventory);
            }

            using (var assertContext = new BeautyStoreDBContext(options))
            {
                var result = assertContext.Inventories.FirstOrDefault(c => c.InventoriesId == 1);
                Assert.NotNull(result);
                Assert.Equal(10, result.Quantity);
            }
        }


        [Fact]
        public void CustomerExistsReturnsCorrectly()
        {
            using (var context = new BeautyStoreDBContext(options))
            {
                //Arrange
                IBeautyStoreRepo repo = new BSRepoDB(context);

                //Act
                bool test1 = repo.CustomerExists("Angela@um.com");
                bool test2 = repo.CustomerExists("Weston@um.com");

                Assert.True(test1);
                Assert.False(test2);
            }
        }
    }
}
