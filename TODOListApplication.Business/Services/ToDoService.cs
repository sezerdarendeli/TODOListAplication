using System;
using System.Collections.Generic;
using System.Linq;
using TODOListApplication.Business.Services.Interfaces;
using TODOListApplication.Data;
using TODOListApplication.Data.DbModel;
using TODOListApplication.ServiceModel.Account;
using TODOListApplication.ServiceModel.ToDo;

namespace TODOListApplication.Business.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ITodoListApplicationRepository _dbRepository;
        public ToDoService(ITodoListApplicationRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public bool DeleteTodoById(int id)
        {
            return _dbRepository.HardDelete<ToDo>(id);
        }

        public bool DeleteTodoTaskById(int id)
        {
            return _dbRepository.HardDelete<ToDoTask>(id);
        }

        public AddToDoRs AddTodo(AddToDoRq request)
        {
            var response = new AddToDoRs();
            var toDoModel = new ToDo();
            toDoModel.Name = request.Name;
            toDoModel.UserId = request.UserId;

            _dbRepository.Add(toDoModel);
            _dbRepository.SaveChanges();

            response.ToDoId = toDoModel.Id;
            return response;
        }

        public AddToDoTaskRs AddTodoTask(AddToDoTaskRq request)
        {
            var response = new AddToDoTaskRs();
            var toDoTaskModel = new ToDoTask
            {
                TaskName = request.TaskName,
                ToDoId = request.ToDoId,
                ExpireDateTime = request.ExpireDateTime,
                Completed = request.Completed,
                Description = request.Description
            };

            _dbRepository.Add(toDoTaskModel);
            _dbRepository.SaveChanges();

            return response;
        }

        public GetToDoRs GetToDoById(GetToDoRq request)
        {
            var response = new GetToDoRs();

            var result = _dbRepository.FirstOrDefault<ToDo>(e => e.Id == request.Id);

            response.Id = result.Id;
            response.Name = result.Name;
            IQueryable<ToDoTask> toDoTaskList = null;
            if (request.CompletedTask)
            {
                toDoTaskList = _dbRepository.Where<ToDoTask>(e => e.ToDoId == request.Id && e.Completed == true);
            }

            if (request.ExpireDate)
            {
                toDoTaskList = _dbRepository.Where<ToDoTask>(e => e.ToDoId == request.Id && e.ExpireDateTime < DateTime.Now);
            }

            if (!request.ExpireDate && !request.CompletedTask)
            {
                toDoTaskList = _dbRepository.Where<ToDoTask>(e => e.ToDoId == request.Id && e.Completed==false);
            }

            response.ToDoTaskList = new List<ToDoTaskServiceModel>();

            if (toDoTaskList == null) return response;
            foreach (var item in toDoTaskList)
            {
                response.ToDoTaskList.Add(new ToDoTaskServiceModel
                {
                    Id = item.Id,
                    ExpireDateTime = item.ExpireDateTime,
                    ToDoId = item.ToDoId,
                    TaskName = item.TaskName,
                    Completed = item.Completed,
                    Description = item.Description
                });
            }


            return response;

        }

        public GetToDoListRs GetToDoList(GetToDoListRq request)
        {
            var response = new GetToDoListRs();

            var result = _dbRepository.Where<ToDo>(e => e.UserId ==request.UserId).ToList();

            response.ToDoList = new List<ToDoModel>();
            foreach (var item in result)
            {
                response.ToDoList.Add(new ToDoModel { Id = item.Id, Name = item.Name });
            }

            return response;

        }
    }
}
