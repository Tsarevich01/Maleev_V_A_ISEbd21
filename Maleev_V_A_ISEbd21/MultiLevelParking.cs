﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Maleev_V_A_ISEbd21
{
    public class MultiLevelParking
    {
        /// <summary>
        /// Список с уровнями парковки
        /// </summary>
        List<Parking<Itest>> parkingStages;
        /// <summary>
        /// Сколько мест на каждом уровне
        /// </summary>
        private const int countPlaces = 3;


        private int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int pictureHeight;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="countStages">Количество уровенй парковки</param>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public MultiLevelParking(int countStages, int pictureWidth, int pictureHeight)
        {
            parkingStages = new List<Parking<Itest>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
            for (int i = 0; i < countStages; ++i)
            {
                parkingStages.Add(new Parking<Itest>(countPlaces, pictureWidth,
               pictureHeight));
            }
        }
        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Parking<Itest> this[int ind]
        {
            get
            {
                if (ind > -1 && ind < parkingStages.Count)
                {
                    return parkingStages[ind];
                }
                return null;
            }
        }

        public void SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                //Записываем количество уровней
                WriteToFile("CountLeveles:" + parkingStages.Count + Environment.NewLine, fs);
                foreach (var level in parkingStages)
                {
                    //Начинаем уровень
                    WriteToFile("Level" + Environment.NewLine, fs);
                    for (int i = 0; i < countPlaces; i++)
                    {
                        try
                        {
                            var car = level[i];
                            //Записываем тип мшаины
                            if (car.GetType().Name == "Truck")
                            {
                                WriteToFile(i + ":Truck:", fs);
                            }
                            if (car.GetType().Name == "Benzovoz")
                            {
                                WriteToFile(i + ":Benzovoz:", fs);
                            }
                            //Записываемые параметры
                            WriteToFile(car + Environment.NewLine, fs);
                        }
                        finally { }
                    }
                }
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
        /// <summary>
        /// Загрузка нформации по автомобилям на парковках из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            string bufferTextFromFile = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                byte[] b = new byte[fs.Length];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    bufferTextFromFile += temp.GetString(b);
                }
            }
            bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
            var strs = bufferTextFromFile.Split('\n');
            if (strs[0].Contains("CountLeveles"))
            {
                //считываем количество уровней
                int count = Convert.ToInt32(strs[0].Split(':')[1]);
                if (parkingStages != null)
                {
                    parkingStages.Clear();
                }
                parkingStages = new List<Parking<Itest>>(count);
            }
            else
            {
                //если нет такой записи, то это не те данные
                throw new Exception("Неверный формат файла");
            }
            int counter = -1;
            int counterCar = 0;
            Itest car = null;
            for (int i = 1; i < strs.Length; ++i)
            {
                //идем по считанным записям
                if (strs[i] == "Level")
                {
                    //начинаем новый уровень
                    counter++;
                    counterCar = 0;
                    parkingStages.Add(new Parking<Itest>(countPlaces, pictureWidth,
                    pictureHeight));
                    continue;
                }
                if (string.IsNullOrEmpty(strs[i]))
                {
                    continue;
                }
                if (strs[i].Split(':')[1] == "Truck")
                {
                    car = new Truck(strs[i].Split(':')[2]);
                }
                else if (strs[i].Split(':')[1] == "Benzovoz")
                {
                    car = new Benzovoz(strs[i].Split(':')[2]);
                }
                parkingStages[counter][counterCar++] = car;
            }
        }
        /// <summary>
        /// Сортировка уровней  
        /// </summary>
        public void Sort()
        {
            parkingStages.Sort();
        }
    }
}
