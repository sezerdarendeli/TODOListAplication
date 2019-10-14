using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.ServiceModel.ToDo
{
    public class GetToDoRq : BaseRq
    {
        public int Id { get; set; }

        public bool CompletedTask { get; set; }

        public bool ExpireDate { get; set; }
    }
}
