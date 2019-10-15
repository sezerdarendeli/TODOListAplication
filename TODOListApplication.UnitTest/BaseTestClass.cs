using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOListApplication.Registration;

namespace TODOListApplication.UnitTest
{
    public class BaseTestClass
    {
        public BaseTestClass()
        {
            IocRegistration.Boostrap();

        }
}
}
