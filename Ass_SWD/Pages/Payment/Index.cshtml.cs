using Ass_SWD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ass_SWD.DataAccess.Models;

namespace Ass_SWD.Pages.Payment
{
   
    public class IndexModel : PageModel
    {
        public readonly Model.MyStoreContext _context = new Model.MyStoreContext();
        public List<Model.Payment> payments = new List<Model.Payment>();
        
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
