namespace Johns.Lyng.Todo.Api.Helpers
{
    public class Conversion : IConvert
    {
        private Conversion() { }

        private static Conversion _instance;
        public static Conversion Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Conversion();
                }
                return _instance;
            }

        }

        public Model.UserTask ConvertToModelTaskItem(ViewModel.Task viewModel)
        {
            return new Model.UserTask()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Description = viewModel.Description
            };
        }


        public Model.UserTaskList ConvertToModelTaskList(ViewModel.TaskList taskList)
        {
            var tasks = new List<Model.UserTask>();
            if (taskList != null && taskList.Tasks != null && taskList.Tasks.Any())
            {
                foreach (var task in taskList.Tasks)
                {
                    ConvertToModelTaskItem(task);
                }
            }

            return new Model.UserTaskList()
            {
                Id = taskList.Id,
                Title = taskList.Title,
                Tasks = tasks
            };
        }

        public ViewModel.Task ConvertToViewModelTaskItem(Model.UserTask task)
        {
            return new ViewModel.Task()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };
        }

        public ViewModel.TaskList ConvertToViewModelTaskList(Model.UserTaskList taskList)
        {
            var tasks = new List<ViewModel.Task>();
            if (taskList != null && taskList.Tasks!= null && taskList.Tasks.Any()) {
                foreach (var task in taskList.Tasks)
                {
                    ConvertToViewModelTaskItem(task);
                }
            }

            return new ViewModel.TaskList()
            {
                Id = taskList.Id,
                Title = taskList.Title,
                Tasks = tasks
            };
        }
    }
}
