using Ass_SWD.Models;
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
        public readonly DataAccess.Models.MyStoreContext _context = new DataAccess.Models.MyStoreContext();
        public List<DataAccess.Models.Payment> payments = new List<DataAccess.Models.Payment>();
        
        public void OnGet()
        {
            payments = _context.Payments.ToList();
        }
    }
}
