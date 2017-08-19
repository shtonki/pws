using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace pws
{
    
    class Program
    {
        static void Main(string[] args)
        {
            GUI.launch();

            //FontBuilder.buildFont(Textures.fontovich, FontBuilder.xd);

            Screen s = new Screen(new Imege(Textures.bg0));

            for (int i = 0; i < 5; i++)
            {
                var e = new MemeButton(800, 80);
                e.setLocation(500, 100 + i*100);
                e.Text = "THESE HOES AINT LOYAL";
                e.Border = new AnimatedBorder(Textures.border2, 4);
                e.TextLayout = new MultiLineFitLayout();
                s.addElement(e);
            }

            var v = new InputBox(500, 100);
            v.setLocation(400, 0);
            s.addElement(v);

            GUI.setScreen(s);
        }
    }

    
}
