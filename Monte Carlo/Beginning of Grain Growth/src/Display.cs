using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Beginning_of_Grain_Growth.src
{
    class Display
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private PictureBox pictureBox;
        private Data data;

        public Display(PictureBox pictureBox, Data data)
        {
            this.pictureBox = pictureBox;
            this.data = data;

            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
        }

        public void Print_Grid()
        {
            Clear();

            for (int i = 0; i < data.Horizontal_cells_num; i++)
            {
                for (int j = 0; j < data.Vertical_cells_num; j++)
                {
                    Rectangle rectangle = new Rectangle(
                        j * data.Cell_size,
                        i * data.Cell_size,
                        data.Cell_size,
                        data.Cell_size
                    );

                    graphics.FillRectangle(data.Colors[data.Grid_values[i, j]], rectangle);
                }
            }

            pictureBox.Image = bitmap;
        }

        public void Print_Energry()
        {
            Clear();

            for (int i = 0; i < data.Horizontal_cells_num; i++)
            {
                for (int j = 0; j < data.Vertical_cells_num; j++)
                {
                    Rectangle rectangle = new Rectangle(
                        j * data.Cell_size,
                        i * data.Cell_size,
                        data.Cell_size,
                        data.Cell_size
                    );

                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(255/data.Energy_max * data.Grid_energy[i, j], 0 ,0)), rectangle);
                }
            }

            pictureBox.Image = bitmap;
        }

        public void Clear()
        {
            graphics.Clear(Color.White);
            pictureBox.Image = bitmap;
        }
    }
}
