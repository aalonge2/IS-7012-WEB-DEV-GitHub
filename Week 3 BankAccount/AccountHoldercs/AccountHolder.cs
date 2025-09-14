using System.ComponentModel.DataAnnotations;

public class AccountHolder
{
    [Key]
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; }
    [Required, Range(0, double.MaxValue)]
    public decimal AccountBalance { get; set; }
    public string? Address { get; set; }
}

        public AccountHolder(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }

    public class BankAccount
    {
        private static int s_accountNumberSeed = 1234567890;
        public string Number { get; }
        public AccountHolder Owner { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(AccountHolder owner, decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance must be positive.");
            }

            Owner = owner;
            Balance = initialBalance;
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");
            }
            Balance += amount;
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");
            }
            Balance -= amount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var accountHolder = new AccountHolder("Anisa", "anisa@example.com", "123-456-7890");
            var account = new BankAccount(accountHolder, 1000);

            Console.WriteLine($"Account {account.Number} was created for {account.Owner.Name} with {account.Balance} initial balance.");
        }
}
}

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AccountHolder> AccountHolders { get; set; }
}
