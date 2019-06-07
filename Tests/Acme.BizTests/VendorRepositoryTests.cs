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
            Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Inc", Email = "abc@abc.com" });
            expected.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });

            //Act
            var actual = repository.Retrieve();

            //Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveWithIteratorTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                {new Vendor()
                {VendorId = 1, CompanyName = "ABC Inc", Email = "abc@abc.com"  } },
                {new Vendor()
                { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" }}
            };
 


            //Act
            var vendorIterator = repository.RetrieveWithIterator();
            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }
            var actual = vendorIterator.ToList();

            //Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveAll()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                { new Vendor()
                {VendorId = 8, CompanyName = "Car Toys Inc", Email = "car@xyz.com"  } },
                { new Vendor()
                { VendorId = 9, CompanyName = "Fun Toys Inc", Email = "fun@xyz.com" }},
                {new Vendor()
                { VendorId = 6, CompanyName = "Toy Blocks Inc", Email = "blocks@xyz.com" }},
                {new Vendor()
                {VendorId = 5, CompanyName = "Toys Inc", Email = "toy@xyz.com"  } }
            };

            //Act

            var vendors = repository.RetrieveAll();

            //Query syntax
            //var vendorQuery = from v in vendors
            //                  where v.CompanyName.Contains("Toy")
            //                  orderby v.CompanyName
            //                  select v;

            //Method syntax
            //var vendorQuery = vendors
            //      .Where(FilterCompanies)
            //      .OrderBy(OrderCompaniesByName);

            //Lambda Expression
            var vendorQuery = vendors
                  .Where(v => v.CompanyName.Contains("Toy"))
                  .OrderBy(v => v.CompanyName);


            //Assert
            CollectionAssert.AreEqual(expected, vendorQuery.ToList());
        }

        //Used for RetrieveAll Method Syntax
        //private bool FilterCompanies(Vendor v) =>
        //    v.CompanyName.Contains("Toy");
        //private string OrderCompaniesByName(Vendor v) => v.CompanyName;

    }
}