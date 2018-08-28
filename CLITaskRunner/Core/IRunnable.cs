using System.Threading.Tasks;

namespace CLITaskRunner.Core
{
    public interface IRunnable
    {
        Task<int> Run();
    }

    public interface IRunnable<TOptions>
    {
        Task<int> Run(TOptions options);
    }
}