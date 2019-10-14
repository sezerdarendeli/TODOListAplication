using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.ServiceModel.ToDo
{
    public class GetToDoListRs : BaseRs
    {
        public List<ToDoModel> ToDoList { get; set; }
    }

    public class ToDoModel : BaseRs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
