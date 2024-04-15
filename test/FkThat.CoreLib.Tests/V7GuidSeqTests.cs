namespace FkThat.CoreLib;

public class V7GuidSeqTests
{
    [Fact]
    public void CompareAjust_resets_seq()
    {
        V7GuidSeq sut = new(42, 69);

        var msec = 43L;
        ushort seq = 0;
        sut.CompareAjust(ref msec, ref seq);

        msec.Should().Be(43L);
        seq.Should().Be(0);

        sut.Msec.Should().Be(43L);
        sut.Seq.Should().Be(0);
    }

    [Fact]
    public void CompareAjust_increses_seq()
    {
        V7GuidSeq sut = new(42, 69);

        var msec = 42L;
        ushort seq = 0;
        sut.CompareAjust(ref msec, ref seq);

        msec.Should().Be(42L);
        seq.Should().Be(70);

        sut.Msec.Should().Be(42L);
        sut.Seq.Should().Be(70);
    }
}
