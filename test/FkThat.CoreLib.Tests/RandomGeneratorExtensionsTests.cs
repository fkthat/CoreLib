namespace FkThat.CoreLib;

public class RandomGeneratoreratorExtensionsTests
{
    [Fact]
    public void GetBytes_with_data_offset_count_should_check_null_random()
    {
        IRandomGenerator random = null!;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(random, new byte[4], 0, 4))
            .Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be(nameof(random));
    }

    [Fact]
    public void GetBytes_with_data_offset_count_should_check_null_data()
    {
        IRandomGenerator sut = A.Fake<FakeRandomGenerator>();
        byte[] data = null!;

        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(sut, data, 0, 4))
            .Should().Throw<ArgumentNullException>().Which.ParamName
            .Should().Be(nameof(data));
    }

    [Fact]
    public void GetBytes_with_data_offset_count_should_check_offset()
    {
        IRandomGenerator sut = A.Fake<FakeRandomGenerator>();

        // negative offset
        int offset = -1;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(sut, new byte[4], offset, 4))
            .Should().Throw<ArgumentOutOfRangeException>().Which.ParamName
            .Should().Be(nameof(offset));

        // too large offset
        offset = 4;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(sut, new byte[4], offset, 4))
            .Should().Throw<ArgumentOutOfRangeException>().Which.ParamName
            .Should().Be(nameof(offset));
    }

    [Fact]
    public void GetBytes_with_data_offset_count_should_check_count()
    {
        IRandomGenerator sut = A.Fake<FakeRandomGenerator>();

        // negative count
        int count = -1;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(sut, new byte[4], 0, count))
            .Should().Throw<ArgumentOutOfRangeException>().Which.ParamName
            .Should().Be(nameof(count));

        // too large count
        count = 5;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(sut, new byte[4], 0, count))
            .Should().Throw<ArgumentOutOfRangeException>().Which.ParamName
            .Should().Be(nameof(count));
    }

    [Fact]
    public void GetBytes_with_data_offset_count_should_fill_data()
    {
        byte[] data = new byte[] { 16, 112, 193, 67 };
        FakeRandomGenerator random = A.Fake<FakeRandomGenerator>();
        A.CallTo(() => random.GetFakeBytes(2)).Returns(new byte[] { 42, 73 });
        IRandomGenerator sut = random;
        RandomGeneratorExtensions.GetBytes(sut, data, 1, 2);
        data.Should().Equal(new byte[] { 16, 42, 73, 67 });
    }

    [Fact]
    public void GetBytes_with_data_should_check_null_random()
    {
        IRandomGenerator random = null!;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(random, new byte[4]))
            .Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be(nameof(random));
    }

    [Fact]
    public void GetBytes_with_data_should_check_null_data()
    {
        IRandomGenerator sut = A.Fake<FakeRandomGenerator>();
        byte[] data = null!;

        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(sut, data))
            .Should().Throw<ArgumentNullException>().Which.ParamName
            .Should().Be(nameof(data));
    }

    [Fact]
    public void GetBytes_with_data_should_fill_data()
    {
        byte[] data = new byte[] { 16, 112, 193, 67 };
        FakeRandomGenerator random = A.Fake<FakeRandomGenerator>();
        A.CallTo(() => random.GetFakeBytes(4)).Returns(new byte[] { 235, 55, 221, 159 });
        IRandomGenerator sut = random;
        RandomGeneratorExtensions.GetBytes(sut, data);
        data.Should().Equal(new byte[] { 235, 55, 221, 159 });
    }

    [Fact]
    public void GetBytes_with_count_should_check_null_random()
    {
        IRandomGenerator random = null!;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(random, 4))
            .Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be(nameof(random));
    }

    [Fact]
    public void GetBytes_with_count_should_check_count()
    {
        IRandomGenerator sut = A.Fake<FakeRandomGenerator>();
        int count = -1;

        FluentActions.Invoking(() => RandomGeneratorExtensions.GetBytes(sut, count))
            .Should().Throw<ArgumentOutOfRangeException>().Which.ParamName
            .Should().Be(nameof(count));
    }

    [Fact]
    public void GetBytes_with_count_should_return_data()
    {
        FakeRandomGenerator random = A.Fake<FakeRandomGenerator>();

        A.CallTo(() => random.GetFakeBytes(4))
            .Returns(new byte[] { 235, 55, 221, 159 });

        IRandomGenerator sut = random;
        byte[] actual = RandomGeneratorExtensions.GetBytes(sut, 4);
        actual.Should().Equal(new byte[] { 235, 55, 221, 159 });
    }

    [Fact]
    public void GetInt32_with_toExclusive_should_check_null_random()
    {
        IRandomGenerator random = null!;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetInt32(random, 42))
            .Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be(nameof(random));
    }

    [Fact]
    public void GetInt32_with_toExclusive_should_check_toExclusive()
    {
        IRandomGenerator sut = A.Fake<FakeRandomGenerator>();

        int toExclusive = 0;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetInt32(sut, toExclusive))
            .Should().Throw<ArgumentOutOfRangeException>().Which.ParamName
            .Should().Be(nameof(toExclusive));

        toExclusive = -1;
        FluentActions.Invoking(() => sut.GetInt32(toExclusive))
            .Should().Throw<ArgumentOutOfRangeException>().Which.ParamName
            .Should().Be(nameof(toExclusive));
    }

    [Fact]
    public void GetInt32_with_toExclusive_should_return_random_int()
    {
        FakeRandomGenerator random = A.Fake<FakeRandomGenerator>();

        A.CallTo(() => random.GetFakeBytes(4))
            .Returns(new byte[] { 0xff, 0xff, 0xff, 0xff }).Once().Then
            .Returns(new byte[] { 0x44, 0x8a, 0x6d, 0x13 }).Once().Then
            .Returns(new byte[] { 0x00, 0x00, 0x00, 0x00 });

        IRandomGenerator sut = random;
        int actual = RandomGeneratorExtensions.GetInt32(sut, 42);
        actual.Should().Be(4);
    }

    [Fact]
    public void GetInt32_with_fromInclusive_toExclusive_should_check_null_random()
    {
        IRandomGenerator random = null!;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetInt32(random, 42, 69))
            .Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be(nameof(random));
    }

    [Fact]
    public void GetInt32_with_fromInclusive_toExclusive_should_check_toExclusive()
    {
        IRandomGenerator sut = A.Fake<FakeRandomGenerator>();

        int toExclusive = 42;
        FluentActions.Invoking(() => sut.GetInt32(42, toExclusive))
            .Should().Throw<ArgumentOutOfRangeException>().Which.ParamName
            .Should().Be(nameof(toExclusive));

        toExclusive = 41;
        FluentActions.Invoking(() => RandomGeneratorExtensions.GetInt32(sut, 42, toExclusive))
            .Should().Throw<ArgumentOutOfRangeException>().Which.ParamName
            .Should().Be(nameof(toExclusive));
    }

    [Fact]
    public void GetInt32_with_fromInclusive_toExclusive_should_return_random_int()
    {
        FakeRandomGenerator random = A.Fake<FakeRandomGenerator>();

        A.CallTo(() => random.GetFakeBytes(4))
            .Returns(new byte[] { 0xff, 0xff, 0xff, 0xff }).Once().Then
            .Returns(new byte[] { 0x44, 0x8a, 0x6d, 0x13 }).Once().Then
            .Returns(new byte[] { 0x00, 0x00, 0x00, 0x00 });

        IRandomGenerator sut = random;
        int actual = RandomGeneratorExtensions.GetInt32(sut, 42, 73);
        actual.Should().Be(46);
    }
}

internal abstract class FakeRandomGenerator : IRandomGenerator
{
    public void GetBytes(Span<byte> data) =>
        new Span<byte>(GetFakeBytes(data.Length)).CopyTo(data);

    public abstract byte[] GetFakeBytes(int count);
}
