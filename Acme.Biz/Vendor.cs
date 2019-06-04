﻿using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public enum IncludeAddress { Yes, No};
        public enum SendCopy { Yes, No};

        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        
        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">Quantity of product to order</param>
        /// <param name="deliverBy">Requested delivery date</param>
        /// <param name="instructions">Delivery Instructions</param>
        /// <returns></returns>
        public OperationResult<bool> PlaceOrder(Product product, int quantity,
            DateTimeOffset? deliverBy = null , string instructions = "Standard delivery")
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;

            var orderTextBuilder = new StringBuilder ("Order from Acme, Inc" + System.Environment.NewLine +
                "Product: " + product.ProductCode + System.Environment.NewLine +
                "Quantity: " + quantity);
            if (deliverBy.HasValue)
            {
                orderTextBuilder.Append( System.Environment.NewLine + "Deliver By: " + deliverBy.Value.ToString("d"));
            }
            if (!String.IsNullOrWhiteSpace(instructions))
            {
                orderTextBuilder.Append (System.Environment.NewLine + "Instructions: " + instructions);
            }


            var orderText = orderTextBuilder.ToString();

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }
            var operationResult = new OperationResult<bool>(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends a product order to the vendor.
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">Quantity of the product to order</param>
        /// <param name="includeAdress">True to include the shipping address</param>
        /// <param name="sendCopy">True to send a copy of the email</param>
        /// <returns>Success flag and order text</returns>
        public OperationResult<bool> PlaceOrder ( Product product, int quantity,
                                            IncludeAddress includeAddress, SendCopy sendCopy)
        {
            var orderText = "Test";
            if (includeAddress == IncludeAddress.Yes) orderText += " with Address";
            if (sendCopy == SendCopy.Yes) orderText += " with Copy";

            var operationResult = new OperationResult<bool>(true, orderText);
            return operationResult;
        }

        public override string ToString()
        {
            string vendorInfo = $"Vendor: {this.CompanyName} ({this.VendorId})";
            string result;
            result = vendorInfo?.ToLower();
            result = vendorInfo?.ToUpper();
            result = vendorInfo?.Replace("Vendor", "Supplier");

            var length = vendorInfo?.Length;
            var index = vendorInfo?.IndexOf(":");
            var begins = vendorInfo?.StartsWith("Vendor");

            return vendorInfo;
        }

        public string PrepareDirections()
        {
            var directions = @"Insert \r\n to define a new line";
            return directions;
        }

        /// <summary>
        /// Overridden to support comparison
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            Vendor compareVendor = obj as Vendor;
            if (compareVendor != null &&
                this.VendorId == compareVendor.VendorId &&
                this.CompanyName == compareVendor.CompanyName &&
                this.Email == compareVendor.Email)
                return true;

            return base.Equals(obj);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }

        /// <summary>
        /// Sends an email to a set of vendors
        /// </summary>
        /// <param name="vendors">Collection of vendors</param>
        /// <param name="message">Message to send</param>
        /// <returns></returns>
        public static List<string> SendEmail(ICollection<Vendor> vendors, string message)
        {
            var confirmations = new List<string>();
            var emailService = new EmailService();
            Console.WriteLine(vendors.Count); //for debugging purposes
            foreach (var vendor in vendors)
            {
                var subject = "Important message for: " + vendor.CompanyName;
                var confirmation = emailService.SendMessage(subject, message, vendor.Email);
                confirmations.Add(confirmation);
            }
            return confirmations;
        }
    }
}
