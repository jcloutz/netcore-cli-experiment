using System.Threading.Tasks;

namespace CLITaskRunner.Core.Tasks
{
    public interface ITaskSequenceRunner<TTaskType> where TTaskType : Enumeration
    {
        ITaskSequenceRunner<TTaskType> Add(TTaskType key);
        Task<int> Run();
    }

    public interface ITaskSequenceRunner<TTaskType, TOptions> where TTaskType : Enumeration
    {
        ITaskSequenceRunner<TTaskType, TOptions> Add(TTaskType key);
        Task<int> Run(TOptions options);
    }
}