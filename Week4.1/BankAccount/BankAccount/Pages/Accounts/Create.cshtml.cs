using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Threading.Tasks;
using System;

public class CreateModel : PageModel
{
    private readonly AppDbContext _db;
    public CreateModel(AppDbContext db) => _db = db;

    [BindProperty]
    public Account Account { get; set; }

    [BindProperty]
    public decimal InitialDeposit { get; set; }

    public void OnGet()
    {
        // prefill account number if desired
        Account = new Account
        {
            AccountNumber = GenerateAccountNumber()
        };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        Account.DateCreated = DateTime.UtcNow;

        if (InitialDeposit > 0)
        {
            Account.Transactions.Add(new AccountTransaction
            {
                Amount = InitialDeposit,
                Date = DateTime.UtcNow,
                Note = "Initial Deposit"
            });
        }

        _db.Accounts.Add(Account);
        await _db.SaveChangesAsync();

        return RedirectToPage("/Accounts/Index");
    }

    private string GenerateAccountNumber()
    {
        // simple unique-ish 10-char number using ticks; replace with better generator if needed
        var ticks = DateTime.UtcNow.Ticks.ToString();
        if (ticks.Length >= 10) return ticks.Substring(0, 10);
        return ticks.PadLeft(10, '0');
    }
}
