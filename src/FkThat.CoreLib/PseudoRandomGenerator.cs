using System.Diagnostics.CodeAnalysis;

namespace FkThat.CoreLib;

/// <summary>
/// Represents the random number generator that uses <c cref="Random"/>.
/// </summary>
public sealed class PseudoRandomGenerator : IRandomGenerator
{
    /// <inheritdoc/>
    [SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
    [ExcludeFromCodeCoverage]
    public void GetBytes(Span<byte> data)
    {
        Random.Shared.NextBytes(data);
    }
}
