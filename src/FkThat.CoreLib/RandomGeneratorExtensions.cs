using System.Runtime.InteropServices;

namespace FkThat.CoreLib;

/// <summary>
/// <c cref="IRandomGenerator"/> extension methods.
/// </summary>
public static class RandomGeneratorExtensions
{
    /// <summary>
    /// Fills an array with random bytes.
    /// </summary>
    /// <param name="random">The <c cref="IRandomGenerator"/> instance.</param>
    /// <param name="data">The array to fill.</param>
    /// <param name="offset">The index of the array to start the fill operation.</param>
    /// <param name="count">The number of bytes to fill.</param>
    public static void GetBytes(this IRandomGenerator random, byte[] data, int offset, int count)
    {
        _ = random ?? throw new ArgumentNullException(nameof(random));
        _ = data ?? throw new ArgumentNullException(nameof(data));

        if (offset < 0 || offset > data.Length - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(offset));
        }

        if (count < 0 || count > data.Length - offset)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        Span<byte> span = new(data, offset, count);
        random.GetBytes(span);
    }

    /// <summary>
    /// Fills an array with random bytes.
    /// </summary>
    /// <param name="random">The <c cref="IRandomGenerator"/> instance.</param>
    /// <param name="data">The array to fill.</param>
    public static void GetBytes(this IRandomGenerator random, byte[] data)
    {
        _ = random ?? throw new ArgumentNullException(nameof(random));
        _ = data ?? throw new ArgumentNullException(nameof(data));
        random.GetBytes(data, 0, data.Length);
    }

    /// <summary>
    /// Creates an array of bytes with a random sequence of values.
    /// </summary>
    /// <param name="random">The <c cref="IRandomGenerator"/> instance.</param>
    /// <param name="count">The number of bytes of random values to create.</param>
    /// <returns></returns>
    public static byte[] GetBytes(this IRandomGenerator random, int count)
    {
        ArgumentNullException.ThrowIfNull(random, nameof(random));
        ArgumentOutOfRangeException.ThrowIfNegative(count, nameof(count));

        byte[] data = new byte[count];
        random.GetBytes(data);
        return data;
    }

    /// <summary>
    /// Returns a non-negative random <c cref="int"/> less than the specified maximum.
    /// </summary>
    /// <param name="random">The <c cref="IRandomGenerator"/> instance.</param>
    /// <param name="toExclusive">The exclusive upper bound of the random number returned.</param>
    public static int GetInt32(this IRandomGenerator random, int toExclusive = int.MaxValue)
    {
        ArgumentNullException.ThrowIfNull(random, nameof(random));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(toExclusive, 0, nameof(toExclusive));

        uint mask = (uint)toExclusive - 1;
        mask |= mask >> 1;
        mask |= mask >> 2;
        mask |= mask >> 4;
        mask |= mask >> 8;
        mask |= mask >> 16;

        uint result = 0;
        Span<byte> span = MemoryMarshal.AsBytes(new Span<uint>(ref result));

        while (true)
        {
            random.GetBytes(span);
            result &= mask;

            if (result < toExclusive)
            {
                return (int)result;
            }
        }
    }

    /// <summary>
    /// Returns a random <c cref="int"/> within a specified range.
    /// </summary>
    /// <param name="random">The <c cref="IRandomGenerator"/> instance.</param>
    /// <param name="fromInclusive">The inclusive lower bound of the random number returned.</param>
    /// <param name="toExclusive">The exclusive upper bound of the random number returned.</param>
    public static int GetInt32(this IRandomGenerator random, int fromInclusive, int toExclusive)
    {
        ArgumentNullException.ThrowIfNull(random, nameof(random));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(toExclusive, fromInclusive, nameof(toExclusive));
        return random.GetInt32(toExclusive - fromInclusive) + fromInclusive;
    }
}
