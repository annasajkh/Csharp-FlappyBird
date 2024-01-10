using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CsharpFlappyBird.Scripts.Core.Entities;

public class Pipe : GameObject
{
    float speed = 50;

    public Pipe(Vector2 position, Texture2D texture)
        : base(position, texture)
    {

    }

    public override void Update(float delta)
    {
        position.X -= speed * delta;

        rectangle.X = (int)position.X;
        rectangle.Y = (int)position.Y;
    }
}
