using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmailManager.Models
{
    public class Email
    {
        public Email()
        {
        }

        public Email(
            string email,
            string firstName,
            string lastName,
            string country = null,
            string organization = null,
            string department = null,
            string position = null,
            string phoneNumber = null)
        {
            EmailAddress = email;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Organization = organization;
            Department = department;
            Position = position;
            PhoneNumber = phoneNumber;
            Created = DateTime.UtcNow;
        }

        public Email(Email email) 
            : this(email.EmailAddress, email.FirstName, email.LastName, email.Country, email.Organization, email.Department, email.Position, email.PhoneNumber)
        {
        }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(100)]
        public string Organization { get; set; }
        [MaxLength(100)]
        public string Department { get; set; }
        [MaxLength(100)]
        public string Position { get; set; }
        [MaxLength(100)]
        public string PhoneNumber { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
