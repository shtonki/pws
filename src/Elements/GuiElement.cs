using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    abstract class GuiElement
    {

        public int x { get; set; }
        public int y { get; set; }
               
        public int width { get; set; }
        public int height { get; set; }


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

        public abstract void draw(DrawerMaym dm);

        public virtual void onMouseDown()
        {
            
        }

        public virtual void onMouseUp()
        {

        }

        public virtual void onMouseLeave()
        {
            
        }

        public virtual void onMouseEnter()
        {

        }

        public delegate void  mouseDownedEventHandler();
        public delegate void mouseEnteredEventHandler();
        public delegate void    mouseLeftEventHandler();
        public delegate void    mouseUpedEventHandler();
        public delegate void   mouseMovedEventHandler();


        public event mouseDownedEventHandler mouseDown;

    }
}
