using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.ServiceModel.ToDo
{
    public class GetToDoRs:BaseRs
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  List<ToDoTaskServiceModel> ToDoTaskList { get; set; }
    }

    public class ToDoTaskServiceModel
    {
        public int Id { get; set; }
        public string TaskName  { get; set; }
        public int ToDoId { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
    }
}
