using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zakirova
{
    /// <summary>
    /// Параметризованный класс для хранения набора объектов от интерфейса Interface1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Parking<T, M> where T : class, ITTruck where M : class, InterDop
    {
        /// <summary>
        /// Список объектов, которые храним
        /// </summary>
        public readonly List<T> _places;
        /// <summary>
        /// Максимальное количество мест на парковке
        /// </summary>
        private readonly int _maxCount;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private readonly int _placeSizeWidth = 260;
        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private readonly int _placeSizeHeight = 110;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Рамзер парковки - ширина</param>
        /// <param name="picHeight">Рамзер парковки - высота</param>
        public Parking(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxCount = width * height;
            _places = new List<T>();
            pictureWidth = picWidth;
            pictureHeight = picHeight;
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="truck">Добавляемый автомобиль</param>
        /// <returns></returns>
        public static bool operator +(Parking<T, M> t, T truck)
        {
            if (t._places.Count >= t._maxCount)
            {
                return false;
            }
            t._places.Add(truck);
            return true;
        }


        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь
        /// объект</param>
        /// <returns></returns>
    public static T operator -(Parking<T, M> t, int index)
        {
            if(index < -1 || index >= t._places.Count)
            {
                return null;
            }
            T truck = t._places[index];
            t._places.RemoveAt(index);
            return truck;
        }

        
        public static bool operator >(Parking<T, M> p, double index)
        {
            return p.count_p() > index;
        }
        public static bool operator <(Parking<T, M> p, double index)
        {
            return p.count_p() < index;
        }
        public int count_p()
        {
            int count = 0;
            for (int i = 0; i < _places.Count; ++i)
            {
                if (_places[i] != null)
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Count; i++)
            {
                _places[i].SetPosition(5 + i % (pictureWidth / _placeSizeWidth) * _placeSizeWidth + 5, i / (pictureWidth / _placeSizeWidth) *
               _placeSizeHeight + 6, pictureWidth, pictureHeight);
                _places[i].DrawTransport(g);
            }
        }
        /// <summary>
        /// Метод отрисовки разметки парковочных мест
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
                
        {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {//линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight,( i *
                   _placeSizeWidth + _placeSizeWidth / 2) + 90, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth,
               (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _maxCount)
                {
                    return _places[index];
                }
                return null;
            }
        }
    }
}
