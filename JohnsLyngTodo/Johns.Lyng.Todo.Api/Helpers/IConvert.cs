namespace Johns.Lyng.Todo.Api.Helpers
{
    public interface IConvert
    {
        Model.UserTaskList ConvertToModelTaskList(ViewModel.TaskList viewModel);
        Model.UserTask ConvertToModelTaskItem(ViewModel.Task viewModel);
        ViewModel.TaskList ConvertToViewModelTaskList(Model.UserTaskList model);
        ViewModel.Task ConvertToViewModelTaskItem(Model.UserTask model);
    }
}
