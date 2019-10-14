using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOListApplication.Web.Models
{
    public class LayoutModel
    {
        public LayoutModel(string title,int toDoId=0)
        {
            Title = title;
            Id = toDoId;
        }

        public LayoutModel()
        {
            throw new NotImplementedException();
        }

        public string Title { get; }

        public int Id { get; }

        public ToDoListViewModel ToDoListViewModel { get; set; }=new ToDoListViewModel();


    }

    public class LayoutModel<T> : LayoutModel
    {
        public LayoutModel(T pageModel, string title,int toDoId) : base(title)
        {
            PageModel = pageModel;
        }

        public T PageModel { get; }
    }
}