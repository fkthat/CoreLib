using System.Diagnostics.CodeAnalysis;

namespace FkThat.CoreLib;

/// <summary>
/// Provides access to the console text input/output.
/// </summary>
public interface IConsoleText
{
    /// <summary>
    /// Gets the standard input stream.
    /// </summary>
    [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords",
        Justification = "Named after the System.Console.")]
    TextReader In { get; }

    /// <summary>
    /// Gets the standard output stream.
    /// </summary>
    TextWriter Out { get; }

    /// <summary>
    /// Gets the standard error stream.
    /// </summary>
    [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords",
        Justification = "Named after the System.Console.")]
    TextWriter Error { get; }
}
