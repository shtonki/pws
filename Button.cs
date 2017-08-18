using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class Button : TextBox
    {
        public Button(int width, int height) : base(width, height, "")
        {
        }

        public Button(int width, int height, string text) : base(width, height, text)
        {
        }

        public override void mouseDown()
        {
            base.mouseDown();
            meme();
        }

        public override void mouseUp()
        {
            base.mouseUp();
            if (memed)
            {
                foreach (var c in clickcallbacks)
                {
                    c();
                }
            }
            dememe();
        }

        public override void mouseLeave()
        {
            base.mouseLeave();
            dememe();
        }

        private bool memed;

        private void meme()
        {
            memed = true;
        }

        private void dememe()
        {
            memed = false;
        }

        private Color pressColor = Color.FromArgb(50, 0x33, 0x3, 0x33);

        public override void draw(DrawerMaym dm)
        {
            base.draw(dm);
            if (memed)
            {
                dm.fillRectange(pressColor, 0, 0, width, height);
            }
        }
    }
}
