using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Ass_SWD.Pages.Payment
{
   
    public class IndexModel : PageModel
    {
        public readonly Models.MyStoreContext _context = new Models.MyStoreContext();
        public List<Models.Payment> payments = new List<Models.Payment>();
        
        public void OnGet(string billingInformation)
        {
            if (string.IsNullOrEmpty(billingInformation))
            {
                payments = _context.Payments.ToList();
            }
            else
            {             
                payments = _context.Payments.Where(x => x.BillingInformation.Contains(billingInformation)).ToList();
            }
        }
    }
}
