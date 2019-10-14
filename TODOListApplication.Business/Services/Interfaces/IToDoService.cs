using TODOListApplication.ServiceModel.Account;
using TODOListApplication.ServiceModel.ToDo;

namespace TODOListApplication.Business.Services.Interfaces
{
    public interface IToDoService
    {
        AddToDoRs AddTodo(AddToDoRq request);

        AddToDoTaskRs AddTodoTask(AddToDoTaskRq request);

        GetToDoRs GetToDoById(GetToDoRq request);

        bool DeleteTodoTaskById(int id);

        bool DeleteTodoById(int id);

        GetToDoListRs GetToDoList(GetToDoListRq request);
    }
}
