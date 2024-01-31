using System;

namespace DatabaseCore.Example;

public class TestQuery<TResponse, TParameters> : IGetQuery<TResponse, TParameters>
{
    public Task<TResponse> Query(TParameters parameters)
    {
        throw new NotImplementedException();
    }
}

public class TestQuery<TResponse> :IGetQuery<TResponse>
{
    Task<TResponse> IGetQuery<TResponse>.Query()
    {
        throw new NotImplementedException();
    }
}