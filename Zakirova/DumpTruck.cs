﻿using System;
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
        private InterDop IntD;
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
        /// <param name="wheels">Признак наличия исходных колес</param>

        public DumpTruck(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool duct, bool carcase, bool frontLight, bool backLight, int numwheel, bool wheels, int TruckOrn) :
 base(maxSpeed, weight, mainColor, 100, 60)
        {
            MaxSpeed = maxSpeed;            
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Duct = duct;
            Carcase = carcase;
            FrontLight = frontLight;
            BackLight = backLight;

            Wheels = wheels;
            switch (TruckOrn)
            {
                case 0:
                    IntD = new ClassDop(numwheel, mainColor);
                    break;
                case 1:
                    IntD = new Ornament1class(numwheel);
                    break;
                case 2:
                    IntD = new Ornament2class(numwheel);
                    break;
            }
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
    }
}