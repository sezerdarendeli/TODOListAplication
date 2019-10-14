using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.ServiceModel.ToDo
{
    public class AddToDoTaskRq : BaseRq
    {
        public int ToDoId { get; set; }

        public string TaskName { get; set; }

        public string ExpireDateTimeString { get; set; }

        public DateTime ExpireDateTime { get; set; } = DateTime.Now;

        public bool Completed { get; set; }

        public string Description { get; set; }
    }
}
