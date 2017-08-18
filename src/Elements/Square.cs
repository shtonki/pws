using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class Square : GuiElement
    {
        public Color backcolor { get; set; } = Color.Transparent;

        public Square(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public Square(int width, int height) : base(0, 0, width, height)
        {
        }

        public Square(int x, int y, int width, int height, Color backgroundColor) : base(x, y, width, height)
        {
            backcolor = backgroundColor;
        }

        public override void draw(DrawerMaym dm)
        {

        }
    }
}
