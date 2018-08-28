using System;
using System.Collections.Generic;
using Autofac.Features.Indexed;

namespace CLITaskRunner.Core.Tasks
{
    public class TaskLoader<TTaskType, TRunnable> : ITaskLoader<TTaskType, TRunnable>
    {
        
        private readonly IIndex<TTaskType, TRunnable> _tasks;
        protected IList<TRunnable> _sequenceTasks { get; set; }

        public TaskLoader(IIndex<TTaskType, TRunnable> tasks)
        {
            _tasks = tasks;
        }
        
        /// <summary>
         /// 
         /// </summary>
         /// <param name="key"></param>
         /// <returns></returns>
         /// <exception cref="Exception"></exception>
        public TRunnable Get(TTaskType key)
        {
            TRunnable task;

            if (_tasks.TryGetValue(key, out task) == false)
                throw new Exception($"Unable to locate task with {key.ToString()}");

            return task;
        }
    }

}