using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _db;
    public DetailsModel(AppDbContext db) => _db = db;

    public Account Account { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Account = await _db.Accounts
            .Include(a => a.Transactions)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (Account == null) return NotFound();

        return Page();
    }
}
