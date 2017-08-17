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
            /*
            s.addElement(new Panel(0, 0, 1920, 540, Color.FloralWhite));
            s.addElement(new Panel(0, 540, 1920, 540, Color.CadetBlue));
            s.addElement(new ImageBox(100, 200, 400, 400, Textures.memex, new Box(0.4, 0.2, 0.5, 0.5)));
            s.addElement(new TextBox(40, 40, 400, 100, "THESE HOES AINT LOYAL", FontFamille.font1));
            
             */

            s.addElement(new Button(100, 80, "PRESS ME"));


            GUI.setScreen(s);
        }

        public const int BACKSCREENWIDTH = 1920;
        public const int BACKSCREENHEIGHT = 1080;
    }

    
}
