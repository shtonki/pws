﻿using System;
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
        private Dictionary<Textures, int> textures;

        public DrawerMaym(Dictionary<Textures, int> textures)
        {
            this.textures = textures;
        }

        public void translate(int x, int y)
        {
            var tx = ((float)x)/Frame.BACKSCREENWIDTHd2;
            var ty = ((float)y)/Frame.BACKSCREENHEIGHTd2;
            GL.Translate(tx, -ty, 0);
        }

        public void fillRectange(Color c, int x, int y, int width, int height)
        {
            fillRectangeR(c, new Box(x, y, width, height));
        }

        private void fillRectangeR(Color c, Box b)
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color4(c);

            GL.Vertex2(b.x, -b.y);
            GL.Vertex2(b.r, -b.y);
            GL.Vertex2(b.r, -b.b);
            GL.Vertex2(b.x, -b.b);

            GL.End();
        }

        public void drawTexture(Textures t, int x, int y, int width, int height, Box? cropbox = null)
        {
            drawTextureR(t, new Box(x, y, width, height), cropbox);
        }

        private void drawTextureR(Textures tx, Box imageLocation, Box? crop = null)
        {
            Box cropx = crop == null ? new Box(0, 0, 1, 1) : crop.Value;

            GL.Enable(EnableCap.Texture2D);
            GL.Color4(Color.White);
            GL.BindTexture(TextureTarget.Texture2D, textures[tx]);
            GL.Begin(PrimitiveType.Quads);
            
            GL.TexCoord2(cropx.x, cropx.y);
            GL.Vertex2(imageLocation.x, -imageLocation.y);

            GL.TexCoord2(cropx.r, cropx.y);
            GL.Vertex2(imageLocation.r, -imageLocation.y);

            GL.TexCoord2(cropx.r, cropx.b);
            GL.Vertex2(imageLocation.r, -imageLocation.b);

            GL.TexCoord2(cropx.x, cropx.b);
            GL.Vertex2(imageLocation.x, -imageLocation.b);
            
            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }
    }
    
    public struct Box
    {
        public double x { get; }
        public double y { get; }
        public double w { get; }
        public double h { get; }
        public double r { get; }
        public double b { get; }

        public Box(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            r = x + w;
            b = y + h;
        }

        public Box(PointF topLeft, PointF bottomRight) : this()
        {
            x = topLeft.X;
            y = topLeft.Y;
            r = bottomRight.X;
            b = bottomRight.Y;
            w = r - x;
            h = b - y;
        }

        public Box(int x, int y, int w, int h) : this(Frame.pixToGL(x, y), Frame.pixToGL(x + w, y + h))
        {
        }

        /*
        public static Box boxifyScreen(int x, int y, int w, int h)
        {
            var p1 = Frame.pixToGL(new Point(x, y));
            var p2 = Frame.pixToGL(new Point(x+w, y+h));
            return new Box(p1, p2);
            //return boxify(x, y, w, h, Frame.BACKSCREENWIDTHd2, Frame.BACKSCREENHEIGHTd2);
        }
        /*
        public static Box boxify(int x, int y, int w, int h, int swd2, int shd2)
        {
            var sx = ((double)(x - swd2)) / swd2;
            var sy = ((double)(y - shd2)) / shd2;
            var sw = ((double)(w - 0)) / swd2;
            var sh = ((double)(h - 0)) / shd2;

            return new Box(
                sx,
                sy,
                sw,
                sh
                );
        }
        */
    }
}
