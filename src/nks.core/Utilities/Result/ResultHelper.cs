namespace nks.core;

public static class ResultHelper
{
    public static Result SuccessResult()
    {
        return new Result(Status.Success);
    }
    public static Result ErrorResult(string message)
    {
        return new Result(Status.Error, message);
    }
    public static Result WarningResult(string message)
    {
        return new Result(Status.Warning, message);
    }
    public static Result ExceptionResult(Exception ex)
    {
        return new Result(Status.Exception, ex.Message);
    }
    public static DataResult<T> SuccessResult<T>(T data)
    {
        return new DataResult<T>(data, Status.Success);
    }
}
