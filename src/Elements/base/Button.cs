using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class Button : Square
    {
        public Button(int width, int height) : base(width, height)
        {
            mouseDown += args =>
            {
                pressed = true;
            };

            mouseUp += args =>
            {
                if (pressed) onClick?.Invoke();
                pressed = false;
            };

            mouseLeft += args =>
            {
                pressed = false;
            };
        }

        private static Color pressedColor = Color.FromArgb(50, 50, 50, 50);
        private bool pressed;

        public override void draw(DrawerMaym dm)
        {
            base.draw(dm);

            if (pressed)
            {
                dm.fillRectange(pressedColor, 0, 0, width, height);
            }
        }

        public delegate void clicked();
        public event clicked onClick;
    }
}
