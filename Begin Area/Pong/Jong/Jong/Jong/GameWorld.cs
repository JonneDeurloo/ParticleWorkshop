using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


// -- -- \\

// Once a life is lost, many more will follow. Trust me.
// This implementation of Pong is clearly not finished.
// However, it's simple enough to quickly understand what's going on.
// And sufficient enough to be playable.

// -- -- \\


class GameWorld
{
    /// <summary>
    /// The paddles that are controllable by the player.
    /// </summary>
    Paddle topPaddle, bottomPaddle;

    /// <summary>
    /// The ball that interacts with the paddles.
    /// </summary>
    Ball square;

    /// <summary>
    /// The font to use to represent the score.
    /// </summary>
    private SpriteFont font;

    Texture2D background;

    public static Point screenResolution;

    public GameWorld(Point screenresolution, ContentManager c)
    {
        Asset.Initialise(c);

        screenResolution = screenresolution;

        topPaddle = new Paddle(new Vector2(20, screenResolution.Y / 2), Microsoft.Xna.Framework.Input.Keys.W, Microsoft.Xna.Framework.Input.Keys.S);
        bottomPaddle = new Paddle(new Vector2(screenResolution.X - 20, screenResolution.Y / 2), Microsoft.Xna.Framework.Input.Keys.Up, Microsoft.Xna.Framework.Input.Keys.Down);
        square = new Ball();

        background = Asset.LoadTexture2D("Background");
        this.font = Asset.LoadFont("Font");
    }

    public void Update(GameTime gT)
    {
        Input.Update();
            // Update everything
        topPaddle.Update(gT);
        bottomPaddle.Update(gT);
        square.Update(gT);
            // Check game state
        this.CheckCollision();
        this.Boundaries();
    }

    public void Draw(GameTime gT, SpriteBatch sB)
    {
        sB.Draw(background, Vector2.Zero, Color.White);
            // Draw the score before the rest, this will draw the ball over the score.
        sB.DrawString(font, topPaddle.score.ToString(), new Vector2(100, 100) , Color.White);
        sB.DrawString(font, bottomPaddle.score.ToString(), new Vector2(screenResolution.X - 100 - font.MeasureString(bottomPaddle.score.ToString()).X, 100), Color.White);

        square.Draw(gT, sB);

        topPaddle.Draw(gT, sB);
        bottomPaddle.Draw(gT, sB);
    }

    /// <summary>
    /// Checks for collisions between the paddles and the square.
    /// </summary>
    private void CheckCollision()
    {
        if (topPaddle.CollisionCheck(square))
            CalculateSquareDirectionAfterPaddle(topPaddle, square);

        if (bottomPaddle.CollisionCheck(square))
            CalculateSquareDirectionAfterPaddle(bottomPaddle, square);
    }

    /// <summary>
    /// Calculates the new trajectory for the square.
    /// </summary>
    /// <param name="p"> The paddle that the square hit. </param>
    /// <param name="b"> The square that hit the paddle. </param>
    private void CalculateSquareDirectionAfterPaddle(Paddle p, Ball b)
    {
            // The new y-speed values that are available.
        float[] yValues = new float[13] { 0.4f, 0.6f, 0.8f, 1.1f, 1.4f, 1.5f, 2.0f, 1.5f, 1.4f, 1.1f, 0.8f, 0.6f, 0.4f };

            // Calculates the most left part of the paddle, along with retrieving the total length of the paddle.
        float paddleMinimalX = p.position.Y - p.texture.Height / 2;
        float paddleLengthX = p.texture.Height;
            
            // Calculates the most left part of the square.
        float squareX = b.position.Y - b.texture.Height / 2;

            // Puts the square's position relative to the paddles position (it's now between 0 and the length of the paddle.)
        float squareRelativePositionX = squareX - paddleMinimalX;

            // Calculates the 'position' within the array given above for the square.
        int squareArrayPositionX = (int)(squareRelativePositionX / 10.0f);
            // Calculates the 'remainder of this position, For example: if we're at 77.84 relatively to the paddle, this will return .784.
        float squareRemainder = (squareRelativePositionX / 10.0f) % 1;

            // Ensures that our array position is within boundaries of the array.
        squareArrayPositionX = Math.Min(squareArrayPositionX, 12);
        squareArrayPositionX = Math.Max(squareArrayPositionX, 0);

            // Ensures that we move into the proper direction after bouncing against a paddle (away from the paddle).
        Vector2 multiplier = Vector2.One;

        if (b.velocity.Y < 0)
            multiplier.Y = -1;

        if (b.velocity.X > 0)
            multiplier.X = -1;

            // Puts the square right up against the paddle.
        b.position.X = p.position.X + p.texture.Width * multiplier.X;

            // Calculates the new Y value. It uses the squareRemainder variable to 'smooth' between different array cells.
        b.velocity.X = (yValues[squareArrayPositionX] * squareRemainder + yValues[Math.Min(squareArrayPositionX + 1, 12)] * (1 -  squareRemainder)) * multiplier.X;
        b.velocity.Y = 0.5f * multiplier.Y;

            // Ensures the result of the vector is equal to 1 (x + y).
        b.velocity.Normalize();

        b.speedMultiplier *= 1.020f;
    }

    /// <summary>
    /// Checks whether or not the square is within the boundaries.
    /// If it's not, it will reverse the direction and move the square against the boundary.
    /// </summary>
    private void Boundaries()
    {

            // On the left and right sides, just bounce.
        if (square.position.X < 0)
        {
            square.Reset();
            bottomPaddle.score++;
        }

        if (square.position.X > screenResolution.X)
        {
            square.Reset();
            topPaddle.score++;
        }

            // On the top and bottom side, respawn and add score.
        if (square.position.Y < 0)
        {
            square.velocity.Y *= -1;
            square.position.Y = 0;
        }

        if (square.position.Y > screenResolution.Y)
        {
            square.velocity.Y *= -1;
            square.position.Y = screenResolution.Y;
        }
    }
}
