﻿using System;
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
            CardView cv = new CardView();
            Square s = new Square(180, 280);
            s.Backimege = new Imege(Textures.cardframegrey);
            addElement(cv);
            //*/
        }
    }
}
