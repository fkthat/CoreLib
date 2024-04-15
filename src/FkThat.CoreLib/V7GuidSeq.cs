namespace FkThat.CoreLib;

internal sealed class V7GuidSeq : IV7GuidSeq
{
    private static readonly Lazy<IV7GuidSeq> _singleton = new(() => new V7GuidSeq());

    private readonly object _lock = new();

    /// <summary>
    /// The constructor for unit tests.
    /// </summary>
    internal V7GuidSeq(long msec, ushort seq)
    {
        Msec = msec;
        Seq = seq;
    }

    private V7GuidSeq()
    {
    }

    public static IV7GuidSeq Singleton => _singleton.Value;

    internal long Msec { get; private set; }

    internal ushort Seq { get; private set; }

    public void CompareAjust(ref long msec, ref ushort seq)
    {
        lock (_lock)
        {
            if (msec > Msec)
            {
                Msec = msec;
                Seq = 0;
                seq = 0;
            }
            else
            {
                msec = Msec;
                seq = ++Seq;
            }
        }
    }
}
