using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ass_SWD.Pages.Payments
{
    public class CreateModel : PageModel
    {
        MyStoreContext _context;
        public List<Category> paymentsGroupByCateID { get; set; }

        [BindProperty]
        public Models.Payment PaymentEntity { get; set; } = default!;

       
        
        public CreateModel(MyStoreContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            paymentsGroupByCateID = _context.Categories.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int i = PaymentEntity.CategoryId;
            string s = PaymentEntity.BillingInformation;

            // Thêm payment vào cơ sở dữ liệu bằng Entity Framework
            _context.Payments.Add(PaymentEntity);
            _context.SaveChanges();

            // Chuyển hướng về trang thành công (hoặc trang khác tùy ý)
            return RedirectToPage("./Index");
        }
    }
}
