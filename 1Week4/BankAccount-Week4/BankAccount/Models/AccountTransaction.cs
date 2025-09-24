using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Models
{
    public class AccountTransaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
