using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace pws
{
    class InputBox : Square
    {
        public InputBox(int width, int height) : base(width, height)
        {
            TextLayout = new SingleLineLayout();
            selectable = true;
            Backcolor = Color.FloralWhite;
        }

        public override void onKeyDown(KeyboardKeyEventArgs args)
        {
            base.onKeyDown(args);

            char? c = null;

            if (args.Key == Key.Space)
            {
                c = ' ';
            }
            else if (args.Key == Key.BackSpace)
            {
                if (Text.Length > 0) Text = Text.Substring(0, Text.Length - 1);
            }
            else
            {
                var v = args.Key.ToString();
                if (v.Length == 1)
                {
                    c = v[0];
                }
            }

            if (c.HasValue)
            {
                Text = Text + c.Value;
            }


            int textWidth = laidText.xs.Sum(cl => cl.width);
            if (textWidth > width)
            {
                textPadding = width - textWidth - 1;
            }
            else
            {
                textPadding = 0;
            }
        }
    }
}
