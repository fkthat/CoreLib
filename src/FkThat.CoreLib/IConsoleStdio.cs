namespace FkThat.CoreLib;

/// <summary>
/// Provides access to the console text input/output.
/// </summary>
public interface IConsoleStdio
{
    /// <summary>
    /// Acquires the standard input stream.
    /// </summary>
    /// <returns>The standard input stream.</returns>
    Stream OpenStandardInput();

    /// <summary>
    /// Acquires the standard output stream.
    /// </summary>
    /// <returns>The standard output stream.</returns>
    Stream OpenStandardOutput();

    /// <summary>
    /// Acquires the standard error stream.
    /// </summary>
    /// <returns>The standard error stream.</returns>
    Stream OpenStandardError();
}
