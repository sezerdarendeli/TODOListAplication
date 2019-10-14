using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.ServiceModel.ToDo
{
    public class GetToDoListRq : BaseRq
    {
        public int UserId { get; set; }
    }
}
