﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class LoginScreen : Screen
    {
        private InputBox username;
        private InputBox password;

        private Square usernameLabel;
        private Square passwordLabel;

        private Button loginButton;

        public LoginScreen() : base(new Imege(Textures.bg3))
        {
            username = new InputBox(1000, 100);
            addElement(username);
            username.moveTo(MoveTo.Center, 200);
            username.Border = new SolidBorder(3, Color.Black);
            username.Backcolor = Color.DimGray;

            password = new InputBox(1000, 100);
            addElement(password);
            password.moveTo(MoveTo.Center, 400);
            password.Border = new SolidBorder(3, Color.Black);
            password.Backcolor = Color.DimGray;

            usernameLabel = new Square(220, 60);
            addElement(usernameLabel);
            usernameLabel.moveTo(MoveTo.Center, 140);
            usernameLabel.Text = "USERNAME";

            passwordLabel = new Square(220, 60);
            addElement(passwordLabel);
            passwordLabel.moveTo(MoveTo.Center, 340);
            passwordLabel.Text = "PASSVORD";

            loginButton = new MemeButton(500, 80);
            addElement(loginButton);
            loginButton.moveTo(MoveTo.Center, 550);
            loginButton.Text = "LOG IN";
            loginButton.Border = new AnimatedBorder(Textures.border0, 5);
        }
    }
}
