using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class ImageBox : GuiElement
    {
        public Textures texture { get; set; }

        public ImageBox(int x, int y, int width, int height, Textures t) : base(x, y, width, height)
        {
            texture = t;
        }

        public override void draw(DrawerMaym dm)
        {
            dm.drawTexture(texture, x, y, width, height);
        }
    }
}
