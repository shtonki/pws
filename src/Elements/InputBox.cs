using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace pws
{
    class InputBox : Square
    {
        public InputBox()
        {
            selectable = true;
        }

        public override void onKeyDown(KeyboardKeyEventArgs args)
        {
            base.onKeyDown(args);
            Console.WriteLine(args.Key);
        }
    }
}
