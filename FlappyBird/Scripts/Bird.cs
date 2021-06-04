using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird
{
    public class Bird : GameObject
    {
        Vector2 velocity;
        float gravity = 10;
        const float MAX_GRAVITY = 1000;
        float flapHeight = 200;

        public Bird(Vector2 position, Texture2D texture)
            : base(position, texture)
        {

        }

        public float map(float inMin, float inMax, float outMin, float outMax, float value)
        {
            return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        public void getInput()
        {
            if(Game1.IsKeySpaceJustPressed)
            {
                velocity.Y = -flapHeight;
            }
        }

        public override void Update(float delta)
        {
            getInput();

            velocity.Y += gravity;
            velocity.Y = MathHelper.Clamp(velocity.Y, -MAX_GRAVITY, MAX_GRAVITY);

            rotation = MathHelper.ToRadians(map(-MAX_GRAVITY, MAX_GRAVITY, -90, 90, velocity.Y));
            position += velocity * delta;

            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
        }
    }
}
