using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class TextBox : Square
    {
        private string text;
        private FontFamille ff;


        public TextBox(int width, int height, string text) : this(0, 0, width, height, text, FontFamille.font1)
        {
        }

        public TextBox(int x, int y, int width, int height, string text, FontFamille ff) : base(x, y, width, height)
        {
            this.text = text;
            this.ff = ff;
            Backcolor = Color.AntiqueWhite;
        }

        public override void draw(DrawerMaym dm)
        {
            dm.fillRectange(Backcolor, X, Y, Width, Height);

            int p = 0;

            var sz = ImageLoader.sizeOf(ff.fontImage);
            double w = (double)sz.Width;
            double h = (double)sz.Height;

            double tw = (double)text.Sum(c => ff.characters[c.ToString()].width);

            foreach (char c in text)
            {
                var v = ff.characters[c.ToString()];

                int rw = (int)(v.width*Width/tw);

                dm.drawTexture(
                    ff.fontImage,
                    p, 0, rw, Height,
                    new Box(v.startx/w, 0, v.width/w, 1)
                    );

                p += rw;
            }
        }
    }
}
