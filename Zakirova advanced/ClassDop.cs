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
       
        public ClassDop(int wh_cnt)
        {
            Number = wh_cnt;
        }
        
        public void DrawDop(Graphics g, float X, float Y)
        {
            Pen dopwheelspen = new Pen(Color.Black);
            Brush dopwheelsbrush = new SolidBrush(Color.Red);
            if (newEnum == EnumW.two)
            {
                g.DrawEllipse(dopwheelspen, X + 20, Y + 24, 20, 20);
                g.DrawEllipse(dopwheelspen, X + 75, Y + 24, 20, 20);

                g.FillEllipse(dopwheelsbrush, X + 20, Y + 24, 20, 20);
                g.FillEllipse(dopwheelsbrush, X + 75, Y + 24, 20, 20);
            }

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
        public void DrawTwo(Graphics g, float X, float Y)
        {
            
        }
        public void DrawThree(Graphics g, float X, float Y)
        {
            DrawTwo(g, X, Y);
            
        }
        public void DrawFour(Graphics g, float X, float Y)
        {
            DrawThree(g, X, Y);
            
        }
    }
}
