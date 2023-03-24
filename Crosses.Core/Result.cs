namespace Crosses.Core;

public record Result<TSuccess, TFailure>
{
    Result()
    {
    }

    bool IsSuccess { get; init; }
    TSuccess SuccessResult { get; init; } = default!;
    TFailure FailureResult { get; init; } = default!;

    public static Result<TSuccess, TFailure> Success(TSuccess result)
    {
        return new Result<TSuccess, TFailure>
        {
            IsSuccess = true,
            SuccessResult = result,
            FailureResult = default!
        };
    }

    public static Result<TSuccess, TFailure> Failure(TFailure result)
    {
        return new Result<TSuccess, TFailure>
        {
            IsSuccess = false,
            SuccessResult = default!,
            FailureResult = result
        };
    }

    public T Match<T>(Func<TSuccess, T> onSuccess, Func<TFailure, T> onFailure)
    {
        return IsSuccess ? onSuccess(SuccessResult) : onFailure(FailureResult);
    }

    public Result<T, TFailure> Select<T>(Func<TSuccess, T> selector)
    {
        return Match(
            value => Result<T, TFailure>.Success(selector(value)),
            Result<T, TFailure>.Failure);
    }
    
    public Result<T, TFailure> SelectMany<T>(Func<TSuccess, Result<T, TFailure>> selector)
    {
        return Select(selector).Match(success => success, Result<T, TFailure>.Failure);
    }

    public Result<TResult, TFailure> SelectMany<TMiddle, TResult>(
        Func<TSuccess, Result<TMiddle, TFailure>> middleSelector,
        Func<TSuccess, TMiddle, TResult> resultSelector)
    {
        return SelectMany(x => middleSelector(x).Select(y => resultSelector(x, y)));
    }
}