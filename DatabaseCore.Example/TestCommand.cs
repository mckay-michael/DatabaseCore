using System;

namespace DatabaseCore.Example;

public class TestCommand<TResponse, TParameters> : ISaveCommand<TResponse, TParameters>
{
    public Task<TResponse> Save(TParameters parameters)
    {
        throw new NotImplementedException();
    }
}

public class TestCommand<TResponse> : ISaveCommand<TResponse>
{
    Task ISaveCommand<TResponse>.Save(TResponse parameters)
    {
        throw new NotImplementedException();
    }
}