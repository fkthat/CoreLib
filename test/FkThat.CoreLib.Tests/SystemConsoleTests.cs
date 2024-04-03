namespace FkThat.CoreLib;

public sealed class SystemConsoleTests
{
    [Fact]
    public void In_should_return_Console_In()
    {
        SystemConsole sut = new();
        sut.In.Should().Be(System.Console.In);
    }

    [Fact]
    public void Out_should_return_Console_Out()
    {
        SystemConsole sut = new();
        sut.Out.Should().Be(System.Console.Out);
    }

    [Fact]
    public void Error_should_return_Console_Error()
    {
        SystemConsole sut = new();
        sut.Error.Should().Be(System.Console.Error);
    }
}
