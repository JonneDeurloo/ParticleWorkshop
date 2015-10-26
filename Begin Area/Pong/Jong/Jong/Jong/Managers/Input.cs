using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Allows you to check for user input for objects in the game.
/// </summary>
public static class Input
{
    /// <summary>
    /// keCurrent represents the current keyboard status, kePrevious represents the previous keyboard status.
    /// Together they can be used to distinguish clicking from pressing.
    /// </summary>
    private static KeyboardState keCurrent, kePrevious;

    private static MouseState meCurrent, mePrevious;

    public static Vector2 mouseCoordinates;

    public static void Update()
    {
        // Setting keyboard data.
        kePrevious = keCurrent;
        keCurrent = Keyboard.GetState();

        // Setting mouse data.
        mePrevious = meCurrent;
        meCurrent = Mouse.GetState();

        mouseCoordinates = new Vector2(meCurrent.X, meCurrent.Y);
    }

    /// <summary>
    /// Checks whether or not a key is being pressed.
    /// </summary>
    /// <param name="keyToCheck">The key to check.</param>
    /// <returns></returns>
    public static Boolean KeyPress(Keys keyToCheck)
    {
        if (keCurrent.IsKeyDown(keyToCheck))
            return true;
        return false;
    }

    /// <summary>
    /// Checks whether or not a key got clicked.
    /// </summary>
    /// <param name="keyToCheck">The key to check.</param>
    /// <returns></returns>
    public static Boolean KeyClickDown(Keys keyToCheck)
    {
        if (!(kePrevious.IsKeyDown(keyToCheck))
        && (keCurrent.IsKeyDown(keyToCheck)))
            return true;
        return false;
    }
}