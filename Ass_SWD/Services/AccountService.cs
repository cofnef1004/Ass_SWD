using Ass_SWD.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using System.Net.Http;

namespace Ass_SWD.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpContext _httpContext;

        public AccountService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public Boolean checkRole()
        {
            string accJsonStr = _httpContext.Session.GetString("admin");
            if (accJsonStr != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
