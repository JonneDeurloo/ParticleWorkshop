using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

// -- -- \\

// You will need to make modifications to this class to the following methods to complete the workshop. (Yes, this is a very long sentence. I agree.)
//  - The constructor
//  - The update function
//  - The draw function.

// This code has been given to you.

// -- -- \\

public class GameWorld
{

    Emitter emitter;

    public GameWorld()
    {
        emitter = new Emitter();
    }

    public void Update(GameTime gT)
    {
        float multiplier = 500;

        if (Input.KeyPress(Keys.LeftShift))
            multiplier *= 3;

        if (Input.KeyPress(Keys.Left))
            emitter.position.X -= multiplier * (float)gT.ElapsedGameTime.TotalSeconds;

        if (Input.KeyPress(Keys.Right))
            emitter.position.X += multiplier * (float)gT.ElapsedGameTime.TotalSeconds;

        if (Input.KeyPress(Keys.Up))
            emitter.position.Y -= multiplier * (float)gT.ElapsedGameTime.TotalSeconds;

        if (Input.KeyPress(Keys.Down))
            emitter.position.Y += multiplier * (float)gT.ElapsedGameTime.TotalSeconds;
    }

    public void Draw(GameTime gT, SpriteBatch sB)
    {

    }

}
