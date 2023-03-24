namespace Crosses.Tests;

static class ResultTestExtensions
{
    public static TSuccess ShouldSucceed<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
    {
        return result.Match(
            success => success,
            failure =>
            {
                Assert.Fail($"Expected Success, but was Failure: {failure}");
                return default!; // suppress null warning -  we'll never actually hit this line
            });
    }

    public static TFailure ShouldFail<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
    {
        return result
            .Match(success =>
                {
                    Assert.Fail($"Expected Failure but was Success {success}");
                    return default!; // suppress null warning -  we'll never actually hit this line
                },
                failure => failure);
    }
}