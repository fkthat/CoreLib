using System.Runtime.Versioning;

namespace FkThat.CoreLib;

public class SystemEnvironmentTests
{
    public static readonly IEnumerable<object[]> SpecialFolders =
        Enum.GetValues<Environment.SpecialFolder>().Distinct()
            .Select(x => new object[] { x })
            .ToArray();

    public static readonly IEnumerable<object[]> SpecialFoldersWithOptions =
        Enum.GetValues<Environment.SpecialFolder>().Distinct()
            .SelectMany(x =>
                Enum.GetValues<Environment.SpecialFolderOption>().Distinct()
                    .Select(y => new object[] { x, y }))
        .ToArray();

    [Fact]
    public void CurrentManagedThreadId_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.CurrentManagedThreadId.Should().Be(Environment.CurrentManagedThreadId);
    }

    [Fact]
    public void ExitCode_get_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        Environment.ExitCode = 42;
        sut.ExitCode.Should().Be(42);
    }

    [Fact]
    public void ExitCode_set_sets_value_to_system_environment()
    {
        SystemEnvironment sut = new();
        sut.ExitCode = 42;
        Environment.ExitCode.Should().Be(42);
    }

    [Fact]
    public void TickCount_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.TickCount.Should().Be(Environment.TickCount);
    }

    [Fact]
    public void TickCount64_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.TickCount64.Should().Be(Environment.TickCount64);
    }

    [Fact]
    public void ProcessorCount_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.ProcessorCount.Should().Be(Environment.ProcessorCount);
    }

    [Fact]
    public void IsPrivilegedProcess_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.IsPrivilegedProcess.Should().Be(Environment.IsPrivilegedProcess);
    }

    [Fact]
    public void HasShutdownStarted_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.HasShutdownStarted.Should().Be(Environment.HasShutdownStarted);
    }

    [Fact]
    public void CommandLine_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.CommandLine.Should().Be(Environment.CommandLine);
    }

    [Fact]
    public void CurrentDirectory_get_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.CurrentDirectory.Should().Be(Environment.CurrentDirectory);
    }

    [Fact]
    public void CurrentDirectory_set_sets_value_to_system_environment()
    {
        SystemEnvironment sut = new();

        var path = Environment.OSVersion.Platform switch
        {
            PlatformID.Win32NT => "C:\\",
            PlatformID.Unix => "/",
            _ => null
        };

        if (path != null)
        {
            sut.CurrentDirectory = path;
            Environment.CurrentDirectory.Should().Be(path);
        }
    }

    [Fact]
    public void ProcessId_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.ProcessId.Should().Be(Environment.ProcessId);
    }

    [Fact]
    public void ProcessPath_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.ProcessPath.Should().Be(Environment.ProcessPath);
    }

    [Fact]
    public void Is64BitProcess_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.Is64BitProcess.Should().Be(Environment.Is64BitProcess);
    }

    [Fact]
    public void Is64BitOperatingSystem_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.Is64BitOperatingSystem.Should().Be(Environment.Is64BitOperatingSystem);
    }

    [Fact]
    public void NewLine_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.NewLine.Should().Be(Environment.NewLine);
    }

    [Fact]
    public void OSVersion_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.OSVersion.Should().Be(Environment.OSVersion);
    }

    [Fact]
    public void Version_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.Version.Should().Be(Environment.Version);
    }

    [Fact]
    public void SystemPageSize_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.SystemPageSize.Should().Be(Environment.SystemPageSize);
    }

    [Fact]
    public void UserName_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.UserName.Should().Be(Environment.UserName);
    }

    [Fact]
    public void UserDomainName_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.UserDomainName.Should().Be(Environment.UserDomainName);
    }

    [Fact]
    public void MachineName_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.MachineName.Should().Be(Environment.MachineName);
    }

    [Fact]
    public void SystemDirectory_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.SystemDirectory.Should().Be(Environment.SystemDirectory);
    }

    [Fact]
    public void UserInteractive_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.UserInteractive.Should().Be(Environment.UserInteractive);
    }

    [Fact]
    public void GetEnvironmentVariable_returns_value_from_system_environment()
    {
        var name = "887002eb-3aef-4d8c-9c39-043bae3f8a5b";

        try
        {
            Environment.SetEnvironmentVariable(name, "foo42");
            SystemEnvironment sut = new();
            sut.GetEnvironmentVariable(name).Should().Be("foo42");
        }
        finally
        {
            Environment.SetEnvironmentVariable(name, null);
        }
    }

    [Theory]
    [InlineData(EnvironmentVariableTarget.Process)]
    public void GetEnvironmentVariable_with_target_returns_value_from_system_environment(
        EnvironmentVariableTarget target)
    {
        var name = "887002eb-3aef-4d8c-9c39-043bae3f8a5b";

        try
        {
            Environment.SetEnvironmentVariable(name, "foo42", target);
            SystemEnvironment sut = new();
            sut.GetEnvironmentVariable(name, target).Should().Be("foo42");
        }
        finally
        {
            Environment.SetEnvironmentVariable(name, null);
        }
    }

    [Fact]
    public void GetEnvironmentVariables_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.GetEnvironmentVariables().Should()
            .BeEquivalentTo(Environment.GetEnvironmentVariables());
    }

    [Fact]
    public void GetEnvironmentVariables_with_target_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.GetEnvironmentVariables(EnvironmentVariableTarget.Process).Should()
            .BeEquivalentTo(Environment.GetEnvironmentVariables());
    }

    [Fact]
    public void ExpandEnvironmentVariables_returns_value_from_system_environment()
    {
        var name = "887002eb-3aef-4d8c-9c39-043bae3f8a5b";

        try
        {
            Environment.SetEnvironmentVariable(name, "foo42");
            SystemEnvironment sut = new();
            sut.ExpandEnvironmentVariables($"foo %{name}% bar").Should()
                .Be("foo foo42 bar");
        }
        finally
        {
            Environment.SetEnvironmentVariable(name, null);
        }
    }

    [Fact]
    public void SetEnvironmentVariable_calls_system_environmet()
    {
        var name = "887002eb-3aef-4d8c-9c39-043bae3f8a5b";

        try
        {
            SystemEnvironment sut = new();
            sut.SetEnvironmentVariable(name, "foo42");
            Environment.GetEnvironmentVariable(name).Should().Be("foo42");
        }
        finally
        {
            Environment.SetEnvironmentVariable(name, null);
        }
    }

    [Fact]
    public void SetEnvironmentVariable_with_target_calls_system_environmet()
    {
        var name = "887002eb-3aef-4d8c-9c39-043bae3f8a5b";

        try
        {
            SystemEnvironment sut = new();
            sut.SetEnvironmentVariable(name, "foo42", EnvironmentVariableTarget.Process);
            Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process)
                .Should().Be("foo42");
        }
        finally
        {
            Environment.SetEnvironmentVariable(name, null);
        }
    }

    [Fact]
    public void GetCommandLineArgs_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.GetCommandLineArgs().Should().Equal(Environment.GetCommandLineArgs());
    }

    [Theory]
    [MemberData(nameof(SpecialFolders))]
    [SupportedOSPlatform("windows")]
    public void GetFolderPath_returns_value_from_system_environment(Environment.SpecialFolder folder)
    {
        SystemEnvironment sut = new();
        sut.GetFolderPath(folder).Should().Be(Environment.GetFolderPath(folder));
    }

    [Theory]
    [MemberData(nameof(SpecialFoldersWithOptions))]
    [SupportedOSPlatform("windows")]
    public void GetFolderPath_with_options_returns_value_from_system_environment(
        Environment.SpecialFolder folder, Environment.SpecialFolderOption option)
    {
        SystemEnvironment sut = new();
        sut.GetFolderPath(folder, option).Should()
            .Be(Environment.GetFolderPath(folder, option));
    }

    [Fact]
    public void GetLogicalDrives_returns_value_from_system_environment()
    {
        SystemEnvironment sut = new();
        sut.GetLogicalDrives().Should().BeEquivalentTo(Environment.GetLogicalDrives());
    }
}
