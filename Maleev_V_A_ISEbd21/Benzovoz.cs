using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maleev_V_A_ISEbd21
{
    public class Benzovoz : Truck
    {
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }

        /// <summary>
        /// Конструктор
        /// </summary>

        public Benzovoz(int maxSpeed, float weight, Color mainColor, Color dopColor) :
        base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
        }
        public override void DrawTruck(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush s = new SolidBrush(DopColor);
            g.FillEllipse(s, _startPosX, _startPosY, 250, 100);
            g.FillRectangle(s, _startPosX + 215, _startPosY - 15, 20, 15);
            base.DrawTruck(g);
        }
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }
    }
}
