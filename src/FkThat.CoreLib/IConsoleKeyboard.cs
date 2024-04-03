namespace FkThat.CoreLib;

/// <summary>
/// Provides access to the console keyboard.
/// </summary>
public interface IConsoleKeyboard
{
    /// <summary>
    /// Gets a value indicating whether a key press is available in the input stream.
    /// </summary>
    bool KeyAvailable { get; }

    /// <summary>
    /// Obtains the next character or function key pressed by the user. The pressed key is
    /// optionally displayed in the console window.
    /// </summary>
    /// <param name="intercept">
    /// Determines whether to display the pressed key in the console window. <see langword="true"/>
    /// to not display the pressed key; otherwise, <see langword="false"/>.
    /// </param>
    /// <returns>
    /// An object that describes the <see cref="ConsoleKey"/> constant and Unicode character, if
    /// any, that correspond to the pressed console key. The <see cref="ConsoleKeyInfo"/> object
    /// also describes, in a bitwise combination of <see cref="ConsoleModifiers"/> values, whether
    /// one or more Shift, Alt, or Ctrl modifier keys was pressed simultaneously with the console
    /// key.
    /// </returns>
    ConsoleKeyInfo ReadKey(bool intercept);
}
