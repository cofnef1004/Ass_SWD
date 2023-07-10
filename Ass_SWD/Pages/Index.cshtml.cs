using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using System.Text.Json;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
namespace Ass_SWD.Pages
{
    public class IndexModel : PageModel
    {

        public async Task<IActionResult> OnGetAsync()
        {
            var staff = HttpContext.Session.GetString("staff");
            var cus = HttpContext.Session.GetString("customer");
            string acc = null;
            if (staff != null) acc = staff;
            else if (cus != null) acc = cus;
            if (acc == null) return RedirectToPage("/Login");
            return Page();
        }


        
       
    }
}