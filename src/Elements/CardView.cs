using System;
using System.Collections.Generic;
using System.Drawing;
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
            namebox.TextLayout = new SingleLineFitLayout();
            addChild(namebox);

            breadbox = new Square();
            breadbox.Text = "II II II II II II II II II II II II II II II II II II II II II II II II ";
            addChild(breadbox);

            movementbox = new Square();
            movementbox.Text = "A";
            movementbox.TextLayout = new SingleLineFitLayout();
            addChild(movementbox);

            ptbox = new Square();
            ptbox.Text = "A A";
            ptbox.TextLayout = new SingleLineFitLayout();
            addChild(ptbox);

            typebox = new Square();
            typebox.Text = "NIG";
            typebox.TextLayout = new SingleLineFitLayout();
            addChild(typebox);

            artbox = new Square();
            artbox.Backimege = new Imege(Textures.A);
            addChild(artbox);

            orbbox = new Square();
            addChild(orbbox);


            topbutton = new Square(0, 0);
            topbutton.clicked += args =>
            {
                this.onClick(args);
            };
            addChild(topbutton);

            layoutStuff();
        }

        private Square topbutton;

        private Square namebox;
        private int nameboxOrigX = 17;
        private int nameboxOrigY = 7;
        private int nameboxOrigW = 123;
        private int nameboxOrigH = 20;

        private Square breadbox;
        private int breadboxOrigX = 33;
        private int breadboxOrigY = 200;
        private int breadboxOrigW = 200;
        private int breadboxOrigH = 100;

        private Square movementbox;
        private int movementboxOrigX = 24;
        private int movementboxOrigY = 321;
        private int movementboxOrigW = 18;
        private int movementboxOrigH = 24;

        private Square ptbox;
        private int ptboxOrigX = 194;
        private int ptboxOrigY = 321;
        private int ptboxOrigW = 43;
        private int ptboxOrigH = 24;

        private Square typebox;
        private int typeboxOrigX = 67;
        private int typeboxOrigY = 321;
        private int typeboxOrigW = 118;
        private int typeboxOrigH = 28;

        private Square artbox;
        private int artboxOrigX = 25;
        private int artboxOrigY = 34;
        private int artboxOrigW = 199;
        private int artboxOrigH = 149;

        private Square orbbox;
        private int orbboxOrigR = 231;
        private int orbboxOrigY = 10;
        private int orbboxOrigW = 199;
        private int orbboxOrigH = 15;

        public void layoutStuff()
        {
            topbutton.setSize(width, height);

            var scale = ((double)height)/frameheight;

            int orbcount = 10;
            int pad = 1;

            orbbox.clearChildren();

            var orbsize = (int)(scale*orbboxOrigH);

            orbbox.X = (int)(scale * orbboxOrigR) - orbcount * orbsize;
            orbbox.Y = (int)(scale * orbboxOrigY);
            orbbox.setSize(
                orbcount * (orbsize + pad),
                orbsize
                );

            for (int i = 0; i < orbcount; i++)
            {
                Square orbsquare = new Square(orbsize, orbsize);
                orbbox.addChild(orbsquare);
                orbsquare.X = i*(orbsize + pad);
                orbsquare.Backimege = new Imege(Textures.orbchaos);
            }


            namebox.X = (int)(scale*nameboxOrigX);
            namebox.Y = (int)(scale*nameboxOrigY);
            namebox.setSize(
                orbbox.X - namebox.X,
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

            typebox.X = (int)(scale * typeboxOrigX);
            typebox.Y = (int)(scale * typeboxOrigY);
            typebox.setSize(
                (int)(scale * typeboxOrigW),
                (int)(scale * typeboxOrigH)
                );

            artbox.X = (int)(scale * artboxOrigX);
            artbox.Y = (int)(scale * artboxOrigY);
            artbox.setSize(
                (int)(scale * artboxOrigW),
                (int)(scale * artboxOrigH)
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

        private const double imgxo = 26.0/framewidth;
        private const double imgxw = 96.0/framewidth;
        

        public override void draw(DrawerMaym dm)
        {
            //base.draw(dm);

            dm.drawTexture(Textures.cardframegrey, 0, 0, width, height);
        }
    }
}
