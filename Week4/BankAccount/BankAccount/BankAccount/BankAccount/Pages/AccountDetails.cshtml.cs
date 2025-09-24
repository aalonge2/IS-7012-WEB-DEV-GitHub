using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Threading.Tasks;

public class AccountDetailsModel : PageModel
{
    private readonly AppDbContext _db;
    public AccountDetailsModel(AppDbContext db) => _db = db;

    [BindProperty(SupportsGet = true)] public int Id { get; set; }
    public Account Account { get; set; }

    [BindProperty] public bool IsDeposit { get; set; } = true;
    [BindProperty] public decimal Amount { get; set; }
    [BindProperty] public string Note { get; set; }

    public string ErrorMessage { get; set; }

    public async Task OnGetAsync()
    {
        Account = await _db.Accounts
            .Include(a => a.Transactions)
            .FirstOrDefaultAsync(a => a.Id == Id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Account = await _db.Accounts
            .Include(a => a.Transactions)
            .FirstOrDefaultAsync(a => a.Id == Id);

        if (Account == null) return NotFound();

        if (Amount <= 0)
        {
            ErrorMessage = "Amount must be positive.";
            return Page();
        }

        var newBalance = Account.Balance + (IsDeposit ? Amount : -Amount);
        if (newBalance < 0)
        {
            ErrorMessage = "Insufficient funds.";
            return Page();
        }

        Account.Transactions.Add(new AccountTransaction
        {
            Amount = IsDeposit ? Amount : -Amount,
            Date = DateTime.UtcNow,
            Note = Note ?? (IsDeposit ? "Deposit" : "Withdrawal")
        });

        await _db.SaveChangesAsync();
        return RedirectToPage(new { Id = Account.Id });
    }
}
