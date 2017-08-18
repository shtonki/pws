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

        bg0,

        buttonbg0,
    };

    public static class ImageLoader
    {
        public static Dictionary<Textures, Image> images { get; }


        static ImageLoader()
        {
            images = new Dictionary<Textures, Image>();

            images[Textures.A] = Resources.AlterFate;
            images[Textures.B] = Resources.AlterTime;
            images[Textures.fontovich] = Resources.noname;
            images[Textures.memex] = Resources.memex;
            images[Textures.bg0] = Resources.background0;
            images[Textures.buttonbg0] = Resources.buttonbg0;
        }

        public static Size sizeOf(Textures t)
        {
            return images[t].Size;
        }
    }
}
