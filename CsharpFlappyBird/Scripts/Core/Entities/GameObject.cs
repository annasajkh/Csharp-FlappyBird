using CsharpFlappyBird.Scripts.Core.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CsharpFlappyBird.Scripts.Core.Entities;

public abstract class GameObject
{

    public Rect rectangle;
    public Texture2D texture;
    public Vector2 position;
    public float rotation;
    public Vector2 scale;
    public Vector2 origin;

    public GameObject(Vector2 position, Texture2D texture)
    {
        this.texture = texture;
        this.position = position;

        scale = new Vector2(Application.scale, Application.scale);

        int width = (int)(texture.Width * Application.scale);
        int height = (int)(texture.Height * Application.scale);

        origin = new Vector2(texture.Width / 2, texture.Height / 2);
        rectangle = new Rect((int)(position.X + origin.X), (int)(position.Y - origin.Y), width, height);
    }

    public abstract void Update(float delta);


    public void Draw(SpriteBatch spriteBatch, SpriteEffects spriteEffects)
    {
        spriteBatch.Draw(texture, position, texture.Bounds, Color.White, rotation, origin, scale, spriteEffects, 0);
    }
}
