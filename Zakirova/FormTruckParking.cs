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
        private readonly ParkingCollection parkingCollection;
        private Stack<Vehicle> TruckInStack;
        public FormTruckParking()
        {
            InitializeComponent();
            parkingCollection = new ParkingCollection(pictureBoxParking.Width,
pictureBoxParking.Height);
            TruckInStack = new Stack<Vehicle>();
            Draw();
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        private void Draw()
        {
            if (listBoxParking.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни один пункт
             //не будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу listBox)
                Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
                Graphics gr = Graphics.FromImage(bmp);
                parkingCollection[listBoxParking.SelectedItem.ToString()].Draw(gr);
                pictureBoxParking.Image = bmp;
            }
        }

        private void ReloadLevels()
        {
            int index = listBoxParking.SelectedIndex;
            listBoxParking.Items.Clear();
            for (int i = 0; i < parkingCollection.Keys.Count; i++)
            {
                listBoxParking.Items.Add(parkingCollection.Keys[i]);
            }
            if (listBoxParking.Items.Count > 0 && (index == -1 || index >=
           listBoxParking.Items.Count))
            {
                listBoxParking.SelectedIndex = 0;
            }
            else if (listBoxParking.Items.Count > 0 && index > -1 && index <
           listBoxParking.Items.Count)
            {
                listBoxParking.SelectedIndex = index;
            }
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
                    if (parkingCollection[listBoxParking.SelectedItem.ToString()] + truck)
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
            if (listBoxParking.SelectedIndex > -1 && maskedTextBox1.Text != "")
            {

                var truck = parkingCollection[listBoxParking.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox1.Text);
                if (truck != null)
                {
                    TruckInStack.Push(truck);
                }
                Draw();
                maskedTextBox1.Text = "";
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

            if (parkingCollection[listBoxParking.SelectedItem.ToString()] > index)
            {
                MessageBox.Show("До " + index + " места свободных доков нет");
            }
            else if (parkingCollection[listBoxParking.SelectedItem.ToString()] < index)
            {
                MessageBox.Show("До " + index + " места есть свободные доки");
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Добавить парковку"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPark_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLevelsName.Text))
            {
                MessageBox.Show("Введите название парковки", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parkingCollection.AddTruckParking(textBoxLevelsName.Text);
            ReloadLevels();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Удалить парковку"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void DelPark_Click_1(object sender, EventArgs e)
        {
            if (listBoxParking.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить парковку {listBoxParking.SelectedItem.ToString()}?", "Удаление",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    parkingCollection.DelParking(textBoxLevelsName.Text);
                    ReloadLevels();
                }
            }
        }

        /// <summary>
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void listBoxParking_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Draw();
        }       

        private void button_TakeFromStack_Click(object sender, EventArgs e)
        {
            if (TruckInStack.Count() > 0)
            {
                var truck = TruckInStack.Pop();
                if (truck != null)
                {
                    FormTruck form = new FormTruck();
                    Random rnd = new Random();
                    truck.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), form.Size.Width, form.Size.Height);
                    form.SetTruck(truck);
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Стек пустой");
            }
            Draw();
        }

        

        
    }
}
