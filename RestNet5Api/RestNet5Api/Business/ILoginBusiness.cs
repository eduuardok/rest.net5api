using RestNet5Api.Data.VO;

namespace RestNet5Api.Business
{
    public interface ILoginBusiness
    {
         TokenVO ValidateCredentials(UserVO user);
    }
}