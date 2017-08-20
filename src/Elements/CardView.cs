using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class CardView : Square
    {
        private const int framewidth = 250;
        private const int frameheight = 350;

        public CardView() : base(framewidth, frameheight)
        {
            namebox = new Square();
            namebox.Text = "RASPUTIN";
            namebox.TextLayout = new SingleLineLayout();
            addChild(namebox);

            breadbox = new Square();
            breadbox.Text = "FLYING";
            addChild(breadbox);

            movementbox = new Square();
            movementbox.Text = "A";
            movementbox.TextLayout = new SingleLineFitLayout();
            addChild(movementbox);

            ptbox = new Square();
            ptbox.Text = "A A";
            ptbox.TextLayout = new SingleLineFitLayout();
            addChild(ptbox);

            layoutStuff();
        }

        private Square namebox;
        private int nameboxOrigX = 22;
        private int nameboxOrigY = 7;
        private int nameboxOrigW = 123;
        private int nameboxOrigH = 19;

        private Square breadbox;
        private int breadboxOrigX = 33;
        private int breadboxOrigY = 200;
        private int breadboxOrigW = 200;
        private int breadboxOrigH = 100;

        private Square movementbox;
        private int movementboxOrigX = 30;
        private int movementboxOrigY = 323;
        private int movementboxOrigW = 18;
        private int movementboxOrigH = 24;

        private Square ptbox;
        private int ptboxOrigX = 191;
        private int ptboxOrigY = 323;
        private int ptboxOrigW = 39;
        private int ptboxOrigH = 24;

        public void layoutStuff()
        {
            var scale = ((double)height)/frameheight;

            namebox.X = (int)(scale*nameboxOrigX);
            namebox.Y = (int)(scale*nameboxOrigY);
            namebox.setSize(
                (int)(scale * nameboxOrigW),
                (int)(scale * nameboxOrigH)
                );

            breadbox.X = (int)(scale * breadboxOrigX);
            breadbox.Y = (int)(scale * breadboxOrigY);
            breadbox.setSize(
                (int)(scale * breadboxOrigW),
                (int)(scale * breadboxOrigH),
                new MultiLineFitLayout(height/10)
                );

            movementbox.X = (int)(scale * movementboxOrigX);
            movementbox.Y = (int)(scale * movementboxOrigY);
            movementbox.setSize(
                (int)(scale * movementboxOrigW),
                (int)(scale * movementboxOrigH)
                );

            ptbox.X = (int)(scale * ptboxOrigX);
            ptbox.Y = (int)(scale * ptboxOrigY);
            ptbox.setSize(
                (int)(scale * ptboxOrigW),
                (int)(scale * ptboxOrigH)
                );
        }

        public override int Width
        {
            get { return width; }
            set
            {
                width = value;
                height = width * frameheight / framewidth;
                layoutStuff();
            }
        }

        public override int Height
        {
            get { return height; }
            set
            {
                height = value;
                width = height*framewidth/frameheight;
                layoutStuff();
            }
        }

        public override void draw(DrawerMaym dm)
        {
            //base.draw(dm);
            dm.drawTexture(Textures.cardframegrey, 0, 0, width, height);
        }
    }
}
