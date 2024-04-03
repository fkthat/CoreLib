using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace FkThat.CoreLib;

/// <summary>
/// Represents the secure random number generator that uses <c cref="RandomNumberGenerator"/>.
/// </summary>
public sealed class CryptoRandomGenerator : IRandomGenerator
{
    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public void GetBytes(Span<byte> data)
    {
        RandomNumberGenerator.Fill(data);
    }
}
