using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class TextBox : GuiElement
    {
        private string text;
        private FontFamille ff;

        public TextBox(int x, int y, int width, int height, string text, FontFamille ff) : base(x, y, width, height)
        {
            this.text = text;
            this.ff = ff;
        }

        public override void draw(DrawerMaym dm)
        {
            int p = 0;

            var sz = ImageLoader.sizeOf(ff.fontImage);
            double w = (double)sz.Width;
            double h = (double)sz.Height;

            double tw = (double)text.Sum(c => ff.xdds[c.ToString()].width);

            foreach (char c in text)
            {
                var v = ff.xdds[c.ToString()];

                int rw = (int)(v.width*width/tw);

                dm.drawTexture(
                    ff.fontImage,
                    x + p, y, rw, height,
                    new Box(v.startx/w, 0, v.width/w, 1)
                    );

                p += rw;
            }
        }
    }
}
