using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

class Paddle
{
    /// <summary>
    /// The keys to use to realise this paddle has to move to the left or right.
    /// </summary>
    Keys keyTop, keyBottom;

    /// <summary>
    /// The standard velocity to move with.
    /// </summary>
    const float speed = 900;

    /// <summary>
    /// The position of the paddle.
    /// </summary>
    public Vector2 position;

    /// <summary>
    /// The velocity of the paddle.
    /// </summary>
    private Vector2 velocity;

    /// <summary>
    /// The score that belongs to this paddle (read: player).
    /// </summary>
    public int score;

    /// <summary>
    /// The texture of the paddle.
    /// </summary>
    public Texture2D texture;

    public Paddle(Vector2 position, Keys keyLeft, Keys keyRight)
    {
        this.keyTop = keyLeft;
        this.keyBottom = keyRight;
        this.position = position;

        this.velocity = Vector2.Zero;
        this.texture = Asset.LoadTexture2D("Paddle");

        this.score = 0;
    }

    /// <summary>
    /// Updates the paddle, allowing it to move around.
    /// </summary>
    /// <param name="gT"></param>
    public void Update(GameTime gT)
    {
        this.Move(gT);
    }

    private void Move(GameTime gT)
    {
        velocity = Vector2.Zero;

        if (Input.KeyPress(keyTop))
            velocity.Y = -speed;

        if (Input.KeyPress(keyBottom))
            velocity.Y = speed;

        position += velocity * (float)gT.ElapsedGameTime.TotalSeconds;
    }

    /// <summary>
    /// Draws the paddle and the score to the screen.
    /// </summary>
    public void Draw(GameTime gT, SpriteBatch sB)
    {
        sB.Draw(texture, position - new Vector2(texture.Width, texture.Height) / 2, Color.White);
    }

    /// <summary>
    /// Checks whether or not the given ball is colliding with this paddle.
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public bool CollisionCheck(Ball b)
    {
        Rectangle recBall = new Rectangle((int)b.position.X - b.texture.Width / 2, (int)b.position.Y - b.texture.Height / 2, b.texture.Width, b.texture.Height);
        Rectangle recPaddle = new Rectangle((int)this.position.X - this.texture.Width / 2, (int)this.position.Y - this.texture.Height / 2, this.texture.Width, this.texture.Height);

        return !(Rectangle.Empty == Rectangle.Intersect(recBall, recPaddle));
    }

}