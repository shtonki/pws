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
        public int textPadding;

        private Color bclr = Color.Transparent;
        private Imege backimege;
        private string text = "";
        private FontFamille fontFamily = FontFamille.font1;
        private TextLayout textLayout = new SingleLineFitLayout();

        public Color Backcolor
        {
            get { return bclr; }
            set { bclr = value; }
        }

        public Imege Backimege
        {
            get { return backimege; }
            set { backimege = value; }
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                layoutText();
            }
        }

        public FontFamille FontFamily
        {
            get { return fontFamily; }
            set { fontFamily = value; }
        }

        public Border Border { get; set; }

        public TextLayout TextLayout
        {
            get { return textLayout; }
            set
            {
                textLayout = value;
                layoutText();
            }
        }

        public Square() : base(0, 0, 100, 100)
        {
        }

        public Square(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public Square(int width, int height) : base(0, 0, width, height)
        {
        }

        public Square(int x, int y, int width, int height, Color backgroundColor) : base(x, y, width, height)
        {
            Backcolor = backgroundColor;
        }

        public Square(int width, int height, Color backgroundColor) : base(0, 0, width, height)
        {
            Backcolor = backgroundColor;
        }

        public override void onResize(resizeEventStruct args)
        {
            base.onResize(args);
            layoutText();
        }

        private void layoutText()
        {
            laidText = TextLayout.layout(Text, Width, Height, FontFamily);
        }

        protected LaidText laidText;

        public override void draw(DrawerMaym dm)
        {
            if (Backimege == null)
            {
                dm.fillRectange(Backcolor, 0, 0, width, height);
            }
            else
            {
                dm.drawImege(Backimege, 0, 0, Width, Height);
            }

            laidText?.draw(dm, 0, 0, textPadding, Width);
            Border?.draw(dm, 0, 0, Width, Height);
        }
    }
}
