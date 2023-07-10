using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using System.Text.Json;

namespace Ass_SWD.Pages
{
    public class IndexModel : PageModel
    {

        public async Task<IActionResult> OnGetAsync()
        {
            var staff = HttpContext.Session.GetString("staff");
            var admin = HttpContext.Session.GetString("admin");
            string acc = null;
            if (staff != null) acc = staff;
            else if (admin != null) acc = admin;
            if (acc == null) return RedirectToPage("/Login");
            return Page();
        }


        
       
    }
}