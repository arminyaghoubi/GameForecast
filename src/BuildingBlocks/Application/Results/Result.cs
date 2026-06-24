namespace BuildingBlocks.Application.Results;

public class Result
{
    public bool IsSuccess { get; }

    public Error Error { get; }

    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException("Successful result cannot have an error.");


        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException("Failure result must have an error.");


        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);
}

public class Result<T> : Result
{
    public T? Data { get; }

    protected Result(T data) : base(true, Error.None)
    {
        Data = data;
    }

    protected Result(Error error) : base(false, error)
    {
        Data = default;
    }

    public static Result<T> Success(T data) => new(data);

    public static new Result<T> Failure(Error error) => new(error);
}