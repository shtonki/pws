using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    abstract class Screen
    {
        public Imege background { get; }

        public Screen()
        {
        }

        public Screen(Imege background)
        {
            this.background = background;
        }

        public List<GuiElement> elements { get; } = new List<GuiElement>();

        public void addElement(GuiElement element)
        {
            elements.Add(element);
        }
    }
}
