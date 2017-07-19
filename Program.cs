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

            Screen s = new Screen();
            s.addElement(new Panel(0, 0, 1920, 540, Color.FloralWhite));
            s.addElement(new Panel(0, 540, 1920, 540, Color.CadetBlue));
            s.addElement(new ImageBox(100, 200, 400, 400, Textures.memex));

            GUI.setScreen(s);
        }
    }

    
}
