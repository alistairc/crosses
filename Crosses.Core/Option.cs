namespace Crosses.Core;

public record Option<T>
{
    Option() {}
    
    bool HasValue { get; init; }
    T Value { get; init; } = default!;

    public static Option<T> Some(T value) => new() { HasValue = true, Value = value };
    public static readonly Option<T> None =new() { HasValue = false };
    
    public TResult Match<TResult>(Func<T, TResult> onSome, Func<TResult> onNone)
    {
        return HasValue ? onSome(Value) : onNone();
    }

    public Option<TResult> Select<TResult>(Func<T, TResult> selector)
    {
        return Match(
            value => Option<TResult>.Some(selector(value)),
            () => Option<TResult>.None
        );
    }

    public Option<TResult> SelectMany<TResult>(Func<T, Option<TResult>> selector)
    {
        return Select(selector).Match(some => some, () => Option<TResult>.None);
    }

    public Option<TResult> SelectMany<TMiddle, TResult>(
        Func<T, Option<TMiddle>> middleSelector,
        Func<T, TMiddle, TResult> resultSelector)
    {
        return SelectMany(x => middleSelector(x).Select(y => resultSelector(x, y)));
    }
}