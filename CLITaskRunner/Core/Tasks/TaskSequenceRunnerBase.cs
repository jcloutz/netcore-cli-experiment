using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CLITaskRunner.Core.Tasks
{
    public abstract class TaskSequenceRunnerBase<TTaskType, TRunnable> where TTaskType : Enumeration
    {
        protected ITaskLoader<TTaskType, TRunnable> TaskLoader;
        protected IList<TTaskType> SequenceTasks { get; set; }

        public TaskSequenceRunnerBase(ITaskLoader<TTaskType, TRunnable> taskLoader)
        {
            TaskLoader = taskLoader;
        }

        protected TaskSequenceRunnerBase<TTaskType, TRunnable> AddTaskToSequence(TTaskType key)
        {
            SequenceTasks.Add(key);
            
            return this;
        }
    }
}