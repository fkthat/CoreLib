using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace FkThat.CoreLib;

/// <inheritdoc/>
public class SystemEnvironment : IEnvironment
{
    /// <inheritdoc/>
    public int CurrentManagedThreadId => Environment.CurrentManagedThreadId;

    /// <inheritdoc/>
    public int ExitCode
    {
        get => Environment.ExitCode;
        set => Environment.ExitCode = value;
    }

    /// <inheritdoc/>
    public int TickCount => Environment.TickCount;

    /// <inheritdoc/>
    public long TickCount64 => Environment.TickCount64;

    /// <inheritdoc/>
    public int ProcessorCount => Environment.ProcessorCount;

    /// <inheritdoc/>
    public bool IsPrivilegedProcess => Environment.IsPrivilegedProcess;

    /// <inheritdoc/>
    public bool HasShutdownStarted => Environment.HasShutdownStarted;

    /// <inheritdoc/>
    public string CommandLine => Environment.CommandLine;

    /// <inheritdoc/>
    public string CurrentDirectory
    {
        get => Environment.CurrentDirectory;
        set => Environment.CurrentDirectory = value;
    }

    /// <inheritdoc/>
    public int ProcessId => Environment.ProcessId;

    /// <inheritdoc/>
    public string? ProcessPath => Environment.ProcessPath;

    /// <inheritdoc/>
    public bool Is64BitProcess => Environment.Is64BitProcess;

    /// <inheritdoc/>
    public bool Is64BitOperatingSystem => Environment.Is64BitOperatingSystem;

    /// <inheritdoc/>
    public string NewLine => Environment.NewLine;

    /// <inheritdoc/>
    public OperatingSystem OSVersion => Environment.OSVersion;

    /// <inheritdoc/>
    public Version Version => Environment.Version;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage(Justification = "Not testable by design.")]
    public string StackTrace => Environment.StackTrace;

    /// <inheritdoc/>
    public int SystemPageSize => Environment.SystemPageSize;

    /// <inheritdoc/>
    public string UserName => Environment.UserName;

    /// <inheritdoc/>
    public string UserDomainName => Environment.UserDomainName;

    /// <inheritdoc/>
    public string MachineName => Environment.MachineName;

    /// <inheritdoc/>
    public string SystemDirectory => Environment.SystemDirectory;

    /// <inheritdoc/>
    public bool UserInteractive => Environment.UserInteractive;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage(Justification = "Not testable by design.")]
    public long WorkingSet => Environment.WorkingSet;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage(Justification = "Not testable by design.")]
    public void Exit(int exitCode) => Environment.Exit(exitCode);

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage(Justification = "Not testable by design.")]
    public void FailFast(string? message) => Environment.FailFast(message);

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage(Justification = "Not testable by design.")]
    public void FailFast(string? message, Exception exception) =>
        Environment.FailFast(message, exception);

    /// <inheritdoc/>
    public string? GetEnvironmentVariable(string variable) =>
        Environment.GetEnvironmentVariable(variable);

    /// <inheritdoc/>
    public string? GetEnvironmentVariable(string variable, EnvironmentVariableTarget target) =>
        Environment.GetEnvironmentVariable(variable, target);

    /// <inheritdoc/>
    public IDictionary GetEnvironmentVariables() => Environment.GetEnvironmentVariables();

    /// <inheritdoc/>
    public IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target) =>
        Environment.GetEnvironmentVariables(target);

    /// <inheritdoc/>
    public void SetEnvironmentVariable(string variable, string? value) =>
        Environment.SetEnvironmentVariable(variable, value);

    /// <inheritdoc/>
    public void SetEnvironmentVariable(
        string variable, string? value, EnvironmentVariableTarget target) =>
        Environment.SetEnvironmentVariable(variable, value, target);

    /// <inheritdoc/>
    public string ExpandEnvironmentVariables(string name) =>
        Environment.ExpandEnvironmentVariables(name);

    /// <inheritdoc/>
    public string[] GetCommandLineArgs() => Environment.GetCommandLineArgs();

    /// <inheritdoc/>
    public string GetFolderPath(Environment.SpecialFolder folder) =>
        Environment.GetFolderPath(folder);

    /// <inheritdoc/>
    public string GetFolderPath(
        Environment.SpecialFolder folder, Environment.SpecialFolderOption option) =>
        Environment.GetFolderPath(folder, option);

    /// <inheritdoc/>
    public string[] GetLogicalDrives() => Environment.GetLogicalDrives();
}
