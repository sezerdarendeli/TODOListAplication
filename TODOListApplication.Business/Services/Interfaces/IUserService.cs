using TODOListApplication.ServiceModel.Account;

namespace TODOListApplication.Business.Services.Interfaces
{
    public interface IUserService
    {
        void GetUserList();

        RegisterRs Register(RegisterRq request);

        LoginRs Login(LoginRq request);
    }
}
