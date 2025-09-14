    using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
public class IndexModel : PageModel
{
    public List<AccountHolder> AccountHolders { get; set; }

    public void OnGet()
    {
        // Example: populate AccountHolders from a data source
        AccountHolders = new List<AccountHolder>
        {
            new AccountHolder { Id = 1, Name = "John Doe", Email = "john@example.com", AccountBalance = 1000, PhoneNumber = "123-456-7890" }
            // Add more sample data or fetch from your database
        };
    }
}

public class AccountHolder
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal AccountBalance { get; set; }
    public string PhoneNumber { get; set; }
}