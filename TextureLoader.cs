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

    public static class ImageLoader
    {
        public static Dictionary<Textures, Image> images { get; }


        static ImageLoader()
        {
            images = new Dictionary<Textures, Image>();

            images[Textures.A] = Resources.AlterFate;
            images[Textures.B] = Resources.AlterTime;
            images[Textures.fontovich] = Resources.memefont;
            images[Textures.memex] = Resources.memex;
        }

        public static Size sizeOf(Textures t)
        {
            return images[t].Size;
        }
    }
}
