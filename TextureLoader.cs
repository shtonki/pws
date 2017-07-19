using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;
using pws.Properties;

namespace pws
{
    public enum Textures
    {
        A,
        B,

        memex,

        fontovich,
    };

    public struct Texture
    {
        public int textureID { get; }

        public int nativeWidth { get; }
        public int nativeHeight { get; }

        public Texture(int textureId, int nativeWidth, int nativeHeight)
        {
            textureID = textureId;
            this.nativeWidth = nativeWidth;
            this.nativeHeight = nativeHeight;
        }
    }

    internal static class TextureLoader
    {
        private static Dictionary<Textures, Texture> textures = new Dictionary<Textures, Texture>();
        private static Dictionary<Textures, Image> images = new Dictionary<Textures, Image>();

        static TextureLoader()
        {
            images[Textures.A] = Resources.AlterFate;
            images[Textures.B] = Resources.AlterTime;
            images[Textures.fontovich] = Resources.memefont;
            images[Textures.memex] = Resources.memex;

        }

        public static Texture getTexture(Textures texture)
        {
            if (textures.ContainsKey(texture)) return textures[texture];

            textures[texture] = makeTexture(images[texture]);
            return textures[texture];
        }

        private static Texture makeTexture(Image image)
        {
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(image);
            BitmapData data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            return new Texture(id, bmp.Width, bmp.Height);
        }


    }
}
