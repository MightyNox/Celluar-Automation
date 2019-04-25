using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Celluar_Automation
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private int cell_size_value;
        private int rule_value;
        private int vertical_cells_num;
        private int horizontal_cells_num;
        bool[,] cells_status;

        public Form()
        {
            InitializeComponent();

            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);

            Set_Limits();
        }

        private void Set_Limits()
        {
            cell_numericUpDown.Minimum = 1;
            cell_numericUpDown.Maximum = 100;

            rule_numericUpDown.Minimum = 0;
            rule_numericUpDown.Maximum = 255;

            vertical_cells_numericUpDown.Minimum = 3;
            vertical_cells_numericUpDown.Maximum = pictureBox.Width / cell_size_value;

            horizontal_cells_numericUpDown.Minimum = 1;
            horizontal_cells_numericUpDown.Maximum = pictureBox.Height / cell_size_value;
        }

        private void Run_Rule()
        {
            //First row
            int middle_index = vertical_cells_num / 2;
            cells_status[0, middle_index] = true;

            int nextValue;
            int currentValue;
            int previousValue;
            int combination;
            int shift;
            for (int i = 1; i < horizontal_cells_num; i++)
            {
                for(int j = 0; j < vertical_cells_num; j++)
                {
                    if (j == 0)
                    {
                        nextValue = Convert.ToInt32(cells_status[i - 1, j + 1]);
                        currentValue = Convert.ToInt32(cells_status[i - 1, j]);
                        previousValue = Convert.ToInt32(cells_status[i - 1, vertical_cells_num - 1]);
                    }
                    else if (j == vertical_cells_num - 1)
                    {
                        nextValue = Convert.ToInt32(cells_status[i - 1, 0]);
                        currentValue = Convert.ToInt32(cells_status[i - 1, j]);
                        previousValue = Convert.ToInt32(cells_status[i - 1, j - 1]);
                    }
                    else
                    {
                        nextValue = Convert.ToInt32(cells_status[i - 1, j + 1]);
                        currentValue = Convert.ToInt32(cells_status[i - 1, j]);
                        previousValue = Convert.ToInt32(cells_status[i - 1, j - 1]);
                    }

                    combination = previousValue << 2 | currentValue << 1 | nextValue;
                    shift = 1 << combination;

                    if ( (rule_value & shift) != 0)
                    {
                        cells_status[i, j] = true;
                    }
                }
            }
        }

        private void Print_Grid()
        {
            Pen black_pen = new Pen(Color.Black);

            for (int i = 0; i < horizontal_cells_num + 1; i++)
            {
                graphics.DrawLine(black_pen, new Point(0, i * cell_size_value), new Point(vertical_cells_num*cell_size_value, i * cell_size_value));
            }

            for (int i = 0; i < vertical_cells_num + 1; i++)
            {
                graphics.DrawLine(black_pen, new Point(i * cell_size_value, 0), new Point(i * cell_size_value, horizontal_cells_num*cell_size_value));
            }
        }

        private void Print_Cells()
        {
            Brush red_brush = new SolidBrush(Color.Red);

            for (int i = 0; i < horizontal_cells_num; i++) 
            {
                for(int j = 0; j < vertical_cells_num; j++)
                {
                    if(cells_status[i, j])
                    {
                        Rectangle rectangle = new Rectangle(
                            j * cell_size_value, 
                            i * cell_size_value, 
                            cell_size_value,
                            cell_size_value
                        );

                        graphics.FillRectangle(red_brush, rectangle);
                    }
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);

            cells_status = new bool[horizontal_cells_num, vertical_cells_num];

            Run_Rule();

            Print_Cells();

            if(grid_checkbox.Checked)
            {
                Print_Grid();
            }

            pictureBox.Image = bitmap;
        }

        private void Cell_ValueChanged(object sender, EventArgs e)
        {
            cell_size_value = decimal.ToInt32(cell_numericUpDown.Value);
            Set_Limits();
            horizontal_cells_numericUpDown.Value = horizontal_cells_numericUpDown.Minimum;
            vertical_cells_numericUpDown.Value = vertical_cells_numericUpDown.Minimum;
        }

        private void Rule_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rule_value = decimal.ToInt32(rule_numericUpDown.Value);
        }

        private void horizontal_cells_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            horizontal_cells_num = decimal.ToInt32(horizontal_cells_numericUpDown.Value);
        }

        private void vertical_cells_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            vertical_cells_num = decimal.ToInt32(vertical_cells_numericUpDown.Value);
        }
    }
}
