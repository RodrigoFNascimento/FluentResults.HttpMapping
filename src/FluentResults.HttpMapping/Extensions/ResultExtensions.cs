namespace FluentResults.HttpMapping.Extensions;

public static class ResultExtensions
{
    /// <summary>
    /// Gets the first reason of type <typeparamref name="TReason"/>
    /// attached to the result.
    /// </summary>
    /// <typeparam name="TReason">The expected reason type.</typeparam>
    /// <param name="result"></param>
    /// <returns>
    /// The first matching reason.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no reason of type <typeparamref name="TReason"/>
    /// is attached to the result.
    /// </exception>
    public static TReason FirstReason<TReason>(this IResultBase result)
        where TReason : IReason
    {
        return result.Reasons.OfType<TReason>().First();
    }

    /// <summary>
    /// Gets the first reason of type <typeparamref name="TReason"/>
    /// that contains the specified metadata key.
    /// </summary>
    /// <typeparam name="TReason">The expected reason type.</typeparam>
    /// <param name="result"></param>
    /// <param name="key">The metadata key that must be present on the reason.</param>
    /// <returns>
    /// The first matching reason.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no reason of type <typeparamref name="TReason"/> exists
    /// with the specified metadata key.
    /// </exception>
    public static TReason FirstReasonWithMetadata<TReason>(
        this IResultBase result,
        string key)
        where TReason : IReason
    {
        return result.Reasons
            .OfType<TReason>()
            .First(r => r.HasMetadataKey(key));
    }

    /// <summary>
    /// Retrieves all metadata values associated with the specified key
    /// across all reasons.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="key">The metadata key to retrieve.</param>
    /// <returns>
    /// A sequence of metadata values. The sequence is empty if the key
    /// is not present on any reason.
    /// </returns>
    public static IEnumerable<object?> GetMetadata(
        this IResultBase result,
        string key)
    {
        return result.Reasons
            .Where(r => r.Metadata.ContainsKey(key))
            .Select(r => r.Metadata[key]);
    }

    /// <summary>
    /// Gets all reasons of type <typeparamref name="TReason"/>
    /// attached to the result.
    /// </summary>
    /// <typeparam name="TReason">The reason type to retrieve.</typeparam>
    /// <param name="result"></param>
    /// <returns>
    /// A sequence of matching reasons. The sequence may be empty.
    /// </returns>
    public static IEnumerable<TReason> GetReasons<TReason>(
        this IResultBase result)
        where TReason : IReason
    {
        return result.Reasons.OfType<TReason>();
    }

    /// <summary>
    /// Determines whether any reason attached to the result contains
    /// metadata with the specified key.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="key">The metadata key to look for.</param>
    /// <returns>
    /// <c>true</c> if at least one reason contains the key; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasMetadata(
        this IResultBase result,
        string key)
    {
        return result.Reasons.Any(r => r.Metadata.ContainsKey(key));
    }
}
