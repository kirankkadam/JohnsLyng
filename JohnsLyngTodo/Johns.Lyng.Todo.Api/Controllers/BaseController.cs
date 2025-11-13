using Johns.Lyng.Todo.Api.Controllers.Interfaces;
using Johns.Lyng.Todo.Api.DataStore;
using Johns.Lyng.Todo.Model;
using Microsoft.AspNetCore.Mvc;

namespace Johns.Lyng.Todo.Api.Controllers
{
    public class BaseController : ControllerBase, IController
    {
        public List<User> Users { get; set; }
        public InMemory DataStore { get; set; }

        public BaseController()
        {
            Users = new List<User>();
            Users.Add(new User() { Id = 1, Name = "Kiran Kadam" });
            Users.Add(new User() { Id = 2, Name = "Peter Parker" });

            DataStore = InMemory.Instance;
        }
    }
}
