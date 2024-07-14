using System;
namespace DatabaseCore;

public interface IGetQuery<TResponse>
{
    Task<TResponse> Query(CancellationToken token = default);
}

public interface IGetQuery<TParameters, TResponse>
{
    Task<TResponse> Query(TParameters parameters, CancellationToken token = default);
}