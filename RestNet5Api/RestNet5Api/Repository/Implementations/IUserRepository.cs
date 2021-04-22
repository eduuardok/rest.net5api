using RestNet5Api.Data.VO;
using RestNet5Api.Model;

namespace RestNet5Api.Repository.Implementations
{
    public interface IUserRepository
    {
         User ValidateCredentials(UserVO user);
         User RefreshUserInfo(User user);
    }
}