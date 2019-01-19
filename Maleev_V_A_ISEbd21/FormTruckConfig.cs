using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maleev_V_A_ISEbd21
{
    public partial class FormTruckConfig : Form
    {
        Itest car = null;

        private event carDelegate eventAddCar;



        public FormTruckConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelGold.MouseDown += panelColor_MouseDown;
            panelGray.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        private void LabelTruck_MouseDown(object sender, MouseEventArgs e)
        {

            labelCar.DoDragDrop(labelCar.Text, DragDropEffects.Move |
           DragDropEffects.Copy);

        }
        private void DrawTruck()
        {
            if (car != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxCar.Width, pictureBoxCar.Height);
                Graphics gr = Graphics.FromImage(bmp);
                car.SetPosition(5, 5, pictureBoxCar.Width, pictureBoxCar.Height);
                car.DrawTruck(gr);
                pictureBoxCar.Image = bmp;
            }
        }

        public void AddEvent(carDelegate ev)
        {
            if (eventAddCar == null)
            {
                eventAddCar = new carDelegate(ev);
            }
            else
            {
                eventAddCar += ev;
            }
        }


        private void labelbenzovoz_MouseDown(object sender, MouseEventArgs e)
        {
            labelBenzovoz.DoDragDrop(labelBenzovoz.Text, DragDropEffects.Move |
           DragDropEffects.Copy);
        }
        
        private void panelCar_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        
        private void panelCar_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Грузовик":
                    car = new Truck(100, 500, Color.White);
                    break;
                case "Бензовоз":
                    car = new Benzovoz(100, 500, Color.White, Color.Black);
                    break;
            }
            DrawTruck();
        }

        private void labelMainColor_DragDrop(object sender, DragEventArgs e)
        {
            if (car != null)
            {
                car.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawTruck();
            }
        }

        private void labelMainColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor,
                DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelColorDop_DragDrop(object sender, DragEventArgs e)
        {
            if (car != null)
            {
                if (car is Benzovoz)
                {
                    (car as Benzovoz).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawTruck();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddCar?.Invoke(car);
            Close();
        }

        
    }
}
