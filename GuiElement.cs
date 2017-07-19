using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    abstract class GuiElement
    {
        public int x { get; set; }
        public int y { get; set; }
               
        public int width { get; set; }
        public int height { get; set; }

        public GuiElement()
        {
            width = 100;
            height = 100;
        }

        public GuiElement(int width, int height)
        {
            this.width = width;
            this.height = height;
        }


        public GuiElement(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void setLocation(int newx, int newy)
        {
            x = newx;
            y = newy;
        }

        public void setSize(int newwidth, int newheight)
        {
            width = newwidth;
            height = newheight;
        }

        public abstract void draw(DrawerMaym dm);
    }
}
