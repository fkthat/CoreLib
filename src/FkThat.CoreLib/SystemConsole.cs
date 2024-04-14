namespace FkThat.CoreLib;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Represents the system console.
/// </summary>
public sealed class SystemConsole : IConsoleText, IConsoleStdio, IConsoleKeyboard
{
    /// <inheritdoc/>
    public TextReader In => Console.In;

    /// <inheritdoc/>
    public TextWriter Out => Console.Out;

    /// <inheritdoc/>
    public TextWriter Error => Console.Error;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public bool KeyAvailable => Console.KeyAvailable;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public Stream OpenStandardInput() => Console.OpenStandardInput();

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public Stream OpenStandardOutput() => Console.OpenStandardOutput();

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public Stream OpenStandardError() => Console.OpenStandardError();

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);
}
