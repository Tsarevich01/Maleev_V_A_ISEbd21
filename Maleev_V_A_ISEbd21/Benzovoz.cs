using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maleev_V_A_ISEbd21
{
    class Benzovoz
    {
        private const int carHeight = 150;
        private const int carWidth = 350;

        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки автомобиля
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;
        //Высота окна отрисовки
        private int _pictureHeight;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес автомобиля
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>

        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color MainColor { private set; get; }
        public Color DopColor { private set; get; }

        /// <summary>
        /// Конструктор
        /// </summary>

        public Benzovoz(int maxSpeed, float weight, Color mainColor, Color dopColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
        }

        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        public void MoveTransport(Direction direction)
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

        public void DrawTruck(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush s = new SolidBrush(DopColor);
            g.FillEllipse(s, _startPosX, _startPosY, 250, 100);
            g.FillRectangle(s, _startPosX + 215, _startPosY - 15, 20, 15);
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
