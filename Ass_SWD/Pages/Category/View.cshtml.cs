using Ass_SWD.Models;
using Ass_SWD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass_SWD.Pages.Category
{
    public class ViewModel : PageModel
    {
        public ICategoryService _categoryService;
        public IAccountService _accountService;
        public List<Models.Category> Categories { get; set; } = default;
        public Boolean IsAdmin { get; set; }

        public ViewModel(ICategoryService categoryService, IAccountService accountService)
        {
            _categoryService = categoryService;
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            IsAdmin = _accountService.checkRole();
            if (IsAdmin)
            {
                Categories = _categoryService.GetAllCategory();
                return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }

        }
    }
}
