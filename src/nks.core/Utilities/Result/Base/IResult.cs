namespace nks.core;

public interface IResult
{
    Status Status { get; }
    string Message { get; }
}

public interface IResult<T> : IResult
{
    T? Data { get; }
}
