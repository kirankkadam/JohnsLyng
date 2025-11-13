using Johns.Lyng.Todo.Model;

namespace Johns.Lyng.Todo.Api.DataStore
{
    public sealed class InMemory
    {

        private static InMemory _instance;
        private static List<UserTaskList> _taskLists { get; set; }

        private InMemory()
        {
        }


        public static InMemory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InMemory();
                    _taskLists = new List<UserTaskList>();
                }
                return _instance;
            }
        }


        public List<UserTaskList> TaskLists
        {
            get
            {
                return _taskLists;
            }
        }
    }
}
