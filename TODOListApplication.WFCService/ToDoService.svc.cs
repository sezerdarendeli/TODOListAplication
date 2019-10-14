using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TODOListApplication.Core;
using TODOListApplication.ServiceModel.ToDo;

namespace TODOListApplication.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ToDoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ToDoService.svc or ToDoService.svc.cs at the Solution Explorer and start debugging.
    public class ToDoService : IToDoService
    {
     
        public AddToDoRs AddToDo(AddToDoRq request)
        {
            var response= new AddToDoRs();
            var todoService = IocContainer.Resolve<TODOListApplication.Business.Services.Interfaces.IToDoService>();

            var result = todoService.AddTodo(request);

            return result;
        }

        public AddToDoTaskRs AddToDoTask(AddToDoTaskRq request)
        {
            var response = new AddToDoRs();
            var todoService = IocContainer.Resolve<TODOListApplication.Business.Services.Interfaces.IToDoService>();

            var result = todoService.AddTodoTask(request);

            return result;
        }

        public GetToDoRs GetToDoById(GetToDoRq request)
        {
            var response = new GetToDoRs();
            var todoService = IocContainer.Resolve<TODOListApplication.Business.Services.Interfaces.IToDoService>();
            var result = todoService.GetToDoById(request);

            response = result;
            return response;
        }

        public bool DeleteTodoTaskById(int id)
        {
            bool response;
            var todoService = IocContainer.Resolve<TODOListApplication.Business.Services.Interfaces.IToDoService>();
           return todoService.DeleteTodoTaskById(id);
        }

        public bool DeleteTodoById(int id)
        {
            bool response;
            var todoService = IocContainer.Resolve<TODOListApplication.Business.Services.Interfaces.IToDoService>();
            return todoService.DeleteTodoById(id);
        }

        public GetToDoListRs GetToDoList(GetToDoListRq request)
        {
            var todoService = IocContainer.Resolve<TODOListApplication.Business.Services.Interfaces.IToDoService>();
            return todoService.GetToDoList(request);
        }
    }
}
