using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomersWebAppMVC.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        public string VAT { get; set; }
        public string Name { get; set; }
        [DisplayName("Creation date")]
        public DateTime CreationDate { get; set; }
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        [DisplayName("Street number")]
        public int StreetNumber { get; set; }
        [DisplayName("Postal code")]
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
