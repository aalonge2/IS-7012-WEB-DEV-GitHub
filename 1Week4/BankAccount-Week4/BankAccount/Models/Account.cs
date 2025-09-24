using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Owner { get; set; }

        public List<AccountTransaction> Transactions { get; set; } = new();

        // Not mapped to DB, computed at runtime
        public decimal Balance => Transactions?.Sum(t => t.Amount) ?? 0m;
    }
}
