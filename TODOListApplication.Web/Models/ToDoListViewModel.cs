
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TODOListApplication.ServiceModel.ToDo;

namespace TODOListApplication.Web.Models
{
    public class ToDoListViewModel
    {
       public List<TodoVModel> ToDoList { get; set; }

       public string AktiveToDoId { get; set; }
    }

    public class TodoVModel
    {
      

        public int Id { get; set; }

        public string Name { get; set; }
    }
}