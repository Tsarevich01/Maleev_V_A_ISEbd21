using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maleev_V_A_ISEbd21
{
    public class Truck : Vehicle, IComparable<Truck>, IEquatable<Truck>
    {
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        protected const int carWidth = 350;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        protected const int carHeight = 150;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public Truck(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }


        public Truck(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public override void DrawTruck(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush sgr = new SolidBrush(MainColor);
            g.FillRectangle(sgr, _startPosX + 200, _startPosY, 50, 100);
            g.FillRectangle(sgr, _startPosX + 250, _startPosY + 60, 70, 40);
            g.FillRectangle(sgr, _startPosX, _startPosY + 70, 250, 30);
            Brush sgb = new SolidBrush(Color.Black);
            g.FillEllipse(sgb, _startPosX + 25, _startPosY + 95, 50, 50);
            g.FillEllipse(sgb, _startPosX + 80, _startPosY + 95, 50, 50);
            g.FillEllipse(sgb, _startPosX + 250, _startPosY + 95, 50, 50);
            g.FillRectangle(sgb, _startPosX + 205, _startPosY + 45, 40, 50);
            g.FillRectangle(sgb, _startPosX + 315, _startPosY + 85, 20, 15);
            g.FillRectangle(sgb, _startPosX - 15, _startPosY + 85, 20, 15);
            Brush sgred = new SolidBrush(Color.Yellow);
            g.FillRectangle(sgred, _startPosX + 300, _startPosY + 60, 20, 15);
            Brush sgye = new SolidBrush(Color.Red);
            g.FillRectangle(sgye, _startPosX, _startPosY + 70, 20, 15);
        }
        public override string ToString()
        {
            return MaxSpeed + ";" + Weight + ";" + MainColor.Name;
        }        public int CompareTo(Truck other)
        {
            if (other == null)
            {
                return 1;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return MaxSpeed.CompareTo(other.MaxSpeed);
            }
            if (Weight != other.Weight)
            {
                return Weight.CompareTo(other.Weight);
            }
            if (MainColor != other.MainColor)
            {
                MainColor.Name.CompareTo(other.MainColor.Name);
            }
            return 0;
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса Car
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Truck other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Truck carObj = obj as Truck;
            if (carObj == null)
            {
                return false;
            }
            else
            {
                return Equals(carObj);
            }
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
