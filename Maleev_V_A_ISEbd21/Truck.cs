using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maleev_V_A_ISEbd21
{
    public class Truck : Vehicle
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
    }
}
