using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TODOListApplication.ServiceModel.Account;
using TODOListApplication.ServiceModel.ToDo;

namespace TODOListApplication.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IToDoService" in both code and config file together.
    [ServiceContract]
    public interface IToDoService
    {
        [OperationContract]

        [WebInvoke]
        AddToDoRs AddToDo(AddToDoRq request);

        [WebInvoke]
        AddToDoTaskRs AddToDoTask(AddToDoTaskRq request);

        [WebInvoke]
        GetToDoRs GetToDoById(GetToDoRq request);

        bool DeleteTodoTaskById(int id);

        bool DeleteTodoById(int id);

        GetToDoListRs GetToDoList(GetToDoListRq request);
    }
}
