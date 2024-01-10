using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace CsharpFlappyBird.Scripts.Core.Utils;
public static class Helper
{
    public static Texture2D LoadTexture2DFromFile(string filename, GraphicsDevice graphicsDevice)
    {
        using (var stream = File.OpenRead(filename))
        {
            return Texture2D.FromStream(graphicsDevice, stream);
        }
    }
}
