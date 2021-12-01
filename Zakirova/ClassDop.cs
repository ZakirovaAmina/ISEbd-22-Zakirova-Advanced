using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Zakirova
{
    class ClassDop : InterDop
    {
        private EnumW newEnum;

        public int Number { set => newEnum = (EnumW)value; }
        public Color DopColor { private set; get; }

        public ClassDop(int wh_cnt, Color dopColor)
        {
            Number = wh_cnt;
            DopColor = dopColor;
        }

        public void DrawDop(Graphics g, Color dopColor, float X, float Y)
        {
            Pen dopwheelspen = new Pen(Color.Black);
            Brush dopwheelsbrush = new SolidBrush(dopColor);
           
                g.DrawEllipse(dopwheelspen, X + 20, Y + 24, 20, 20);
                g.DrawEllipse(dopwheelspen, X + 75, Y + 24, 20, 20);

                g.FillEllipse(dopwheelsbrush, X + 20, Y + 24, 20, 20);
                g.FillEllipse(dopwheelsbrush, X + 75, Y + 24, 20, 20);
           

            if (newEnum == EnumW.three)
            {
                g.DrawEllipse(dopwheelspen, X + 20, Y + 24, 20, 20);
                g.DrawEllipse(dopwheelspen, X + 75, Y + 24, 20, 20);
                g.FillEllipse(dopwheelsbrush, X + 20, Y + 24, 20, 20);
                g.FillEllipse(dopwheelsbrush, X + 75, Y + 24, 20, 20);

                g.DrawEllipse(dopwheelspen, X + 40, Y + 24, 20, 20);
                g.FillEllipse(dopwheelsbrush, X + 40, Y + 24, 20, 20);
            }

            if (newEnum == EnumW.four)
            {
                g.DrawEllipse(dopwheelspen, X + 20, Y + 24, 20, 20);
                g.DrawEllipse(dopwheelspen, X + 75, Y + 24, 20, 20);
                g.FillEllipse(dopwheelsbrush, X + 20, Y + 24, 20, 20);
                g.FillEllipse(dopwheelsbrush, X + 75, Y + 24, 20, 20);
                g.DrawEllipse(dopwheelspen, X + 40, Y + 24, 20, 20);
                g.FillEllipse(dopwheelsbrush, X + 40, Y + 24, 20, 20);

                g.DrawEllipse(dopwheelspen, X - 5, Y + 24, 20, 20);
                g.FillEllipse(dopwheelsbrush, X - 5, Y + 24, 20, 20);
            }
        }
       
    }
}
