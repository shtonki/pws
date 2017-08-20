using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class CardView : Square
    {
        private const int framewidth = 180;
        private const int frameheight = 280;

        public CardView() : base(framewidth, frameheight)
        {
            //Backimege = new Imege(Textures.cardframegrey);
        }

        public override void draw(DrawerMaym dm)
        {
            //base.draw(dm);
            dm.drawTexture(Textures.cardframegrey, x, y, width, height);
        }
    }
}
