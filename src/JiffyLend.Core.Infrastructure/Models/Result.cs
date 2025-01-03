namespace JiffyLend.Module.Core.Application.Common.Models;

public class Result<TValue>
{
    public bool IsSuccess { get; init; }
    public int Code { get; set; }
    public string Message { get; set; }
    public TValue Data { get; init; }
    public string TraceIdentifier { get; set; }

    public string[] Errors { get; set; }

    public Result(TValue data)
    {
        IsSuccess = true;
        Data = data;
    }

    public Result(string[] errors)
    {
        IsSuccess = false;
        Errors = errors;
    }

    public static Result<TValue> Success(TValue data)
        => new(data);

    public static Result<TValue> Failure(string[] errors)
        => new(errors);

    public static implicit operator Result<TValue>(TValue data)
        => new(data);

    public static implicit operator Result<TValue>(string[] errors)
        => new(errors);

    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<string[], TResult> failure)
    {
        return IsSuccess ? success(Data!) : failure(Errors);
    }
}