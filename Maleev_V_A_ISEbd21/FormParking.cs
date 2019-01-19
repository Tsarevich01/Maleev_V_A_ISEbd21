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
    public partial class FormParking : Form
    {
        MultiLevelParking parking;
        

        private const int countLevel = 5;
        public FormParking()
        {
            InitializeComponent();
            parking = new MultiLevelParking(countLevel, pictureBoxParking.Width,
pictureBoxParking.Height);
            Draw();
            for (int i = 0; i < countLevel; i++)
            {
                listBoxlevel.Items.Add("Уровень " + (i + 1));
            }
            listBoxlevel.SelectedIndex = 0;

        }
        
        private void Draw()
        {
            if (listBoxlevel.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBoxParking.Width,
pictureBoxParking.Height);
                Graphics gr = Graphics.FromImage(bmp);
                parking[listBoxlevel.SelectedIndex].Draw(gr);
                pictureBoxParking.Image = bmp;
            }
        }
               

        private void buttonBenzovoz_Click(object sender, EventArgs e)
        {
            if (listBoxlevel.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var car = new Benzovoz(100, 1000, dialog.Color, dialogDop.Color);
                        int place = parking[listBoxlevel.SelectedIndex] + car;
                        if (place == -1)
                        {
                            MessageBox.Show("Нет свободных мест", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Draw();
                    }
                }
            }
        }

        private void buttonTruck_Click(object sender, EventArgs e)
        {
            if (listBoxlevel.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var car = new Truck(100, 1000, dialog.Color);
                    int place = parking[listBoxlevel.SelectedIndex] + car;
                    if (place == -1)
                    {
                        MessageBox.Show("Нет свободных мест", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Draw();
                }
            }
        }

        private void buttonTake_Click(object sender, EventArgs e)
        {
            if (listBoxlevel.SelectedIndex > -1)
            {
                if (maskedTextBox.Text != "")
                {
                    var car = parking[listBoxlevel.SelectedIndex] -
                   Convert.ToInt32(maskedTextBox.Text);
                    if (car != null)
                    {
                        Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width,
                       pictureBoxTakeCar.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        car.SetPosition(5, 5, pictureBoxTakeCar.Width,
                       pictureBoxTakeCar.Height);
                        car.DrawTruck(gr);
                        pictureBoxTakeCar.Image = bmp;
                    }
                    else
                    {
                        Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width,
                       pictureBoxTakeCar.Height);
                        pictureBoxTakeCar.Image = bmp;
                    }
                    Draw();
                }

            }
        }
        private void listBoxlevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}

