namespace FkThat.CoreLib;

public class V4GuidGeneratorTests
{
    [Fact]
    public void NewGuid_should_return_unique_values()
    {
        V4GuidGenerator sut = new();
        var r = Enumerable.Repeat(0, 42).Select(_ => sut.NewGuid());
        r.Should().OnlyHaveUniqueItems();
    }
}
