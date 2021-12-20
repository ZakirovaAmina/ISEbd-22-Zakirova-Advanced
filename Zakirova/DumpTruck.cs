using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zakirova
{
    /// <summary>
    /// Класс отрисовки самовсвала
    /// </summary>
    public class DumpTruck : Truck
	{
        InterDop IntD;
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия трубы
        /// </summary>
        public bool Duct { private set; get; }
        /// <summary>
        /// Признак наличия кузова
        /// </summary>
        public bool Carcase { private set; get; }
        /// <summary>
        /// Признак наличия передней фары
        /// </summary>
        public bool FrontLight { private set; get; }
        /// <summary>
        /// Признак наличия задней фары
        /// </summary>
        public bool BackLight { private set; get; }
        public string TruckOrn { private set; get; }
        public int NumWheel { private set; get; }
        /// <summary>
        /// Разделитель для записи информации в файл
        /// </summary>
        private readonly char separator = ':';
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес самосвала</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="duct">Признак наличия трубы</param>
        /// <param name="carcase">Признак наличия кузова</param>
        /// <param name="frontLight">Признак наличия передней фары</param>
        /// <param name="backLight">Признак наличия задней фары</param>
        public DumpTruck(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool duct, bool carcase, bool frontLight, bool backLight, int numwheel, bool wheels, string TruckOrn) :
 base(maxSpeed, weight, mainColor, wheels, 100, 60)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Duct = duct;
            Carcase = carcase;
            FrontLight = frontLight;
            BackLight = backLight;
            NumWheel = numwheel;
            Wheels = wheels;
            IntD = new ClassDop(2, dopColor);
            if (TruckOrn == "ClassDop")
            {
                IntD = new ClassDop(numwheel, dopColor);
            }
            if (TruckOrn == "Ornament1class")
            {
                IntD = new Ornament1class(numwheel, dopColor);
            }
            if (TruckOrn == "Ornament2class")
            {
                IntD = new Ornament2class(numwheel, dopColor);
            }
        }
        /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info"></param>
        public DumpTruck(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 11)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                Wheels = Convert.ToBoolean(strs[3]);
                DopColor = Color.FromName(strs[4]);
                Duct = Convert.ToBoolean(strs[5]);
                Carcase = Convert.ToBoolean(strs[6]);
                FrontLight = Convert.ToBoolean(strs[7]);
                BackLight = Convert.ToBoolean(strs[8]);                             
                NumWheel = Convert.ToInt32(strs[9]);
                if (strs[10] == "ClassDop")
                {
                    IntD = new ClassDop(2, Color.Pink);
                }
                else if (strs[10] == "Ornament1class")
                {
                    IntD = new Ornament1class(2, Color.Pink);
                }
                else if (strs[10] == "Ornament2class")
                {
                    IntD = new Ornament2class(2, Color.Pink);
                }
            }
        }
        public override string ToString()
        {
            return
           $"{base.ToString()}{separator}{DopColor.Name}{separator}{Duct}{separator}{Carcase}" +
           $"{separator}{FrontLight}{separator}{BackLight}{separator}{NumWheel}{separator}{TruckOrn}";
        }
        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>

        /// <summary>
        /// Отрисовка самосвала
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {
            Pen fog1 = new Pen(DopColor);
            Pen back1 = new Pen(MainColor);
            Pen light1 = new Pen(Color.Yellow);
            Pen wheel = new Pen(MainColor);

            Brush light = new SolidBrush(Color.Yellow);
            Brush fog = new SolidBrush(DopColor);
            Brush back = new SolidBrush(MainColor);
            Brush wheels = new SolidBrush(MainColor);

            base.DrawTransport(g);

            if (Wheels)
            {
                g.DrawEllipse(wheel, _startPosX + 75, _startPosY + 24, 20, 20);
                g.DrawEllipse(wheel, _startPosX + 20, _startPosY + 24, 20, 20);
                g.DrawEllipse(wheel, _startPosX, _startPosY + 24, 20, 20);

                g.FillEllipse(wheels, _startPosX + 75, _startPosY + 24, 20, 20);
                g.FillEllipse(wheels, _startPosX + 20, _startPosY + 24, 20, 20);
                g.FillEllipse(wheels, _startPosX, _startPosY + 24, 20, 20);
            }
            if (!Wheels)
            {
                IntD.DrawDop(g, DopColor, _startPosX, _startPosY);
            }
            if (FrontLight)
            {
                g.DrawEllipse(light1, _startPosX + 100, _startPosY, 65, 20);
                g.FillEllipse(light, _startPosX + 100, _startPosY, 65, 20);
            }
            if (BackLight)
            {
                g.DrawEllipse(light1, _startPosX - 65, _startPosY + 5, 65, 20);
                g.FillEllipse(light, _startPosX - 65, _startPosY + 5, 65, 20);
            }
            if (Duct)
            {
                g.DrawRectangle(fog1, _startPosX + 90, _startPosY - 57, 10, 16);
                g.FillRectangle(fog, _startPosX + 90, _startPosY - 57, 10, 16);
            }
            if (Carcase)
            {
                g.DrawRectangle(back1, _startPosX, _startPosY - 30, 60, 40);
                g.FillRectangle(back, _startPosX, _startPosY - 30, 60, 40);
            }
        }
        /// <summary>
        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }
        public void SetOrn(InterDop orn)
        {
            IntD = orn;
            TruckOrn = IntD.GetType().Name;
        }
       
    }
}
