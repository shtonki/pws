﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace pws
{
    abstract class GuiElement
    {

        public int x { get; set; }
        public int y { get; set; }
               
        public int width { get; set; }
        public int height { get; set; }
        
        public bool focused { get; private set; }
        public bool selectable { get; set; }

        public List<GuiElement> children { get; private set; }= new List<GuiElement>();
        public GuiElement parent { get; private set; }

        public GuiElement(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void setLocation(int newx, int newy)
        {
            x = newx;
            y = newy;
        }

        public void setSize(int newwidth, int newheight)
        {
            width = newwidth;
            height = newheight;
        }

        public void addChild(GuiElement child)
        {
            children.Add(child);
            child.parent = this;
        }

        public bool focus()
        {
            if (selectable) focused = true;
            return selectable;
        }

        public void unfocus()
        {
            focused = false;
        }

        public abstract void draw(DrawerMaym dm);

        public virtual void onMouseDown(MouseButtonEventArgs args)
        {
            mouseDown?.Invoke(args);
        }

        public virtual void onMouseUp(MouseButtonEventArgs args)
        {
            mouseUp?.Invoke(args);
        }

        public virtual void onMouseLeave(MouseMoveEventArgs args)
        {
            mouseLeft?.Invoke(args);
        }

        public virtual void onKeyDown(KeyboardKeyEventArgs args)
        {
            keyDown?.Invoke(args);
        }

        public virtual void onMouseEnter(MouseMoveEventArgs args)
        {

        }

        public delegate void  mouseClickEventHandler(MouseButtonEventArgs args);
        public delegate void mouseMoveEventHandler(MouseMoveEventArgs args);
        public delegate void keyboardEvent(KeyboardKeyEventArgs args);

        public event mouseClickEventHandler mouseDown;
        public event mouseClickEventHandler mouseUp;
        public event mouseMoveEventHandler mouseLeft;
        public event keyboardEvent keyDown;

    }
}
