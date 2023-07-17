using Ass_SWD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ass_SWD.Pages.Insurance
{
    public class DeleteModel : PageModel
    {
        public IList<Model.Insurance> Insurances { get; set; } = default!;
        public int Id ;
        public IActionResult OnGet(int id)
        {
            using (var db = new MyStoreContext())
            {
                Model.Insurance insu = db.Insurances.FirstOrDefault(i => i.InsuranceId == id);
                Id = insu.PatientId;
                db.Insurances.Remove(insu);
                db.SaveChanges();
                Insurances = db.Insurances.Where(i => i.PatientId == Id).ToList();
                return RedirectToPage("/Insurance/Index", new {id = Id });
            }
        }
    }
}
