using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Zakirova
{
    class ParkingCollection
    {
        /// <summary>
        /// Словарь (хранилище) с парковками
        /// </summary>
        readonly Dictionary<string, Parking<Vehicle, ClassDop>> parkingStages;
        /// <summary>
        /// Возвращение списка названий праковок
        /// </summary>
        public List<string> Keys => parkingStages.Keys.ToList();
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Разделитель для записи информации в файл
        /// </summary>
        private readonly char separator = ':';
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public ParkingCollection(int pictureWidth, int pictureHeight)
        {
            parkingStages = new Dictionary<string, Parking<Vehicle, ClassDop>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }

        /// <summary>
        /// Добавление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void AddTruckParking(string name)
        {
            if (parkingStages.ContainsKey(name))
            {
                return;
            }
            parkingStages.Add(name, new Parking<Vehicle, ClassDop>(pictureWidth, pictureHeight));
        }
        /// <summary>
        /// Удаление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void DelParking(string name)
        {
            if (parkingStages.ContainsKey(name))
            {
                parkingStages.Remove(name);
            }
        }
        /// <summary>
        /// Доступ к парковке
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Parking<Vehicle, ClassDop> this[string ind]
        {
            get
            {
                if (parkingStages.ContainsKey(ind))
                {
                    return parkingStages[ind];
                }
                else
                {
                    return null;
                }
            }
        }
        public Vehicle this[string ind, int ind2]
        {
            get
            {
                if (parkingStages.ContainsKey(ind))
                {
                    return parkingStages[ind][ind2];
                }
                return null;
            }
        }

        /// <summary>
        /// Метод записи информации в файл
        /// </summary>
        /// <param name="text">Строка, которую следует записать</param>
        /// <param name="stream">Поток для записи</param>
        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine($"ParkingCollection");

                    foreach (var level in parkingStages)
                    {
                        sw.WriteLine($"Parking{separator}{level.Key}");
                        ITTruck truck = null;
                        for (int i = 0; (truck = level.Value[i]) != null; i++)
                        {
                            if (truck != null)
                            {
                                if (truck.GetType().Name == "Truck")
                                {
                                    sw.Write($"Truck{separator}");

                                }
                                if (truck.GetType().Name == "DumpTruck")
                                {
                                    sw.Write($"DumpTruck{separator}");
                                }
                                sw.WriteLine(truck);
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool SaveData(string filename, string parkName)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            if (!parkingStages.ContainsKey(parkName))
            {
                return false;
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine($"OneTruckParking");

                    sw.WriteLine($"Parking{separator}{parkName}");
                    ITTruck truck = null;
                    var level = parkingStages[parkName];


                    for (int i = 0; (truck = level[i]) != null; i++)
                    {
                        if (truck != null)
                        {
                            if (truck.GetType().Name == "Truck")
                            {
                                sw.Write($"Truck{separator}");

                            }
                            if (truck.GetType().Name == "DumpTruck")
                            {
                                sw.Write($"DumpTruck{separator}");
                            }
                            sw.WriteLine(truck);
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Загрузка информации по автобусам на парковках из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadParking(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                if (line.Contains("ParkingCollection"))
                {
                    parkingStages.Clear();
                }
                else
                {
                    return false;
                }
                line = sr.ReadLine();
                Vehicle truck = null;
                string key = string.Empty;
                while (line != null && line.Contains("Parking"))
                {
                    key = line.Split(separator)[1];
                    parkingStages.Add(key, new Parking<Vehicle, ClassDop>(pictureWidth, pictureHeight));

                    line = sr.ReadLine();
                    while (line != null && (line.Contains("Truck") || line.Contains("DumpTruck")))
                    {
                        if (line.Split(separator)[0] == "Truck")
                        {
                            truck = new Truck(line.Split(separator)[1]);
                        }
                        else if (line.Split(separator)[0] == "DumpTruck")
                        {
                            truck = new DumpTruck(line.Split(separator)[1]);
                        }
                        var result = parkingStages[key] + truck;
                        if (!result)
                        {
                            return false;
                        }
                        line = sr.ReadLine();
                    }
                }
                return true;
            }
        }

        public bool LoadOneParking(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();

                if (line.Contains("OneTruckParking")) { }
                else
                {
                    return false;
                }
                line = sr.ReadLine();
                Vehicle bus = null;
                string key = string.Empty;
                if (line != null && line.Contains("Parking"))
                {
                    key = line.Split(separator)[1];
                    if (parkingStages.ContainsKey(key))
                    {
                        parkingStages[key].ClearPlaces();
                    }
                    else
                    {
                        parkingStages.Add(key, new Parking<Vehicle, ClassDop>(pictureWidth, pictureHeight));
                    }

                    line = sr.ReadLine();
                    while (line != null && (line.Contains("Truck") || line.Contains("DumpTruck")))
                    {
                        if (line.Split(separator)[0] == "Truck")
                        {
                            bus = new Truck(line.Split(separator)[1]);
                        }
                        else if (line.Split(separator)[0] == "DumpTruck")
                        {
                            bus = new DumpTruck(line.Split(separator)[1]);
                        }
                        var result = parkingStages[key] + bus;
                        if (!result)
                        {
                            return false;
                        }
                        line = sr.ReadLine();
                    }
                }
                else return false;
                return true;
            }
        }
    }

}
