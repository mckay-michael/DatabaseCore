using System;
namespace DatabaseCore;

public interface IGetQuery<TResponse>
{
    Task<TResponse> Query();
}

public interface IGetQuery<TResponse, TParameters>
{
    Task<TResponse> Query(TParameters parameters);
}