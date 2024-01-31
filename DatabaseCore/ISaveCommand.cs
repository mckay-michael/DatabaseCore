using System;
namespace DatabaseCore;

public interface ISaveCommand<TParameters>
{
    Task Save(TParameters parameters);
}

public interface ISaveCommand<TResponse, TParameters>
{
    Task<TResponse> Save(TParameters parameters);
}