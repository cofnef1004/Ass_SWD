using Ass_SWD.Business.Interface;
using Ass_SWD.Model;

namespace Ass_SWD.Business.Repository
{
    public class UserService :IUserRepository
    {
        private Model.MyStoreContext db = new MyStoreContext();

        public User login(string username, string password)
        {
            return db.Users.FirstOrDefault(acc => acc.UserName.Equals(username) && acc.Password.Equals(password));
        }
    }
}
