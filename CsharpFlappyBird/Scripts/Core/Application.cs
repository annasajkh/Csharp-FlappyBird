using CsharpFlappyBird.Scripts.Core.Entities;
using CsharpFlappyBird.Scripts.Core.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CsharpFlappyBird.Scripts.Core;

public class Application : Game
{
    public static GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Bird bird;
    public static bool IsKeySpaceJustPressed;
    bool pressedState;
    Pipes[] pipes;

    public static Texture2D birdTexture;
    public static Texture2D pipeTexture;
    public static float scale = 3;
    public static Random random = new Random();
    public static float halfPipeHeight;

    public Application()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        IsMouseVisible = true;
        Window.Title = "Flappy Bird";
        base.Initialize();

        halfPipeHeight = pipeTexture.Height * scale / 2;
        bird = new Bird(new Vector2(100, graphics.PreferredBackBufferHeight / 2), birdTexture);
        pipes = new Pipes[5];

        for (int i = 2; i < pipes.Length + 2; i++)
        {
            pipes[i - 2] = new Pipes(i * 200, pipeTexture);
        }
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        birdTexture = Helper.LoadTexture2DFromFile("Assets/Sprites/bird.png", GraphicsDevice);
        pipeTexture = Helper.LoadTexture2DFromFile("Assets/Sprites/pipe.png", GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState state = Keyboard.GetState();

        if (!pressedState && state.IsKeyDown(Keys.Space))
        {
            IsKeySpaceJustPressed = true;
            pressedState = true;
        }
        else if (state.IsKeyUp(Keys.Space))
        {
            IsKeySpaceJustPressed = false;
            pressedState = false;
        }
        foreach (var pipe in pipes)
        {
            pipe.UpdateAll((float)gameTime.ElapsedGameTime.TotalSeconds);
            if (bird.rectangle.Intersects(pipe.up.rectangle) ||
               bird.rectangle.Intersects(pipe.down.rectangle) ||
               bird.position.Y > graphics.PreferredBackBufferHeight + bird.rectangle.Height ||
               bird.position.Y < -bird.rectangle.Height
              )
            {
                Initialize();
            }

        }

        bird.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

        if (pressedState)
        {
            IsKeySpaceJustPressed = false;
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, null, null);
        foreach (var pipe in pipes)
        {
            pipe.DrawAll(spriteBatch);
        }
        bird.Draw(spriteBatch, SpriteEffects.None);
        spriteBatch.End();
        base.Draw(gameTime);
    }
}
