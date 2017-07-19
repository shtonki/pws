using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    struct glyphxd
    {
        public int startx { get; }
        public int width { get; }

        public glyphxd(int startx, int width)
        {
            this.startx = startx;
            this.width = width;
        }
    }

    class FontFamille
    {
        public Textures fontImage;
        public Dictionary<string, glyphxd> xdds;

        public FontFamille(Textures fontImage, string fontstring)
        {
            this.fontImage = fontImage;

            xdds = new Dictionary<string, glyphxd>();

            var lines = fontstring.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            glyphxd lst = new glyphxd();
            foreach (string line in lines)
            {
                string[] ss = line.Split();
                string g = ss[0];
                int l = Int32.Parse(ss[1]);
                int w = Int32.Parse(ss[2]);

                lst = xdds[g] = new glyphxd(l, w);
            }
            xdds[" "] = new glyphxd(lst.startx + lst.width, 32);
        }

        public static FontFamille font1 = new FontFamille(Textures.fontovich, Properties.Resources.font1);
    }

    class Font
    {
    }
}
