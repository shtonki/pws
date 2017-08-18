using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class Panel : GuiElement
    {
        public Panel(int x, int y, int width, int height, Color backgroundColor) : base(x, y, width, height)
        {
            backcolor = backgroundColor;
        }

        public override void draw(DrawerMaym dm)
        {
            base.draw(dm);
        }
    }
}
