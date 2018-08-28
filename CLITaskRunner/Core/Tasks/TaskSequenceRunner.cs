using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CLITaskRunner.Core.Tasks
{
    public class TaskSequenceRunner<TTaskTypes>
        : TaskSequenceRunnerBase<TTaskTypes, IRunnable>, ITaskSequenceRunner<TTaskTypes> 
        where TTaskTypes : Enumeration
    {
        private readonly ILogger<TaskSequenceRunner<TTaskTypes>> _logger;

        public TaskSequenceRunner(
            ITaskLoader<TTaskTypes, IRunnable> taskLoader, 
            ILogger<TaskSequenceRunner<TTaskTypes>> logger) 
            : base(taskLoader)
        {
            _logger = logger;
        }

        public ITaskSequenceRunner<TTaskTypes> Add(TTaskTypes key)
        {
            AddTaskToSequence(key);

            return this;
        }

        public async Task<int> Run()
        {
            foreach (var taskKey in SequenceTasks)
            {
                _logger.LogInformation($"Starting: {taskKey.DisplayName}");
                var task = TaskLoader.Get(taskKey);
                
                await task.Run();
                _logger.LogInformation($"Finished: {taskKey.DisplayName}");
            }

            return 1;
        }
    }
    
    public class TaskSequenceRunner<TTaskTypes, TOptions> 
        : TaskSequenceRunnerBase<TTaskTypes, IRunnable<TOptions>>, ITaskSequenceRunner<TTaskTypes, TOptions>
        where TTaskTypes : Enumeration
    {
        private readonly ILogger<TaskSequenceRunner<TTaskTypes, IRunnable<TOptions>>> _logger;

        public TaskSequenceRunner(
            ITaskLoader<TTaskTypes, IRunnable<TOptions>> taskLoader,
            ILogger<TaskSequenceRunner<TTaskTypes, IRunnable<TOptions>>> logger) 
            : base(taskLoader)
        {
            _logger = logger;
        }

        public ITaskSequenceRunner<TTaskTypes, TOptions> Add(TTaskTypes key)
        {
            AddTaskToSequence(key);

            return this;
        }

        public async Task<int> Run(TOptions options)
        {
            foreach (var taskKey in SequenceTasks)
            {
                _logger.LogInformation($"Starting: {taskKey.DisplayName}");
                var task = TaskLoader.Get(taskKey);
                
                await task.Run(options);
                _logger.LogInformation($"Finished: {taskKey.DisplayName}");
            }
            
            return 1;
        }
    }
}