using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Zakirova
{
    class ClassDop
    {
        private EnumW newEnum;
      
        public int Number { set => newEnum = (EnumW)value; }
        public void DrawWheels(Graphics g, float _startPosX, float _startPosY)
        {
            switch (newEnum)
            {
                case EnumW.two:
                    DrawTwo(g, _startPosX, _startPosY);
                    break;

                case EnumW.three:
                    DrawThree(g, _startPosX, _startPosY);
                    break;

                case EnumW.four:
                    DrawFour(g, _startPosX, _startPosY);
                    break;
            }
        }
        public ClassDop(int wh_cnt)
        {
            Number = wh_cnt;
        }  
        Pen dopwheelspen = new Pen(Color.Black);
        Brush dopwheelsbrush = new SolidBrush(Color.Red);
        public void DrawTwo(Graphics g, float X, float Y)
        {
          g.DrawEllipse(dopwheelspen, X + 40, Y + 24, 20, 20);
          g.DrawEllipse(dopwheelspen, X + 60, Y + 24, 20, 20);

          g.FillEllipse(dopwheelsbrush, X + 40, Y + 24, 20, 20);
          g.FillEllipse(dopwheelsbrush, X + 60, Y + 24, 20, 20);
        }
        public void DrawThree(Graphics g, float X, float Y)
        {
            DrawTwo(g, X, Y);
            g.DrawEllipse(dopwheelspen, X + 15, Y + 24, 20, 20);
            g.FillEllipse(dopwheelsbrush, X + 15, Y + 24, 20, 20);
        }
        public void DrawFour(Graphics g, float X, float Y)
        {
            DrawThree(g, X, Y);
            g.DrawEllipse(dopwheelspen, X - 5, Y + 24, 20, 20);
            g.FillEllipse(dopwheelsbrush, X - 5, Y + 24, 20, 20);
        }
    }
}
