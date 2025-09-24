using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;

    [BindProperty(SupportsGet = true)]
    public string SearchString { get; set; }

    public List<Account> Accounts { get; set; } = new();

    public async Task OnGetAsync()
    {
        var q = _db.Accounts.Include(a => a.Transactions).AsQueryable();

        if (!string.IsNullOrWhiteSpace(SearchString))
        {
            q = q.Where(a => a.FullName.Contains(SearchString) || a.Email.Contains(SearchString));
        }

        Accounts = await q.OrderBy(a => a.FullName).ToListAsync();
    }
}
