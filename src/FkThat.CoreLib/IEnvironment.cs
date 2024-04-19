using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace FkThat.CoreLib;

/// <summary>
/// Provides information about, and means to manipulate, the current environment and platform.
/// </summary>
public interface IEnvironment
{
    /// <summary>
    /// Gets a unique identifier for the current managed thread.
    /// </summary>
    int CurrentManagedThreadId { get; }

    /// <summary>
    /// Gets or sets the exit code of the process.
    /// </summary>
    int ExitCode { get; set; }

    /// <summary>
    /// Gets the number of milliseconds elapsed since the system started.
    /// </summary>
    int TickCount { get; }

    /// <summary>
    /// Gets the number of milliseconds elapsed since the system started.
    /// </summary>
    long TickCount64 { get; }

    /// <summary>
    /// Gets the number of processors available to the current process.
    /// </summary>
    int ProcessorCount { get; }

    /// <summary>
    /// Gets a value that indicates whether the current process is authorized to perform
    /// security-relevant functions.
    /// </summary>
    bool IsPrivilegedProcess { get; }

    /// <summary>
    /// Gets a value that indicates whether the current application domain is being unloaded or the
    /// common language runtime (CLR) is shutting down.
    /// </summary>
    bool HasShutdownStarted { get; }

    /// <summary>
    /// Gets the command line for this process.
    /// </summary>
    string CommandLine { get; }

    /// <summary>
    /// Gets or sets the fully qualified path of the current working directory.
    /// </summary>
    string CurrentDirectory { get; set; }

    /// <summary>
    /// Gets the unique identifier for the current process.
    /// </summary>
    int ProcessId { get; }

    /// <summary>
    /// Returns the path of the executable that started the currently executing process. Returns
    /// null when the path is not available.
    /// </summary>
    string? ProcessPath { get; }

    /// <summary>
    /// Gets a value that indicates whether the current process is a 64-bit process.
    /// </summary>
    bool Is64BitProcess { get; }

    /// <summary>
    /// Gets a value that indicates whether the current operating system is a 64-bit operating
    /// system.
    /// </summary>
    bool Is64BitOperatingSystem { get; }

    /// <summary>
    /// Gets the newline string defined for this environment.
    /// </summary>
    string NewLine { get; }

    /// <summary>
    /// Gets the current platform identifier and version number.
    /// </summary>
    OperatingSystem OSVersion { get; }

    /// <summary>
    /// Gets a version consisting of the major, minor, build, and revision numbers of the common
    /// language runtime.
    /// </summary>
    Version Version { get; }

    /// <summary>
    /// Gets current stack trace information.
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Not testable by design.")]
    string StackTrace { get; }

    /// <summary>
    /// Gets the number of bytes in the operating system's memory page.
    /// </summary>
    int SystemPageSize { get; }

    /// <summary>
    /// Gets the user name of the person who is associated with the current thread.
    /// </summary>
    string UserName { get; }

    /// <summary>
    /// Gets the network domain name associated with the current user.
    /// </summary>
    string UserDomainName { get; }

    /// <summary>
    /// Gets the NetBIOS name of this local computer.
    /// </summary>
    string MachineName { get; }

    /// <summary>
    /// Gets the fully qualified path of the system directory.
    /// </summary>
    string SystemDirectory { get; }

    /// <summary>
    /// Gets a value indicating whether the current process is running in user interactive mode.
    /// </summary>
    bool UserInteractive { get; }

    /// <summary>
    /// Gets the amount of physical memory mapped to the process context.
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Not testable by design.")]
    long WorkingSet { get; }

