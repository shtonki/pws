using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class Screen
    {
        public List<GuiElement> elements { get; } = new List<GuiElement>();

        public void addElement(GuiElement element)
        {
            elements.Add(element);
        }
    }
}
