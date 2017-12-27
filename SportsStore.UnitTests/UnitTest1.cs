using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using Moq;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            // - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
             });
            // Arrange - create a controller and make the page size 3 items
            ProductController target = new ProductController(mock.Object);
            target.PageSize = 3;
            // Action - test the product counts for different categories
            int res1 = ((ProductsListViewModel)target
            .List("Cat1").Model).PagingInfo.TotalItems;
            int res2 = ((ProductsListViewModel)target
            .List("Cat2").Model).PagingInfo.TotalItems;
            int res3 = ((ProductsListViewModel)target
            .List("Cat3").Model).PagingInfo.TotalItems;
            int resAll = ((ProductsListViewModel)target
            .List(null).Model).PagingInfo.TotalItems;
            // Assert
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
}