    /// <summary>
    /// </summary>
    /// <param name="exitCode"></param>
    [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords",
        Justification = "Named for consistency with System.Environment.Exit.")]
    void Exit(int exitCode);

    /// <summary>
    /// Immediately terminates the process before reporting an error message. For Windows, the error
    /// message is written to the Windows Application event log, and the message is included in
    /// error reporting to Microsoft. For Unix-like systems, the message, alongside the stack trace,
    /// is written to the standard error stream.
    /// </summary>
    /// <param name="message">
    /// A message that explains why the process was terminated, or <see langword="null"/> if no
    /// explanation is provided.
    /// </param>
    void FailFast(string? message);

    /// <summary>
    /// Immediately terminates the process before reporting an error message. For Windows, the error
    /// message is written to the Windows Application event log, and the message and exception
    /// information is included in error reporting to Microsoft. For Unix-like systems, the message
    /// alongside the stack trace is written to the standard error stream.
    /// </summary>
    /// <param name="message">
    /// A message that explains why the process was terminated, or <see langword="null"/> if no
    /// explanation is provided.
    /// </param>
    /// <param name="exception">
    /// An exception that represents the error that caused the termination. This is typically the
    /// exception in a catch block.
    /// </param>
    void FailFast(string? message, Exception exception);

    /// <summary>
    /// Retrieves the value of an environment variable from the current process.
    /// </summary>
    /// <param name="variable">The name of the environment variable.</param>
    /// <returns>
    /// The value of the environment variable specified by variable, or <see langword="null"/> if
    /// the environment variable is not found.
    /// </returns>
    string? GetEnvironmentVariable(string variable);

    /// <summary>
    /// Retrieves the value of an environment variable from the current process or from the Windows
    /// operating system registry key for the current user or local machine.
    /// </summary>
    /// <param name="variable">The name of the environment variable.</param>
    /// <param name="target">
    /// One of the <see cref="EnvironmentVariableTarget"/> values. Only <see
    /// cref="EnvironmentVariableTarget.Process"/> is supported on .NET running on Unix-like
    /// systems.
    /// </param>
    /// <returns>
    /// The value of the environment variable specified by variable, or <see langword="null"/> if
    /// the environment variable is not found.
    /// </returns>
    string? GetEnvironmentVariable(string variable, EnvironmentVariableTarget target);

    /// <summary>
    /// Retrieves all environment variable names and their values from the current process.
    /// </summary>
    /// <returns></returns>
    IDictionary GetEnvironmentVariables();

    /// <summary>
    /// Retrieves all environment variable names and their values from the current process, or from
    /// the Windows operating system registry key for the current user or local machine.
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target);

    /// <summary>
    /// Creates, modifies, or deletes an environment variable stored in the current process.
    /// </summary>
    /// <param name="variable">The name of an environment variable.</param>
    /// <param name="value">A value to assign to variable.</param>
    void SetEnvironmentVariable(string variable, string? value);

    /// <summary>
    /// Creates, modifies, or deletes an environment variable stored in the current process or in
    /// the Windows operating system registry key reserved for the current user or local machine.
    /// </summary>
    /// <param name="variable">The name of an environment variable.</param>
    /// <param name="value">A value to assign to variable.</param>
    /// <param name="target">
    /// One of the enumeration values that specifies the location of the environment variable.
    /// </param>
    void SetEnvironmentVariable(string variable, string? value, EnvironmentVariableTarget target);

    /// <summary>
    /// Replaces the name of each environment variable embedded in the specified string with the
    /// string equivalent of the value of the variable, then returns the resulting string.
    /// </summary>
    /// <param name="name">
    /// A string containing the names of zero or more environment variables. Each environment
    /// variable is quoted with the percent sign character (%).
    /// </param>
    /// <returns>A string with each environment variable replaced by its value.</returns>
    string ExpandEnvironmentVariables(string name);

    /// <summary>
    /// Returns a string array containing the command-line arguments for the current process.
    /// </summary>
    string[] GetCommandLineArgs();

    /// <summary>
    /// Gets the path to the specified system special folder.
    /// </summary>
    /// <param name="folder">
    /// One of the enumeration values that identifies a system special folder.
    /// </param>
    string GetFolderPath(Environment.SpecialFolder folder);

    /// <summary>
    /// Gets the path to the specified system special folder using a specified option for accessing
    /// special folders.
    /// </summary>
    /// <param name="folder">
    /// One of the enumeration values that identifies a system special folder.
    /// </param>
    /// <param name="option">
    /// One of the enumeration values that specifies options to use for accessing a special folder.
    /// </param>
    [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords",
        Justification = "Named such for consistency with the System.Environment class.")]
    string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option);

    /// <summary>
    /// Returns an array of string containing the names of the logical drives on the current
    /// computer.
    /// </summary>
    string[] GetLogicalDrives();
}
