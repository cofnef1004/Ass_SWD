using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using System.Text.Json;

namespace Ass_SWD.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string capCha { get; set; }

        [BindProperty]
        public string validate { get; set; } = "";
        public void OnGet()
        {
            validate = GenerateRandomString();
            capCha = string.Join(" ", validate.ToCharArray());
        }


        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string CapchaInput { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(CapchaInput))
            {
                setNotice("Input all the field");
                return Page();
            }
            if (!CapchaInput.Equals(validate))
            {
                setNotice("Wrong Capcha");
                return Page();
            }
            try
            {
                using (var db = new MyStoreContext())
                {
                    var acc = db.Users.FirstOrDefault(acc => acc.UserName.Equals(Username) && acc.Password.Equals(Password));
                    if (acc == null)
                    {
                        setNotice("Wrong Username or Password");
                        return Page();
                    }
                    var sessionStr = acc.Role.Equals("Admin") ? "admin" : "staff";
                    var accJson = JsonSerializer.Serialize(acc);
                    HttpContext.Session.SetString(sessionStr, accJson.ToString());
                    return RedirectToPage("/Patients");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void setNotice(string notice)
        {
            validate = GenerateRandomString();
            capCha = string.Join(" ", validate.ToCharArray());
            ViewData["notice"] = notice;
        }

        public static string GenerateRandomString()
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            for (int i = 0; i < 6; i++)
            {
                result += chars[rnd.Next(chars.Length)];
            }
            return result;
        }
    }
}
