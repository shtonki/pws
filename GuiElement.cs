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
        protected List<clicked> clickcallbacks = new List<clicked>();
        public int x { get; set; }
        public int y { get; set; }
               
        public int width { get; set; }
        public int height { get; set; }

        public Color backcolor { get; set; } = Color.Transparent;

        public List<GuiElement> children { get; private set; }= new List<GuiElement>();
        public GuiElement parent { get; private set; }

        public GuiElement()
        {
            width = 100;
            height = 100;
        }

        public GuiElement(int width, int height)
        {
            this.width = width;
            this.height = height;
        }


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

        public virtual void draw(DrawerMaym dm)
        {
            dm.fillRectange(backcolor, x, y, width, height);
        }

        public virtual void mouseDown()
        {
            
        }

        public virtual void mouseUp()
        {

        }

        public virtual void mouseLeave()
        {
            
        }

        public virtual void mouseEnter()
        {

        }

        public delegate void clicked();

        public void addCallback(clicked c)
        {
            clickcallbacks.Add(c);
        }
    }
}
