using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class Border
    {
        public Textures texture;
        public int thickness;

        public Border(Textures texture, int thickness)
        {
            this.texture = texture;
            this.thickness = thickness;
        }

        public void draw(DrawerMaym dm)
        {
            
        }
    }
}
