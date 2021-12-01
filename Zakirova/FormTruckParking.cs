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
    public partial class FormTruckParking : Form
    {
        private readonly Parking<Truck, ClassDop> parking;
        public FormTruckParking()
        {
            InitializeComponent();
            parking = new Parking<Truck, ClassDop>(pictureBoxParking.Width,
pictureBoxParking.Height);
            Draw();
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parking.Draw(gr);
            pictureBoxParking.Image = bmp;
        }      
        
        /// <summary>
        /// Обработка нажатия кнопки "Припарковать гоночный автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_parkingMod_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    bool tmp = true;
                    if (Convert.ToInt32(trWheel.SelectedItem) == 2 || Convert.ToInt32(trWheel.SelectedItem) == 3 ||
             Convert.ToInt32(trWheel.SelectedItem) == 4) { tmp = false; }
                    var truck = new DumpTruck(rnd.Next(100, 300), rnd.Next(1000, 2000), dialog.Color,
                   dialogDop.Color, true, true, true, true, Convert.ToInt32(trWheel.SelectedItem), tmp, ornwheels.SelectedIndex);
                   // var truck = new DumpTruck(100, 1000, dialog.Color, dialogDop.Color,
                  // true, true, true, true);
                    if (parking + truck != -1)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Парковка переполнена");
                    }
                }
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Take_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {
                var truck = parking - Convert.ToInt32(maskedTextBox1.Text);
                if (truck != null)
                {
                    FormTruck form = new FormTruck();
                    form.SetTruck(truck);
                    form.ShowDialog();
                }
                Draw();
            }
        }

        private void buttonPlaceCheck_Click(object sender, EventArgs e)
        {
            double index;
            if (maskedTextBoxPlaces.Text != "")
            {
                index = Convert.ToInt32(maskedTextBoxPlaces.Text);
            }
            else { return; }

            if (parking > index)
            {
                MessageBox.Show("До " + index + " места свободных парковочных мест нет");
            }
            else if (parking < index)
            {
                MessageBox.Show("До " + index + " места есть свободные парковочные места");
            }
        }
    }
}
