﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ChinookASPNETWebAPI.Domain.ApiModels;
using ChinookASPNETWebAPI.Domain.Converters;

namespace ChinookASPNETWebAPI.Domain.Entities
{
    public class Customer : IConvertModel<Customer, CustomerApiModel>
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? SupportRepId { get; set; }


        public virtual Employee SupportRep { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public CustomerApiModel Convert() =>
            new()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Company = Company,
                Address = Address,
                City = City,
                State = State,
                Country = Country,
                PostalCode = PostalCode,
                Phone = Phone,
                Fax = Fax,
                Email = Email,
                SupportRepId = SupportRepId ?? 0
            };
    }
}