﻿using System;
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
        public const bool design = true;

        static void Main(string[] args)
        {
            // ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvxyz1234567890!'.",?*/-+&()
            GUI.launch();

            //FontBuilder.buildFont(Textures.fontovich, FontBuilder.xd);

            LoginScreen l = new LoginScreen();
            GameScreen g = new GameScreen();

            GUI.setScreen(l);
        }
    }

    
}
