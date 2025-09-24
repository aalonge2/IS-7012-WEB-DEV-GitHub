using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System;
using System.Threading.Tasks;

public class CreateAccountModel : PageModel
{
    private readonly AppDbContext _db;
    public CreateAccountModel(AppDbContext db) => _db = db;

    [BindProperty] public string Owner { get; set; }
    [BindProperty] public decimal InitialBalance { get; set; }
    [BindProperty] public string SelectedService { get; set; }

    public string ErrorMessage { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Owner))
        {
            ErrorMessage = "Owner required.";
            return Page();
        }

        if (InitialBalance < 0)
        {
            ErrorMessage = "Initial balance must be non-negative.";
            return Page();
        }

        // Generate 10-digit account number
        var number = DateTime.UtcNow.Ticks.ToString().Substring(0, 10);

        var account = new Account
        {
            Number = number,
            Owner = Owner
        };

        if (InitialBalance > 0)
        {
            account.Transactions.Add(new AccountTransaction
            {
                Amount = InitialBalance,
                Date = DateTime.UtcNow,
                Note = "Initial deposit"
            });
        }

        _db.Accounts.Add(account);
        await _db.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
