using Ass_SWD.Services;
using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ass_SWD.Pages.Payments
{
    public class CreateModel : PageModel
    {
        IPaymentService _paymentService;
        MyStoreContext _storeContext;
        public List<Models.Category> paymentsGroupByCateID { get; set; }

        [BindProperty]
        public Payment PaymentEntity { get; set; } = default!;

       
        
        public CreateModel(IPaymentService paymentService, MyStoreContext context )
        {
            _paymentService = paymentService;
            _storeContext = context;    
        }

        public void OnGet()
        {
            paymentsGroupByCateID = _storeContext.Categories.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int i = PaymentEntity.CategoryId;
            string s = PaymentEntity.BillingInformation;


            // Thêm payment vào cơ sở dữ liệu bằng Entity Framework
            _paymentService.AddPayment(PaymentEntity);
           
            // Chuyển hướng về trang thành công (hoặc trang khác tùy ý)
            return RedirectToPage("./Index");
        }
    }
}
