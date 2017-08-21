using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class GameScreen : Screen
    {
        public GameScreen() : base(new Imege(Textures.table0))
        {
            /*/
            var v = new HexPanel(11, 7, 80);
            var p = new Square();
            p.width = v.width + 50;
            p.height = v.height + 50;
            p.Backimege = new Imege(Textures.table0);
            p.addChild(v);
            v.moveTo(MoveTo.Center, MoveTo.Center);
            addElement(p);
            /*/
            int xxx = 0;

            for (int i = 0; i < 5; i++)
            {
                CardView cv = new CardView();
                cv.Height = 150 + i*100;
                cv.X = xxx;
                xxx += cv.Width;
                addElement(cv);
            }
            //*/
        }
    }
}
