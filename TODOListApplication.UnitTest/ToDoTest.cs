using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODOListApplication.Business.Services.Interfaces;
using TODOListApplication.Core;
using TODOListApplication.ServiceModel.ToDo;

namespace TODOListApplication.UnitTest
{
    [TestClass]
    public class ToDoTest:BaseTestClass
    {
        /// <summary>
        /// Get ToDo List test Unit Test
        /// </summary>
        [TestMethod]
        public void GetToDoListTest()
        {
            var todoService = IocContainer.Resolve<IToDoService>();
            var response =todoService.GetToDoList(new GetToDoListRq {UserId = 1});
            Assert.IsTrue(response.ToDoList.Count >0);
        }

        /// <summary>
        /// Test  ToDo task get list unit test
        /// </summary>
        [TestMethod]
        public void GoToDoByIdTest()
        {
            var todoService = IocContainer.Resolve<IToDoService>();
            var response = todoService.GetToDoById(new GetToDoRq {Id = 4});
            Assert.IsTrue(response.ToDoTaskList.Count > 0);
        }
        /// <summary>
        /// Test ToDO Task delete service unit test
        /// </summary>
        [TestMethod]
        public void DeleteTodoByIdTest()
        {
            var todoService = IocContainer.Resolve<IToDoService>();
            var response = todoService.DeleteTodoById(id: 2);
            Assert.IsTrue(response);
        }
    }
}
