using System;

namespace CLITaskRunner.Core.Tasks
{
    public interface ITaskLoader<TTaskType, TRunnable>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        TRunnable Get(TTaskType key);
    }
}