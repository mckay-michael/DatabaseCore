using System;
namespace DatabaseCore;

public interface ISaveCommand<TParameters>
{
    Task Save(TParameters parameters, CancellationToken token = default);
}

public interface ISaveCommand<TParameters, TResponse>
{
    Task<TResponse> Save(TParameters parameters, CancellationToken token = default);
}