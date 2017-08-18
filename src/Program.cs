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

            Screen s = new Screen();
            

            var e = new Square(500, 500);
            //e.backimege = new Imege(Textures.A);
            e.setText("THESE HOES");

            s.addElement(e);

            GUI.setScreen(s);
        }
    }

    
}
