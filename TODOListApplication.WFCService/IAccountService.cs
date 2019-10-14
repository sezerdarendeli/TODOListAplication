﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TODOListApplication.ServiceModel.Account;

namespace TODOListApplication.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        [WebInvoke]
        RegisterRs Register(RegisterRq request);

        [OperationContract]
        [WebInvoke]
        LoginRs Login(LoginRq request);

    }
}
