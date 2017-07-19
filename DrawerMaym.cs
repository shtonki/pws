using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;


namespace pws
{
    class DrawerMaym
    {
        public void fillRectange(Color c, int x, int y, int width, int height)
        {
            fillRectangeR(c, boxify(x, y, width, height));
        }

        private void fillRectangeR(Color c, Box b)
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color4(c);

            GL.Vertex2(b.x,       -(b.y      ));
            GL.Vertex2(b.x + b.w, -(b.y      ));
            GL.Vertex2(b.x + b.w, -(b.y + b.h));
            GL.Vertex2(b.x,       -(b.y + b.h));

            GL.End();
        }
        
        public void drawTexture(Textures t, int x, int y, int width, int height)
        {
            var nx = x * 2 - 1;
            var ny = y * 2 - 1;

            GL.Enable(EnableCap.Texture2D);
            GL.Color4(Color.White);
            drawTextureR(TextureLoader.getTexture(t), boxify(x, y, width, height));
            GL.Disable(EnableCap.Texture2D);
        }

        private void drawTextureR(Texture t, Box b)
        {
            GL.BindTexture(TextureTarget.Texture2D, t.textureID);
            GL.Begin(PrimitiveType.Quads);
            
            GL.TexCoord2(0, 0);
            GL.Vertex2(b.x, -(b.y));

            GL.TexCoord2(1, 0);
            GL.Vertex2(b.x + b.w, -(b.y));

            GL.TexCoord2(1, 1);
            GL.Vertex2(b.x + b.w, -(b.y + b.h));

            GL.TexCoord2(0, 1);
            GL.Vertex2(b.x, -(b.y + b.h));
            
            GL.End();
        }
        
        private const int screenWidthd2 = 1920/2;
        private const int screenHeightd2 = 1080/2;
        private static Box boxify(int x, int y, int w, int h)
        {
            var sx = ((double)(x - screenWidthd2))/screenWidthd2;
            var sy = ((double)(y - screenHeightd2))/screenHeightd2;
            var sw = ((double)(w - 0))/screenWidthd2;
            var sh = ((double)(h - 0))/screenHeightd2;

            return new Box(
                sx,
                sy,
                sw,
                sh
                );
        }

        private struct Box
        {
            public double x { get; }
            public double y { get; }
            public double w { get; }
            public double h { get; }

            public Box(double x, double y, double w, double h)
            {
                this.x = x;
                this.y = y;
                this.w = w;
                this.h = h;
            }
        }
    }
}
