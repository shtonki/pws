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
        public Imege backimege { get; set; }

        public string text { get; private set; } = "";
        public bool multilineText { get; set; }
        public FontFamille fontFamily { get; set; } = FontFamille.font1;


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

        public void setText(string txt)
        {
            text = txt;
            layoutText();
        }

        private void layoutText()
        {
            textLayout = TextLayout.multiLineLayout(text, width, height, fontFamily);
        }

        private TextLayout textLayout;

        public override void draw(DrawerMaym dm)
        {
            if (backimege == null)
            {
                dm.fillRectange(backcolor, x, y, width, height);
            }
            else
            {
                dm.drawImege(backimege, x, y, width, height);
            }

            textLayout?.draw(dm, x, y);

            
            dm.drawTexture(Textures.border0, x, y, width, 4,          new Box(0.0, 0.0, 0.4, 0.4));
            dm.drawTexture(Textures.border0, x, y, 4, height,         new Box(0.0, 0.0, 0.4, 0.4));
            dm.drawTexture(Textures.border0, x, y+height-4, width, 4, new Box(0.0, 0.0, 0.4, 0.4));
            dm.drawTexture(Textures.border0, x+width-4, y, 4, height, new Box(0.0, 0.0, 0.4, 0.4));
        }
    }
}
