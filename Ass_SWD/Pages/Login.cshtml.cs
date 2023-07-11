using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Ass_SWD.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                using (var db = new MyStoreContext())
                {
                    var acc = db.Users.FirstOrDefault(acc => acc.UserName.Equals(Username) && acc.Password.Equals(Password));
                    if (acc == null) return Page();
                    var sessionStr = acc.Role.Equals("Admin") ? "admin" : "staff";
                    var accJson = JsonSerializer.Serialize(acc);
                    HttpContext.Session.SetString(sessionStr, accJson.ToString());
                    return RedirectToPage("/Index");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GenerateCaptcha(int length)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] captchaChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                captchaChars[i] = characters[random.Next(characters.Length)];
            }

            return new string(captchaChars);
        }
    }
}
