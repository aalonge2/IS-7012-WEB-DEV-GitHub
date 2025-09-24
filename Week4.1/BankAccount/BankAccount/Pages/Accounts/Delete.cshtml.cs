using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Threading.Tasks;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _db;
    public DeleteModel(AppDbContext db) => _db = db;

    [BindProperty]
    public Account Account { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Account = await _db.Accounts.FindAsync(id);
        if (Account == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var account = await _db.Accounts.FindAsync(Account.Id);
        if (account == null) return NotFound();

        // optionally remove transactions first (cascade delete can handle it if configured)
        _db.Accounts.Remove(account);
        await _db.SaveChangesAsync();

        return RedirectToPage("/Accounts/Index");
    }
}
