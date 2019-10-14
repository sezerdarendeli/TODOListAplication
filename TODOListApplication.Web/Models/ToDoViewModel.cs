using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TODOListApplication.ServiceModel.ToDo;

namespace TODOListApplication.Web.Models
{
    public class ToDoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<ToDoTaskViewModel> ToDoTaskList { get; set; }
    }

    public class ToDoTaskViewModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int ToDoId { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
    }
}