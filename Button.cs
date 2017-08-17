using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    class Button : TextBox
    {
        public Button(int width, int height, string text) : base(width, height, text)
        {
            backcolor = Color.Gainsboro;
        }

        public override void mouseDown()
        {
            base.mouseDown();
            meme();
        }

        public override void mouseUp()
        {
            base.mouseUp();
            if (memed) Console.WriteLine("xd");
            dememe();
        }

        public override void mouseLeave()
        {
            base.mouseLeave();
            dememe();
        }

        private bool memed;

        private void meme()
        {
            memed = true;
            backcolor = Color.DimGray;
        }

        private void dememe()
        {
            memed = false;
            backcolor = Color.Gainsboro;
        }
    }
}
