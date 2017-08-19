using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace pws
{
    
    class Program
    {
        public const bool design = false;

        static void Main(string[] args)
        {
            GUI.launch();

            //FontBuilder.buildFont(Textures.fontovich, FontBuilder.xd);

            LoginScreen loginScreen = new LoginScreen();
            GameScreen gameScreen = new GameScreen();

            GUI.setScreen(gameScreen);
        }
    }

    
}
