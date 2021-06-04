using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace FlappyBird
{
    public class Pipes
    {
        public Pipe up;
        public Pipe down;
        float gap = 100;

        public Pipes(float x, Texture2D texture)
        {
            float randomNum = gap + (float)Game1.random.NextDouble() * (Game1.graphics.PreferredBackBufferHeight - gap);

            up = new Pipe(new Vector2(x, randomNum - Game1.halfPipeHeight - gap), texture);
            down = new Pipe(new Vector2(x, randomNum + Game1.halfPipeHeight), texture);
        }

        public void UpdateAll(float delta)
        {
            if(up.position.X < -up.rectangle.Width)
            {
                up.position.X = 1000 - up.rectangle.Width;
                down.position.X = 1000 - up.rectangle.Width;
                float randomNum = gap + (float)Game1.random.NextDouble() * (Game1.graphics.PreferredBackBufferHeight - gap);
                up.position.Y = randomNum - Game1.halfPipeHeight - gap;
                down.position.Y = randomNum + Game1.halfPipeHeight;

            }
            up.Update(delta);
            down.Update(delta);
        }

        public void DrawAll(SpriteBatch spriteBatch)
        {
            up.Draw(spriteBatch, SpriteEffects.FlipVertically);
            down.Draw(spriteBatch, SpriteEffects.None);
        }

    }
}
