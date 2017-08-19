using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class MemeButton : Button
    {
        private static Random rand = new Random(420);

        public MemeButton(int width, int height) : base(width, height)
        {
            var x = rand.NextDouble()*0.7;
            var y = rand.NextDouble()*0.7;
            Backimege = new Imege(Textures.buttonbg2, new Box(x, y, 0.3, 0.3));
        }
    }
}
