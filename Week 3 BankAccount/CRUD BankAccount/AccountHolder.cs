using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

    public class AccountHolder
{
    [Key]
    public int Id { get; set; } // Primary Key

    [Required]
    [StringLength(100)]
    public string Name { get; set; } // Name of the Account Holder

    [Required]
    [EmailAddress]
    public string Email { get; set; } // Email Address

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Account balance must be a positive value.")]
    public decimal AccountBalance { get; set; } // Account Balance

    [Phone]
    public string? PhoneNumber { get; set; } // Phone Number

    [StringLength(200)]
    public string? Address { get; set; } // Address
}

// Add a namespace to avoid duplicate class definitions in the global namespace
namespace YourAppNamespace
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class AccountHolder
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Name of the Account Holder

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Email Address

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Account balance must be a positive value.")]
        public decimal AccountBalance { get; set; } // Account Balance

        [Phone]
        public string? PhoneNumber { get; set; } // Phone Number

        [StringLength(200)]
        public string? Address { get; set; } // Address
    }
}