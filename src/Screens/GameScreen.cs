using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class GameScreen : Screen
    {
        public GameScreen()
        {
            var v = new HexPanel(4, 3, 160);
            v.x = 400;
            v.y = 400;
            //v.moveTo(MoveTo.Center, MoveTo.Center);
            addElement(v);
        }
    }
}
