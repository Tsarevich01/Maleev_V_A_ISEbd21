using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maleev_V_A_ISEbd21
{
    public class Benzovoz : Truck, IComparable<Benzovoz>, IEquatable<Benzovoz>
    {
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        private int _countLines;
        public int CountLines
        {
            set { if (value > 0 && value < 4) _countLines = value; }
            get { return _countLines; }
        }
        public Benzovoz(int maxSpeed, float weight, Color mainColor, Color dopColor) :
        base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Random rnd = new Random();
            CountLines = rnd.Next(1, 4);
        }


        public Benzovoz(string info) : base(info)
 {
            string[] strs = info.Split(';');
            if (strs.Length == 4)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);                
            }
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
        }        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name;
        }        public int CompareTo(Benzovoz other)
        {
            var res = (this is Truck).CompareTo(other is Truck);
            if (res != 0)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                DopColor.Name.CompareTo(other.DopColor.Name);
            }
            
            if (CountLines != other.CountLines)
            {
                return CountLines.CompareTo(other.CountLines);
            }
            return 0;
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Benzovoz other)
        {
            var res = (this as Truck).Equals(other as Truck);
            if (!res)
            {
                return res;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (DopColor != other.DopColor)
            {
                return false;
            }
            
            
            if (CountLines != other.CountLines)
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
            Benzovoz carObj = obj as Benzovoz;
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
