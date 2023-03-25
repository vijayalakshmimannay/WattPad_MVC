using WattPad.Models;

namespace WattPad.Repository
{
    public interface IUserRL
    {
        public UserModel AddUser(UserModel user);

        public string UserLogin(LoginModel loginModel);
    }
}
