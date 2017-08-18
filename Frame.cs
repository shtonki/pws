using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using pws.Properties;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace pws
{
    class Frame : GameWindow
    {
        private Screen activeScreen;

        private ManualResetEventSlim loadre;

        public Frame(int width, int height, ManualResetEventSlim ld = null) : base(width, height)
        {
            loadre = ld;

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        }

        public void setScreen(Screen screen)
        {
            activeScreen = screen;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loadTextures();
            if (loadre != null) loadre.Set();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);

            if (activeScreen != null)
            {
                DrawerMaym dm = new DrawerMaym(textures);
                foreach (var elem in activeScreen.elements)
                {
                    drawElement(elem, dm);
                }
            }

            this.SwapBuffers();
        }

        private void drawElement(GuiElement ge, DrawerMaym dm)
        {
            ge.draw(dm);

            dm.translate(ge.x, ge.y);
            foreach (var kid in ge.children)
            {
                drawElement(kid, dm);
            }
            dm.translate(-ge.x, -ge.y);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            hovered?.mouseDown();
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            hovered?.mouseUp();
        }

        private GuiElement hovered;

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            var newover = elementAt(e.Position);
            if (newover != hovered)
            {
                hovered?.mouseLeave();
                newover?.mouseEnter();
            }
            hovered = newover;
        }

        private GuiElement elementAt(Point p)
        {
            var sp = scalePoint(p);
            int x = sp.X;
            int y = sp.Y;

            foreach (var v in activeScreen.elements)
            {
                if (v.x < x &&
                    v.x + v.width > x &&
                    v.y < y &&
                    v.y + v.height > y)
                {
                    return v;
                }
            }

            return null;
        }


        public static PointF pixToGL(int x, int y)
        {
            return pixToGL(new Point(x, y));
        }

        public static PointF pixToGL(Point p)
        {
            var sx = ((float)(p.X - BACKSCREENWIDTHd2)) / BACKSCREENWIDTHd2;
            var sy = ((float)(p.Y - BACKSCREENHEIGHTd2)) / BACKSCREENHEIGHTd2;

            return new PointF(sx, sy);
        }



        public const int BACKSCREENWIDTH = 1920;
        public const int BACKSCREENHEIGHT = 1080;
        public const int BACKSCREENWIDTHd2 = BACKSCREENWIDTH/2;
        public const int BACKSCREENHEIGHTd2 = BACKSCREENHEIGHT/2;

        private Point scalePoint(Point p)
        {
            double xs = ((double)BACKSCREENWIDTH) / Width;
            double ys = ((double)BACKSCREENHEIGHT) / Height;

            return new Point((int)Math.Round(p.X*xs), (int)Math.Round(p.Y*ys));
        }

        private static Dictionary<Textures, int> textures;

        private static void loadTextures()
        {
            if (textures != null) throw new Exception();
            textures = new Dictionary<Textures, int>();

            foreach (Textures t in Enum.GetValues(typeof (Textures)))
            {
                loadTexture(t, ImageLoader.images[t]);
            }
        }

        private static void loadTexture(Textures t, Image i)
        {
            if (textures.ContainsKey(t)) throw new Exception("Reloading existing texture");
            textures[t] = makeTexture(i);
        }

        private static int makeTexture(Image image)
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

            return id;
        }

    }
}
