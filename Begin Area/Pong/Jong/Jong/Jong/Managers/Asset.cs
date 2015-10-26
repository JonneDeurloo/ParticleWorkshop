using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

/// <summary>
/// Allows you to load in any (regular) data type for objects in the game.
/// </summary>
public static class Asset
{
    private static ContentManager coManager;

    private static Texture2D DefTexture;
    private static SpriteFont DefFont;

    /// <summary>
    /// Initialises the asset manager.
    /// </summary>
    /// <param name="coMan"></param>
    public static void Initialise(ContentManager coMan)
    {
        if (coMan != null)
        {
            coManager = coMan;

            DefTexture = coMan.Load<Texture2D>("Default/DefTexture");
            DefFont = coMan.Load<SpriteFont>("Default/DefFont");
        }
        else
            Console.WriteLine("The content manager send to the Asset class was null (empty)!");
    }

    /// <summary>
    /// Loads in a texture 2D. The default texture will be returned when the texture cannot be found.
    /// </summary>
    /// <param name="stPath">The path to the texture.</param>
    /// <returns></returns>
    public static Texture2D LoadTexture2D (String stPath)
    {
        if (coManager != null)
        {       // Try to load in the texture.
            try
            {
                return coManager.Load<Texture2D>(stPath);
            }
                // Incase we couldn't load the texture due to, generally, a faulty path.
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't find the following path: " + stPath + ". Returning the default texture.");
                Console.WriteLine(ex);
                return DefTexture;
            }
        }
        else
            Console.WriteLine("The content manager is not initialised!");
        return null;
    }

    /// <summary>
    /// Loads in a spritefont. The default spritefont will be returned when the spritefont cannot be found.
    /// </summary>
    /// <param name="stPath">The path to the spritefont.</param>
    /// <returns></returns>
    public static SpriteFont LoadFont(String stPath)
    {
        if (coManager != null)
        {       // Try to load in the texture.
            try
            {
                return coManager.Load<SpriteFont>(stPath);
            }
            // Incase we couldn't load the font due to, generally, a faulty path.
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't find the following path: " + stPath + ". Returning the default spritefont.");
                Console.WriteLine(ex);
                return DefFont;
            }
        }
        else
            Console.WriteLine("The content manager is not initialised!");
        return null;
    }
}