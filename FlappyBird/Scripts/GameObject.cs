using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FlappyBird
{
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

            scale = new Vector2(Game1.scale, Game1.scale);

            int width = (int)(texture.Width * Game1.scale);
            int height = (int)(texture.Height * Game1.scale);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            rectangle = new Rect((int)(position.X + origin.X), (int)(position.Y - origin.Y), width, height);
        }

        public abstract void Update(float delta);


        public void Draw(SpriteBatch spriteBatch, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(texture: texture,
                             position: position,
                             color: Color.White,
                             rotation: rotation,
                             origin: origin,
                             scale: scale,
                             effects: spriteEffects);
            //spriteBatch.Draw(Game1.birdTexture, destinationRectangle: rectangle, color: Color.White, origin: new Vector2(Game1.birdTexture.Width / 2, Game1.birdTexture.Height / 2));
        }
    }
}
