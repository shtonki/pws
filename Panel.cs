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
        private Color backgroundColor;

        public Panel(int x, int y, int width, int height, Color backgroundColor) : base(x, y, width, height)
        {
            this.backgroundColor = backgroundColor;
        }

        public override void draw(DrawerMaym dm)
        {
            dm.fillRectange(backgroundColor, x, y, width, height);
        }
    }
}
