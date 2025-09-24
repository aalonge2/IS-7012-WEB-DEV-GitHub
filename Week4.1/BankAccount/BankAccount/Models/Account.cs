using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models
{
    public enum AccountType
    {
        Checking,
        Savings,
        Business
    }

    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Full Name"), StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress, Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name = "Account Type")]
        public AccountType AccountType { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Navigation - one account has many transactions
        public List<AccountTransaction> Transactions { get; set; } = new();

        // Computed balance from transactions
        public decimal Balance => Transactions?.Sum(t => t.Amount) ?? 0m;
    }
}
