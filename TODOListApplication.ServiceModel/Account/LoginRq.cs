using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.ServiceModel.Account
{
    public class LoginRq:BaseRq
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
