using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class AccountHolder1Update
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required] // Added to ensure the property is not null
        public string AccountHolderName { get; set; } = string.Empty; // Default value to avoid null

        [EmailAddress]
        [Required] // Added to ensure the property is not null
        public string EmailAddress { get; set; } = string.Empty; // Default value to avoid null

        public decimal AccountBalance { get; set; }

        [Phone]
        [Required] // Added to ensure the property is not null
        public string PhoneNumber { get; set; } = string.Empty; // Default value to avoid null

        [Required] // Added to ensure the property is not null
        public string Address { get; set; } = string.Empty; // Default value to avoid null
    }
}