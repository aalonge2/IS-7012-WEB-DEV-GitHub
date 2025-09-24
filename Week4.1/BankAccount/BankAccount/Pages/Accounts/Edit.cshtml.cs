using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class EditModel : PageModel
{
    private readonly AppDbContext _db;
    public EditModel(AppDbContext db) => _db = db;

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
        if (!ModelState.IsValid) return Page();

        _db.Attach(Account).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _db.Accounts.AnyAsync(a => a.Id == Account.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("/Accounts/Index");
    }
}
