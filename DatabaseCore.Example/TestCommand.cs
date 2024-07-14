using System;

namespace DatabaseCore.Example;

public class TestCommand : ISaveCommand<int, int>, ITestCommand
{
    public Task<int> Save(int parameters, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}

public class TestCommand1 : ISaveCommand<string>
{
    public Task Save(string parameters, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}