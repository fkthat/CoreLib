namespace FkThat.CoreLib;

/// <summary>
/// Represents a random number generator.
/// </summary>
public interface IRandomGenerator
{
    /// <summary>
    /// Fills a span with random bytes.
    /// </summary>
    /// <param name="data">The span to fill with random bytes.</param>
    void GetBytes(Span<byte> data);
}
