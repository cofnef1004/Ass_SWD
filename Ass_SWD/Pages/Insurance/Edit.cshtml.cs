using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ass_SWD.Pages.Insurance
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Models.Insurance Insurance { get; set; } = default!;
        private List<String> type = new List<String> { "Health", "Treatment", "Medical" };

        public int Id;
        public IActionResult OnGet(int id)
        {
            using (var db = new MyStoreContext())
            {
                Insurance = db.Insurances.FirstOrDefault(i => i.InsuranceId == id);
            }
            Id = Insurance.PatientId;
            ViewData["notice"] = "";
            ViewData["type"] = new SelectList(type);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            using (var db = new MyStoreContext())
            {

                ViewData["notice"] = "Insurance update success";
                ViewData["type"] = new SelectList(type);
                db.Insurances.Update(Insurance);
                db.SaveChanges();
                Id = Insurance.PatientId;
                return Page();
            }
        }

    }
}
