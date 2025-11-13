using Johns.Lyng.Todo.Api.Controllers;
using Johns.Lyng.Todo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Johns.Lyng.Todo.Api.Tests
{
    [TestClass]
    public sealed class TaskControllerTests
    {
        private ListController _listController;
        public TaskControllerTests()
        {
            _listController = new ListController();
        }

        [TestMethod]
        public void TestForGetMethod()
        {
            var newListForUser1 = new UserTaskList()
            {
                Id = 1,
                Title = "Test",
                Description = "Test Description",
                OwnerId = 1
            };

            _listController.DataStore.TaskLists.Add(newListForUser1);
            var result = _listController.GetListForUser(1);
            var actionResult = result.Result as OkObjectResult;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, StatusCodes.Status200OK);
        }


        [TestMethod]
        public async Task TestForCreateMethod()
        {
            var newListForUser1 = new ViewModel.TaskList()
            {
                Id = 1,
                Title = "Test",
                OwnerId = 1
            };

            var result = await _listController.CreateList(newListForUser1);
            var actionResult = result as OkObjectResult;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, StatusCodes.Status200OK);
        }

        [TestMethod]
        public async Task TestForUpdateMethod()
        {
            var newListForUser1 = new ViewModel.TaskList()
            {
                Id = 1,
                Title = "Test",
                OwnerId = 1
            };

            await _listController.CreateList(newListForUser1);

            var updatedListForUser1 = new ViewModel.TaskList()
            {
                Id = 1,
                Title = "Updated Test",
                OwnerId = 1
            };
            var result =  await _listController.UpdateList(updatedListForUser1);
            var actionResult = result as OkObjectResult;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, StatusCodes.Status200OK);
        }

        [TestMethod]
        public void TestForDeleteMethod()
        {
            var newListForUser1 = new UserTaskList()
            {
                Id = 1,
                Title = "Test",
                Description = "Test Description",
                OwnerId = 1
            };

            _listController.DataStore.TaskLists.Add(newListForUser1);
            var result = _listController.DeleteList(1);
            var actionResult = result.Result as OkObjectResult;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, StatusCodes.Status200OK);
        }
    }
}
