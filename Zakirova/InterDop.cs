using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Zakirova
{
    public interface InterDop
    {
        int Number { set; }

        void DrawDop(Graphics g, Color dopColor, float X, float Y);
    }
}