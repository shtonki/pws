using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pws
{
    static class FontBuilder
    {
        public static string xd = "ABCDEFGHIJKLMNOPQRSTUVXYZ";

        public static void buildFont(Textures fontimage, string glyphstring)
        {
            throw new Exception();
            Screen s = new LoginScreen();
            GUI.setScreen(s);

            var bp = new Square(0, 0, 500, 500, Color.LightCoral);
            s.addElement(bp);

            var v = new ImageBox(0, 0, 500, 500, Textures.fontovich);
            s.addElement(v);

            int l = 0;
            int w = 30;


            List<string> glyphs = glyphiphy(glyphstring);
            List<glyphxd> xds = new List<glyphxd>();

            while (true)
            {
                v.setCrop(l, 0, w, 64);
                string i = Console.ReadLine();
                if (i.Length == 0)
                {
                    xds.Add(new glyphxd(l, w));

                    l = l + w;
                    w = 20;
                }
                else if (i == "quit")
                {
                    break;
                }
                else
                {
                    w = Int32.Parse(i);
                }
            }

            using (StreamWriter writer = new StreamWriter("font.txt"))
            {
                for (int i = 0; i < xds.Count; i++)
                {
                    writer.WriteLine("{0} {1} {2}", glyphs[i], xds[i].startx, xds[i].width);
                }
            }
        }

        private static List<string> glyphiphy(string s)
        {
            List<string> rt = new List<string>();
            int p = 0;
            while (p < s.Length)
            {
                rt.Add(s[p].ToString());
                p++;
            }
            return rt;
        }
    }
}
