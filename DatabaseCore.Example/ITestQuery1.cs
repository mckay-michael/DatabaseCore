namespace DatabaseCore.Example
{
    public interface ITestQuery1
    {
        Task<string> Query(CancellationToken token = default);
    }
}