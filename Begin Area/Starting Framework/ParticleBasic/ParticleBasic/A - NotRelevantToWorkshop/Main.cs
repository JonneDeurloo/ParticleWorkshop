using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

// -- -- \\

// There is no need to make any modifications within this class for the purpose of the workshop.
// This code has been 'given' to you.

// -- -- \\

public class Main : Microsoft.Xna.Framework.Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch sB;

    GameWorld gameWorld;

    public Main()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        this.graphics.PreferredBackBufferWidth = 800;
        this.graphics.PreferredBackBufferHeight = 600;
        this.graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        sB = new SpriteBatch(GraphicsDevice);

        Asset.Initialise(Content);
        gameWorld = new GameWorld();
    }

    protected override void Update(GameTime gT)
    {
        Input.Update();
        gameWorld.Update(gT);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        sB.Begin();

        gameWorld.Draw(gameTime, sB);

        sB.End();

    }
}
