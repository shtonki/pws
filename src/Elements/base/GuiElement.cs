using System;
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

        public int x;
        public int y;


        public int width;
        public int height;
        
        public bool focused { get; private set; }
        public bool selectable { get; set; }

        public List<GuiElement> children { get; private set; }= new List<GuiElement>();
        public GuiElement parent { get; private set; }

        public int X
        {
            get { return x; }
            set { setLocation(value, y); }
        }

        public int Y
        {
            get { return y; }
            set { setLocation(x, value); }
        }

        public virtual int Width
        {
            get { return width; }
            set { width = value; }
        }

        public virtual int Height
        {
            get { return height; }
            set { height = value; }
        }

        public GuiElement(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public GuiElement(int width, int height)
        {
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
            resizeEventStruct args = new resizeEventStruct(newwidth, newheight, width, height);
            width = newwidth;
            height = newheight;
            onResize(args);
        }

        public void addChild(GuiElement child)
        {
            if (child.parent != null) throw new Exception();
            if (children.Contains(child)) throw new Exception();
            children.Add(child);
            child.parent = this;
        }

        public void removeChild(GuiElement child)
        {
            children.Remove(child);
            child.parent = null;
        }

        public void clearChildren()
        {
            while (children.Count > 0)
            {
                removeChild(children[0]);
            }
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

        public void moveTo(MoveTo xPlacement, int yVal)
        {
            moveTo(xPlacement, MoveTo.Nowhere);
            Y = yVal;
        }

        public void moveTo(int xVal, MoveTo yPlacement)
        {
            moveTo(MoveTo.Nowhere, yPlacement);
            X = xVal;
        }

        public void moveTo(MoveTo xPlacement, MoveTo yPlacement)
        {
            int px, py, pw, ph;
            if (parent == null)
            {
                px = py = 0;
                pw = Frame.BACKSCREENWIDTH;
                ph = Frame.BACKSCREENHEIGHT;
            }
            else
            {
                px = parent.X;
                py = parent.Y;
                pw = parent.Width;
                ph = parent.Height;
            }

            X = koenDontKillMe(xPlacement, X, Width, px, pw);
            Y = koenDontKillMe(yPlacement, Y, Height, py, ph);
        }
        
        private int koenDontKillMe(MoveTo mt, int thisLocation, int thisSize, int parentLocation, int parentSize)
        {
            switch (mt)
            {
                case MoveTo.Center:
                {
                    return parentLocation + (parentSize / 2 - thisSize / 2);
                }

                case MoveTo.Nowhere:
                {
                    return thisLocation;
                }

                default:
                    throw new Exception();
            }
        }

        public abstract void draw(DrawerMaym dm);

        protected bool pressed;

        public virtual void onClick(MouseButtonEventArgs args)
        {
            clicked?.Invoke(args);
        }

        public virtual void onMouseDown(MouseButtonEventArgs args)
        {
            mouseDown?.Invoke(args);
            pressed = true;
        }

        public virtual void onMouseUp(MouseButtonEventArgs args)
        {
            mouseUp?.Invoke(args);
            if (pressed)
            {
                onClick(args);
            }
            pressed = false;
        }

        public virtual void onMouseLeave(MouseMoveEventArgs args)
        {
            mouseLeft?.Invoke(args);
            pressed = false;
        }

        public virtual void onKeyDown(KeyboardKeyEventArgs args)
        {
            keyDown?.Invoke(args);
        }

        public virtual void onMouseEnter(MouseMoveEventArgs args)
        {

        }

        public virtual void onResize(resizeEventStruct args)
        {
            resize?.Invoke(args);
        }

        public delegate void  mouseClickEventHandler(MouseButtonEventArgs args);
        public delegate void mouseMoveEventHandler(MouseMoveEventArgs args);
        public delegate void keyboardEvent(KeyboardKeyEventArgs args);
        public delegate void resizeEvent(resizeEventStruct args);

        public event mouseClickEventHandler mouseDown;
        public event mouseClickEventHandler mouseUp;
        public event mouseMoveEventHandler mouseLeft;
        public event mouseClickEventHandler clicked;
        public event keyboardEvent keyDown;
        public event resizeEvent resize;
    }

    public struct resizeEventStruct
    {
        public int newHeight;
        public int newWidth;
        public int oldHeight;
        public int oldWidth;

        public resizeEventStruct(int newWidth, int newHeight, int oldWidth, int oldHeight)
        {
            this.newHeight = newHeight;
            this.newWidth = newWidth;
            this.oldHeight = oldHeight;
            this.oldWidth = oldWidth;
        }
    }

    public enum MoveTo
    {
        Center,
        Nowhere,
    }
}
