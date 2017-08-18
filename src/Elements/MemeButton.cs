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
            var x = rand.NextDouble()*0.7;
            var y = rand.NextDouble()*0.7;
            backimege = new Imege(Textures.buttonbg2, new Box(x, y, 0.3, 0.3));
        }
    }
}
