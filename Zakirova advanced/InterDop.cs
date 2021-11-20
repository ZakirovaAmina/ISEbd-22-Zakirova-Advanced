using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Zakirova
{
    interface InterDop
    {
        int Number { set; }

        void DrawDop(Graphics g, float X, float Y);
    }
}
