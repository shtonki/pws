using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class ImageBox : Square
    {

        public Textures texture { get; set; }

        private Box crop { get; set; }

        public ImageBox(int x, int y, int width, int height, Textures t) : base(x, y, width, height)
        {
            texture = t;
            crop = new Box(0.0, 0.0, 1.0, 1.0);
        }

        public ImageBox(int x, int y, int width, int height, Textures t, Box crop) : base(x, y, width, height)
        {
            texture = t;
            this.crop = crop;
        }

        public void setCrop(int x, int y, int w, int h)
        {
            var sz = ImageLoader.sizeOf(texture);
            Box b = new Box(
                (double)x/sz.Width,
                (double)y/sz.Height,
                (double)w/sz.Width,
                (double)h/sz.Height
                );
            setCrop(b);
        }

        public void setCrop(double x, double y, double w, double h)
        {
            Box b = new Box(x, y, w, h);
            setCrop(b);
        }

        public void setCrop(Box crop)
        {
            this.crop = crop;
        }

        public override void draw(DrawerMaym dm)
        {
            dm.drawTexture(texture, 0, 0, width, height, crop);
        }
    }
}
