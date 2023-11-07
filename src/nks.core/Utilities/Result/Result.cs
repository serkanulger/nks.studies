namespace nks.core;

public class Result : IResult
{
    public Status Status { get; } 

    public string Message { get; }
    public Result(Status status)
        : this (status, status.ToString())
    {
    }
    
    public Result(Status status, string message)
    {
        Status = status;
        Message = message;
    }
}

public class DataResult<T> : Result, IResult<T>
{
    public T? Data {get; internal set;} = default;

    public DataResult(T data, Status status)
    : base(status)
    {
        Data = data;
    }

    public DataResult(T data, Status status, string message)
    : base(status, message)
    {
        Data = data;
    }
}
