using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class AccountTransaction
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Display(Name = "Note")]
        public string Note { get; set; }
    }
}
