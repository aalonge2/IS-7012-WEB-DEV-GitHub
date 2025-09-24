using BankAccount1.Models1.Classes;
using Microsoft.EntityFrameworkCore;
namespace BankAccount1.Models1
{
    public class BankAccountContext1
    {
    }
}


public class BankAccountContext1 : DbContext
{
    public DbSet<BankAccount> BankAccounts1 { get; set; }
    public DbSet<AccountHolder> AccountHolders1 { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("YourConnectionStringHere");
    }
}

public class AccountHolder
{
    public int Id { get; set; }

}
