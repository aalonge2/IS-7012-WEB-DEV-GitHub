using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;

    public List<Account> Accounts { get; set; }

    public async Task OnGetAsync()
    {
        Accounts = await _db.Accounts
            .Include(a => a.Transactions)
            .ToListAsync();
    }
}
