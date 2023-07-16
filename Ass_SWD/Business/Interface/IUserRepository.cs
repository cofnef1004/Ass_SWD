using Ass_SWD.Models;

namespace Ass_SWD.Business.Interface
{
    public interface IUserRepository
    {
        User login(string username, string password);
    }
}
