using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Ball
{
    /// <summary>
    /// Determines how fast the cube rotates.
    /// </summary>
    public float rotationalSpeed = 7.5f;

    /// <summary>
    /// The current rotation value of the cube.
    /// </summary>
    private float rotation;

    /// <summary>
    /// The texture of the paddle.
    /// </summary>
    public Texture2D texture;

    /// <summary>
    /// The position of the paddle.
    /// </summary>
    public Vector2 position;

    /// <summary>
    /// The velocity of the paddle.
    /// </summary>
    public Vector2 velocity;

    /// <summary>
    /// Determines how fast the ball is moving in a certain direction.
    /// </summary>
    public float speedMultiplier = 750f;

    public Ball()
    {
        rotation = 0;

        this.Reset();

        this.texture = Asset.LoadTexture2D("Square");
    }

    public void Update(GameTime gT)
    {   
            // Rotates the ball
        rotation += rotationalSpeed * (float)gT.ElapsedGameTime.TotalSeconds;
            // Moves the ball
        this.position += this.velocity * speedMultiplier * (float)gT.ElapsedGameTime.TotalSeconds;
    }

    public void Draw(GameTime gT, SpriteBatch sB)
    {
        sB.Draw(texture, position, null, Color.White, rotation, (new Vector2(texture.Width, texture.Height) / 2), 1.0f, SpriteEffects.None, 1);
    }

    /// <summary>
    /// Resets the ball back to the middle of the screen with a new direction.
    /// </summary>
    public void Reset()
    {
        this.velocity = new Vector2((float)Data.randomGenerator.NextDouble() - 0.5f, (float)Data.randomGenerator.NextDouble() - 0.5f);
        this.velocity.X *= 4;
        this.velocity.Normalize();

        this.position = new Vector2(GameWorld.screenResolution.X, GameWorld.screenResolution.Y) / 2;

        this.speedMultiplier = 600;
    }
}