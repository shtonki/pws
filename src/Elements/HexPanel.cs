using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace pws
{
    class HexPanel : Square
    {
        private int xcount;
        private int ycount;
        private int hexsize;

        public HexPanel(int xcount, int ycount, int hexsize) : base()
        {
            width = hexsize+(int)((xcount-1)*hexsize*0.75);
            height = ycount*hexsize + hexsize/2;

            this.xcount = xcount;
            this.ycount = ycount;
            this.hexsize = hexsize;
            Backcolor = Color.Firebrick;
        }

        public override void onMouseDown(MouseButtonEventArgs args)
        {
            base.onMouseDown(args);
            var p = args.Position;
            var mousex = p.X;
            var mousey = p.Y;

            int cx = 0;
            int cy = 0;
            double cd = 2000;

            for (int i = 0; i < xcount; i++)
            {
                int os = (i%2)*hexsize/2;
                for (int j = 0; j < ycount; j++)
                {
                    int hexX = x + (int)(0.75*hexsize*i);
                    int hexY = y + (j*hexsize + os);

                    int dx = hexX - mousex;
                    int dy = hexY - mousey;

                    var td = Math.Sqrt(dx*dx + dy*dy);
                    if (td < cd)
                    {
                        cx = i;
                        cy = j;
                        cd = td;
                    }
                }
            }

            Console.WriteLine("{0} {1}", cx, cy);

        }

        public override void draw(DrawerMaym dm)
        {
            base.draw(dm);

            for (int i = 0; i < xcount; i++)
            {
                int os = (i%2)*hexsize/2;
                for (int j = 0; j < ycount; j++)
                {
                    int hexX = x + (int)(0.75*hexsize*i);
                    int hexY = y + (j*hexsize + os);

                    if (i%2 == 0)
                    {
                        dm.fillHexagon(hexX, hexY, hexsize, Color.White, Textures.A);

                    }
                    else
                    {
                        dm.fillHexagon(hexX, hexY, hexsize, Color.White, Color.BlueViolet);
                    }
                }
            }

        }
    }
}
