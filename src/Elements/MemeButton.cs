using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class MemeButton : Button
    {
        private static Random rand = new Random();

        public MemeButton(int width, int height) : base(width, height)
        {
            var x = rand.NextDouble()/3;
            var y = rand.NextDouble()/5;
            backimege = new Imege(Textures.buttonbg0, new Box(x, y, x + 0.1, y + 0.1));
        }
    }
}
