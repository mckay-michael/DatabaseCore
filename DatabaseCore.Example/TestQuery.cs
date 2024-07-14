using System;

namespace DatabaseCore.Example;

public class TestQuery : IGetQuery<string, string>
{
    public Task<string> Query(string parameters, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}

public class TestQuery1 : IGetQuery<string>, ITestQuery1
{
    public Task<string> Query(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}