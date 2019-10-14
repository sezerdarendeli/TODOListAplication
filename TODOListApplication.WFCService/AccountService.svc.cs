using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Caching;
using TODOListApplication.Business.Services.Interfaces;
using TODOListApplication.Core;
using TODOListApplication.ServiceModel.Account;

namespace TODOListApplication.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    public class AccountService : IAccountService
    {
        public void DoWork()
        {
        }

        public RegisterRs Register(RegisterRq request)
        {
            var response = new RegisterRs();
            var accountService = IocContainer.Resolve<IUserService>();
            return accountService.Register(request);
        }

        public LoginRs Login(LoginRq request)
        {
            var response = new LoginRs();
            var accountService = IocContainer.Resolve<IUserService>();
            return accountService.Login(request);
        }
    }
}
