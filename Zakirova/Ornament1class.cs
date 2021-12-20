using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zakirova
{
    public class Ornament1class : InterDop
    {
        private EnumW newEnum;

        public int Number { set => newEnum = (EnumW)value; }
        public Color DopColor { private set; get; }

        public Ornament1class(int wh_cnt, Color dopColor)
        {
            Number = wh_cnt;
            DopColor = dopColor;
        }

        public void DrawDop(Graphics g, Color dopColor, float _startPosX, float _startPosY)
        {
            Pen dopwheelspen = new Pen(Color.Red);
            Brush dopwheelsbrush = new SolidBrush(dopColor);

            g.DrawEllipse(dopwheelspen, _startPosX + 20, _startPosY + 24, 20, 20);
            g.DrawEllipse(dopwheelspen, _startPosX + 75, _startPosY + 24, 20, 20);

            g.FillEllipse(dopwheelsbrush, _startPosX + 20, _startPosY + 24, 20, 20);
            g.DrawLine(dopwheelspen, _startPosX + 24, _startPosY + 25, _startPosX + 36, _startPosY + 43);
            g.DrawLine(dopwheelspen, _startPosX + 36, _startPosY + 25, _startPosX + 24, _startPosY + 43);

            g.FillEllipse(dopwheelsbrush, _startPosX + 75, _startPosY + 24, 20, 20);
            g.DrawLine(dopwheelspen, _startPosX + 79, _startPosY + 25, _startPosX + 91, _startPosY + 43);
            g.DrawLine(dopwheelspen, _startPosX + 91, _startPosY + 25, _startPosX + 79, _startPosY + 43);

            if (newEnum == EnumW.three)
            {
                g.DrawEllipse(dopwheelspen, _startPosX + 40, _startPosY + 24, 20, 20);

                g.FillEllipse(dopwheelsbrush, _startPosX + 40, _startPosY + 24, 20, 20);
                g.DrawLine(dopwheelspen, _startPosX + 44, _startPosY + 25, _startPosX + 56, _startPosY + 43);
                g.DrawLine(dopwheelspen, _startPosX + 56, _startPosY + 25, _startPosX + 44, _startPosY + 43);
            }
            if (newEnum == EnumW.four)
            {
                g.DrawEllipse(dopwheelspen, _startPosX + 40, _startPosY + 24, 20, 20);
                g.DrawEllipse(dopwheelspen, _startPosX - 5, _startPosY + 24, 20, 20);

                g.FillEllipse(dopwheelsbrush, _startPosX + 40, _startPosY + 24, 20, 20);
                g.DrawLine(dopwheelspen, _startPosX + 44, _startPosY + 25, _startPosX + 56, _startPosY + 43);
                g.DrawLine(dopwheelspen, _startPosX + 56, _startPosY + 25, _startPosX + 44, _startPosY + 43);

                g.FillEllipse(dopwheelsbrush, _startPosX - 5, _startPosY + 24, 20, 20);
                g.DrawLine(dopwheelspen, _startPosX - 1, _startPosY + 25, _startPosX + 11, _startPosY + 43);
                g.DrawLine(dopwheelspen, _startPosX + 11, _startPosY + 25, _startPosX - 1, _startPosY + 43);
            }
        }

    }
}
