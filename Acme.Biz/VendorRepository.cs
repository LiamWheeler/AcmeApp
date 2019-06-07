using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> vendors;
        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }


        public IEnumerable<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();
                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Inc", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });
            }
            for (int i = 0; i < vendors.Count; i++)
            {
                Console.WriteLine(vendors[i]);
            }
            return vendors;
        }


        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }

        public T RetrieveValue<T>(string sql, T defaultValue)
        {
            //Call the database to retrieve the value
            //If no value is returned, return the default value
            T value = defaultValue;
            return value;
        }

        /// <summary>
        /// Retrieves all of the vendors, one at a time
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            //get data from the database
            this.Retrieve();

            foreach (var vendor in vendors)
            {
                Console.WriteLine($"Vendor Id: {vendor.VendorId}");
                yield return vendor;
            }
        }

        public IEnumerable<Vendor> RetrieveAll()
        {
                vendors = new List<Vendor>();
            {
                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Inc", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });
                vendors.Add(new Vendor() { VendorId = 3, CompanyName = "EFG Inc", Email = "efg@xyz.com" });
                vendors.Add(new Vendor() { VendorId = 4, CompanyName = "HIJ Inc", Email = "hij@xyz.com" });
                vendors.Add(new Vendor() { VendorId = 5, CompanyName = "Toys Inc", Email = "toy@xyz.com" });
                vendors.Add(new Vendor() { VendorId = 6, CompanyName = "Toy Blocks Inc", Email = "blocks@xyz.com" });
                vendors.Add(new Vendor() { VendorId = 7, CompanyName = "Home Inc", Email = "home@xyz.com" });
                vendors.Add(new Vendor() { VendorId = 8, CompanyName = "Car Toys Inc", Email = "car@xyz.com" });
                vendors.Add(new Vendor() { VendorId = 9, CompanyName = "Fun Toys Inc", Email = "fun@xyz.com" });
            }
            return vendors;
        }
    }
}
