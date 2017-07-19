using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using pws.Properties;

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
                DrawerMaym dm = new DrawerMaym();
                foreach (var elem in activeScreen.elements)
                {
                    elem.draw(dm);
                }
            }

            this.SwapBuffers();
        }
    }
}
