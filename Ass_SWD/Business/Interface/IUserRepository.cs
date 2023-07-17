using Ass_SWD.Model;

namespace Ass_SWD.Business.Interface
{
    public interface IUserRepository
    {
        User login(string username, string password);
    }
}
