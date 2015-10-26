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
        graphics.PreferredBackBufferHeight = 700;
        graphics.PreferredBackBufferWidth = 1000;
        graphics.ApplyChanges();

        base.Initialize(); 
    }

    protected override void LoadContent()
    { 
        sB = new SpriteBatch(GraphicsDevice);
        gameWorld = new GameWorld(new Point(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Content);
    }

    protected override void Update(GameTime gT)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();

        gameWorld.Update(gT);

        base.Update(gT);
    }

    protected override void Draw(GameTime gT)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        sB.Begin();

        gameWorld.Draw(gT, sB);

        sB.End();

        base.Draw(gT);
    }
}