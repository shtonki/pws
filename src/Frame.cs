﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
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

        private Designer designer;

        public Frame(int width, int height, ManualResetEventSlim ld = null, bool design = false) : base(width, height, new GraphicsMode(32,24,0,32), "StonerKart")
        {
            loadre = ld;

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            if (design)
            {
                Thread t = new Thread(() =>
                {
                    designer = new Designer();
                    Application.Run(designer);
                });

                t.Start();
            }
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

                if (activeScreen.background != null) dm.drawImege(activeScreen.background, 0, 0, BACKSCREENWIDTH, BACKSCREENHEIGHT);

                foreach (var elem in activeScreen.Elements)
                {
                    drawElement(elem, dm);
                }
            }

            this.SwapBuffers();
        }

        private void drawElement(GuiElement ge, DrawerMaym dm)
        {
            dm.translate(ge.X, ge.Y);

            ge.draw(dm);

            foreach (var kid in ge.children)
            {
                drawElement(kid, dm);
            }

            dm.translate(-ge.X, -ge.Y);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            e.Position = scalePoint(e.Position);

            focus(hovered);
            hovered?.onMouseDown(e);
            designer?.setActive(hovered);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            e.Position = scalePoint(e.Position);

            hovered?.onMouseUp(e);
        }

        private GuiElement hovered;
        private GuiElement focused;

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);

            e.Position = scalePoint(e.Position);
            var newover = elementAt(e.Position);

            if (newover != hovered)
            {
                hovered?.onMouseLeave(e);
                newover?.onMouseEnter(e);
            }
            hovered = newover;
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            focused?.onKeyDown(e);
        }

        private void focus(GuiElement f)
        {
            if (f == null) return;
            if (f.focus())
            {
                focused?.unfocus();
                focused = f;
            }
        }

        private GuiElement elementAt(Point sp)
        {
            if (activeScreen == null) return null;

            //var sp = scalePoint(p);

            int x = sp.X;
            int y = sp.Y;
            GuiElement r = null;
            var l = activeScreen.Elements;

            while (true)
            {
                bool c = false;

                foreach (var v in l)
                {
                    if (v.hoverable &&
                        v.X < x &&
                        v.X + v.Width > x &&
                        v.Y < y &&
                        v.Y + v.Height > y)
                    {
                        r = v;
                        l = v.children;
                        c = true;
                        x -= v.X;
                        y -= v.Y;
                    }
                }

                if (!c) return r;
            }
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

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
