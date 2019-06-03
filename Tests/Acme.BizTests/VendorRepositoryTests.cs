using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = 42;

            //Act
            var actual = repository.RetrieveValue<int>("Select ...", 42);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueStringTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = "Test";

            //Act
            var actual = repository.RetrieveValue<string>("Select ...", "Test");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueObjectTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            //Act
            var actual = repository.RetrieveValue<Vendor>("Select ...", vendor);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveCountTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = 2;

            //Act
            var actual = repository.Retrieve();

            //Assert
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod()]
        public void RetrieveElementsTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Inc", Email = "abc@abc.com" });
            expected.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });

            //Act
            var actual = repository.Retrieve();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveWithKeysTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new Dictionary<string, Vendor>()
            {
                                {"ABC Inc", new Vendor()
                {VendorId = 1, CompanyName = "ABC Inc", Email = "abc@abc.com" } },
                {"XYZ Inc", new Vendor()
                {VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" } }
            };

            //Act
            var actual = repository.RetrieveWithKeys();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
          
        }
    }
}