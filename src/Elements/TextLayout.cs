using System;
using System.Linq;
using System.Collections.Generic;

namespace pws
{
    class TextLayout
    {
        private List<x> xs;
        private FontFamille ff;
        private double tw;
        private int charHeight;

        public TextLayout(List<x> xs, FontFamille ff, int charHeight)
        {
            this.xs = xs;
            this.ff = ff;
            this.charHeight = charHeight;
        }

        public static TextLayout singleLineLayout(string text, int width, int height, FontFamille ff)
        {
            List<x> xs = new List<x>();
            int p = 0;

            var sz = ImageLoader.sizeOf(ff.fontImage);
            double w = (double)sz.Width;
            double h = (double)sz.Height;

            var tw = (double)text.Sum(c => ff.characters[c.ToString()].width);

            foreach (char c in text)
            {
                var v = ff.characters[c.ToString()];

                int rw = (int)(v.width*width/tw);

                xs.Add(new x(v, p, 0, rw, new Box(v.startx/w, 0, v.width/w, 1)));
                p += rw;
            }

            return new TextLayout(xs, ff, height);
        }

        public static TextLayout multiLineLayout(string text, int width, int height, FontFamille ff, int minsize = 1, int maxsize = Int32.MaxValue)
        {
            var words = text.Split(' ');

            var sz = ImageLoader.sizeOf(ff.fontImage);
            double w = (double)sz.Width;
            double h = (double)sz.Height;

            List<x> candidate = null;

            for (int fontheight = minsize; fontheight < maxsize; fontheight++)
            {
                int xpos = 0;
                int ypos = 0;

                List<x> xlist = new List<x>();
                double scale = ((double)fontheight)/h;

                foreach (char c in text)
                {
                    glyphxd v = ff.characters[c.ToString()];
                    var charwidth = v.width*scale;

                    if (xpos + charwidth > width)
                    {
                        xpos = 0;
                        ypos += fontheight;
                    }

                    if (ypos > height)
                    {
                        return new TextLayout(candidate, ff, fontheight);
                    }

                    xlist.Add(new x(v, xpos, ypos, (int)charwidth, new Box(v.startx / w, 0, v.width / w, 1)));
                    xpos += (int)charwidth;
                }

                candidate = xlist;
            }

            throw new Exception();
        }

        private static void wordify(string text)
        {
            
        }

        public void draw(DrawerMaym dm, int x, int y)
        {
            foreach (var xdd in xs)
            {
                dm.drawTexture(
                    ff.fontImage,
                    x + xdd.xpos,
                    y + xdd.ypos,
                    xdd.rw,
                    charHeight,
                    xdd.crop);

            }
        }

        public struct x
        {
            public glyphxd glyph;
            public int xpos;
            public int ypos;
            public int rw;
            public Box crop;

            public x(glyphxd glyph, int xpos, int ypos, int rw, Box crop)
            {
                this.glyph = glyph;
                this.xpos = xpos;
                this.ypos = ypos;
                this.rw = rw;
                this.crop = crop;
            }
        }
    }
}