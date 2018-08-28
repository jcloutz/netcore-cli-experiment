
using CLITaskRunner.Core;

namespace CLITaskRunner.Tasks
{
    sealed class TaskTypes : Enumeration
    {
        public static readonly TaskTypes LoadPosts = new TaskTypes(1, "Load Posts");
        
        private TaskTypes() { }

        private TaskTypes(int value, string displayName) : base(value, displayName)
        {
        }
    }
}