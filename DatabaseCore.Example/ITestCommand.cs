namespace DatabaseCore.Example
{
    public interface ITestCommand
    {
        Task<int> Save(int parameters, CancellationToken token = default);
    }
}