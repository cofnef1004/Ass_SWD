using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Ass_SWD.Pages.PaymentList
{
   
    public class IndexModel : PageModel
    {
       MyStoreContext _context = new MyStoreContext();
        public List<Payment> payments = new List<Payment>();
        
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
