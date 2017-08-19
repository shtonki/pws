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
        private Color bclr = Color.Transparent;
        private Imege backimege;
        private string text = "";
        private bool multilineText;
        private FontFamille fontFamily = FontFamille.font1;

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

        public bool MultilineText
        {
            get { return multilineText; }
            set { multilineText = value; }
        }

        public FontFamille FontFamily
        {
            get { return fontFamily; }
            set { fontFamily = value; }
        }

        public Border Border { get; set; }

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

        private void layoutText()
        {
            textLayout = TextLayout.multiLineLayout(Text, width, height, FontFamily);
        }

        private TextLayout textLayout;

        public override void draw(DrawerMaym dm)
        {
            if (Backimege == null)
            {
                dm.fillRectange(Backcolor, x, y, width, height);
            }
            else
            {
                dm.drawImege(Backimege, x, y, width, height);
            }

            textLayout?.draw(dm, x, y);
            Border?.draw(dm, x, y, width, height);
        }
    }
}
