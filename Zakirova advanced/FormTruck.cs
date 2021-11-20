using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zakirova
{
	public partial class FormTruck : Form
    {      
        private ITTruck truck;

        public FormTruck()
		{
			InitializeComponent();
        }

        /// <summary>
        /// Метод отрисовки машины
        /// </summary>        
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxTruck.Width, pictureBoxTruck.Height);
            Graphics gr = Graphics.FromImage(bmp);
            truck.DrawTransport(gr);
            pictureBoxTruck.Image = bmp;           
        }
     
       
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bool tmp = true;
            if (Convert.ToInt32(trWheel.SelectedItem) == 2 || Convert.ToInt32(trWheel.SelectedItem) == 3 ||
              Convert.ToInt32(trWheel.SelectedItem) == 4) { tmp = false; }
            truck = new DumpTruck(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Yellow, true, true, true, true, Convert.ToInt32(trWheel.SelectedItem), tmp, ornwheels.SelectedIndex);            
            truck.SetPosition(rnd.Next(80, 500),
           rnd.Next(10, 100), pictureBoxTruck.Width, pictureBoxTruck.Height);
            Draw();
        }      

        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    truck.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    truck.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    truck.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    truck.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }       
    }
}
