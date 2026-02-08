namespace FluentResults.HttpMapping.Context;

/// <summary>
/// Immutable context object passed to HTTP mapping rules.
///
/// <para>
/// This type represents a read-only snapshot of a
/// <see cref="FluentResults.Result"/> or <see cref="Result{T}"/> after an
/// endpoint has executed.
/// </para>
///
/// <para>
/// It exposes only the information that mapping rules are allowed to inspect,
/// ensuring rules remain deterministic, side-effect free, and independent of
/// ASP.NET infrastructure.
/// </para>
/// </summary>
public sealed class HttpResultMappingContext
{
    /// <summary>
    /// Gets the underlying FluentResults result returned by the endpoint.
    /// </summary>
    public IResultBase Result { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpResultMappingContext"/> class
    /// for the specified FluentResults result.
    /// </summary>
    /// <param name="result">
    /// The FluentResults result produced by an endpoint.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="result"/> is <c>null</c>.
    /// </exception>
    public HttpResultMappingContext(IResultBase result)
    {
        Result = result ?? throw new ArgumentNullException(nameof(result));
    }
}
