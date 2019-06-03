using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            //arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true, "Order from Acme, Inc\r\nProduct: Tools-0001\r\nQuantity: 12" +
                                                "\r\nInstructions: Standard delivery");


            //act
            var actual = vendor.PlaceOrder(product, 12);

            //Assert

            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrder_3Parameters()
        {
            //arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true, "Order from Acme, Inc\r\nProduct:" +
                " Tools-0001\r\nQuantity: 12" + "\r\nDeliver By: 25/10/2019" +
                "\r\nInstructions: Standard delivery");


            //act
            var actual = vendor.PlaceOrder(product, 12,
                new DateTimeOffset(2019, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            //Assert

            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_Exception()
        {
            //arrange
            var vendor = new Vendor();

            //act
            var actual = vendor.PlaceOrder(null, 12);

            //Assert
            //Expected exception
        }

        [TestMethod()]
        public void PlaceOrderTest_WithAddress()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true, "Test with Address");

            var actual = vendor.PlaceOrder(product, 12,
                                           Vendor.IncludeAddress.Yes,
                                           Vendor.SendCopy.No);

            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_NoDeliveryDate()
        {
            //arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                "Order from Acme, Inc\r\nProduct:" + " Tools-0001\r\nQuantity: 12" +
                "\r\nInstructions: deliver to Suite 42");


            //act
            var actual = vendor.PlaceOrder(product, 12,
                                instructions: "deliver to Suite 42");

            //Assert

            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "Vendor: ABC Corp (1)";

            var actual = vendor.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PrepareDirectionsTest()
        {
            var vendor = new Vendor();
            var expected = @"Insert \r\n to define a new line";
            
            var actual = vendor.PrepareDirections();
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
    }
}