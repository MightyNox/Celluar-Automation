using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Game_of_Life
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private int vertical_cells_num;
        private int horizontal_cells_num;
        private int cell_size_value;
        private int speed_value;
        private bool[,] cells_status;
        private string pattern;

        public Form()
        {
            InitializeComponent();

            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);

            Set_Elements();
            Init_data();
        }

        private void Init_data()
        {
            horizontal_cells_num = pictureBox.Height / cell_size_value;
            vertical_cells_num = pictureBox.Width / cell_size_value;

            cells_status = new bool[horizontal_cells_num, vertical_cells_num];

            Match_Pattern();

            Print();
        }

        private void Match_Pattern()
        {
            switch (pattern)
            {
                case "Empty":
                    {
                        break;
                    }
                case "Block":
                    {
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        break;
                    }
                case "Bee-hive":
                    {
                        cells_status[horizontal_cells_num / 2 - 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;

                        break;
                    }
                case "Loaf":
                    {
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 2] = true;

                        break;
                    }
                case "Boat":
                    {
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;

                        break;
                    }
                case "Tub":
                    {
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;

                        break;
                    }
                case "Blinker":
                    {
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;
                        break;
                    }
                case "Toad":
                    {
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 1] = true;
                        break;
                    }
                case "Beacon":
                    {
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 - 2] = true;
                        cells_status[horizontal_cells_num / 2 - 2, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2 - 2, vertical_cells_num / 2 - 2] = true;

                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 1] = true;
                        break;
                    }
                case "Pulsar":
                    {
                        if (cell_size_value > 20)
                        {
                            cell_numericUpDown.Value = 20;
                        }


                        for(int i=0; i<=4; i++)
                        {
                            int x = 1;
                            int y = 1;

                            if(i==0)
                            {
                                x = -1;
                                y = -1;
                            }
                            else if(i==1)
                            {
                                x = 1;
                                y = -1;
                            }
                            else if(i ==2)
                            {
                                x = -1;
                                y = 1;
                            }
                            else
                            {
                                x = 1;
                                y = 1;
                            }

                            cells_status[horizontal_cells_num / 2 + x * 2, vertical_cells_num / 2 + y * 1] = true;
                            cells_status[horizontal_cells_num / 2 + x * 3, vertical_cells_num / 2 + y * 1] = true;
                            cells_status[horizontal_cells_num / 2 + x * 4, vertical_cells_num / 2 + y * 1] = true;

                            cells_status[horizontal_cells_num / 2 + x * 1, vertical_cells_num / 2 + y * 2] = true;
                            cells_status[horizontal_cells_num / 2 + x * 1, vertical_cells_num / 2 + y * 3] = true;
                            cells_status[horizontal_cells_num / 2 + x * 1, vertical_cells_num / 2 + y * 4] = true;

                            cells_status[horizontal_cells_num / 2 + x * 6, vertical_cells_num / 2 + y * 2] = true;
                            cells_status[horizontal_cells_num / 2 + x * 6, vertical_cells_num / 2 + y * 3] = true;
                            cells_status[horizontal_cells_num / 2 + x * 6, vertical_cells_num / 2 + y * 4] = true;

                            cells_status[horizontal_cells_num / 2 + x * 2, vertical_cells_num / 2 + y * 6] = true;
                            cells_status[horizontal_cells_num / 2 + x * 3, vertical_cells_num / 2 + y * 6] = true;
                            cells_status[horizontal_cells_num / 2 + x * 4, vertical_cells_num / 2 + y * 6] = true;
                        }

                        break;
                    }
                case "Glider":
                    {
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 1] = true;

                        break;
                    }
                case "Light-weight spaceship":
                    {
                        if (cell_size_value > 30)
                        {
                            cell_numericUpDown.Value = 30;
                        }

                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2] = true;

                        break;
                    }
                case "Middle-weight spaceship":
                    {
                        if (cell_size_value > 30)
                        {
                            cell_numericUpDown.Value = 30;
                        }

                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 3] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 3] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2 + 2] = true;

                        break;
                    }
                case "Heavy-weight spaceship":
                    {
                        if (cell_size_value > 30)
                        {
                            cell_numericUpDown.Value = 30;
                        }

                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 3] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 4] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 3] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 4] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2 + 2] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2 + 3] = true;

                        break;
                    }
                case "Gosper glider gun":
                    {
                        if(cell_size_value > 10)
                        {
                            cell_numericUpDown.Value = 10;
                        }

                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 9] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 10] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 9] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 10] = true;

                        cells_status[horizontal_cells_num / 2 - 3, vertical_cells_num / 2 + 3] = true;
                        cells_status[horizontal_cells_num / 2 - 3, vertical_cells_num / 2 + 2] = true;
                        cells_status[horizontal_cells_num / 2 - 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2 + 3, vertical_cells_num / 2 + 3] = true;
                        cells_status[horizontal_cells_num / 2 + 3, vertical_cells_num / 2 + 2] = true;

                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 4] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 7] = true;

                        cells_status[horizontal_cells_num / 2 - 2, vertical_cells_num / 2 + 5] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 + 6] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 6] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 6] = true;
                        cells_status[horizontal_cells_num / 2 + 2, vertical_cells_num / 2 + 5] = true;

                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 14] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 14] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 12] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 + 10] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 + 11] = true;
                        cells_status[horizontal_cells_num / 2 - 2, vertical_cells_num / 2 + 10] = true;
                        cells_status[horizontal_cells_num / 2 - 2, vertical_cells_num / 2 + 11] = true;
                        cells_status[horizontal_cells_num / 2 - 3, vertical_cells_num / 2 + 10] = true;
                        cells_status[horizontal_cells_num / 2 - 3, vertical_cells_num / 2 + 11] = true;
                        cells_status[horizontal_cells_num / 2 - 4, vertical_cells_num / 2 + 12] = true;
                        cells_status[horizontal_cells_num / 2 - 4, vertical_cells_num / 2 + 14] = true;
                        cells_status[horizontal_cells_num / 2 - 5, vertical_cells_num / 2 + 14] = true;

                        cells_status[horizontal_cells_num / 2 - 3, vertical_cells_num / 2 + 24] = true;
                        cells_status[horizontal_cells_num / 2 - 3, vertical_cells_num / 2 + 25] = true;
                        cells_status[horizontal_cells_num / 2 - 2, vertical_cells_num / 2 + 24] = true;
                        cells_status[horizontal_cells_num / 2 - 2, vertical_cells_num / 2 + 25] = true;

                        break;
                    }
                case "Penta-decathlon":
                    {
                        if (cell_size_value > 30)
                        {
                            cell_numericUpDown.Value = 30;
                        }

                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 4] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 3] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 - 2] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 - 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 - 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 1] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 2] = true;
                        cells_status[horizontal_cells_num / 2 - 1, vertical_cells_num / 2 + 3] = true;
                        cells_status[horizontal_cells_num / 2 + 1, vertical_cells_num / 2 + 3] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 4] = true;
                        cells_status[horizontal_cells_num / 2, vertical_cells_num / 2 + 5] = true;
                        break;
                    }
                case "Random":
                    {
                        Random rand = new Random();
                        for(int i=0; i<horizontal_cells_num; i++)
                        {
                            for(int j=0; j<vertical_cells_num; j++)
                            {
                                cells_status[i, j] = rand.NextDouble() >= 0.5;
                            }
                        }

                        break;
                    }
            }
        }

        private void Set_Elements()
        {
            cell_numericUpDown.Minimum = 2;
            cell_numericUpDown.Maximum = 50;
            cell_numericUpDown.Value = 50;

            speed_numericUpDown.Minimum = 1;
            speed_numericUpDown.Maximum = 10;
            speed_numericUpDown.Value = 10;

            pattern_comboBox.Items.Add("Empty");

            //Still lifes
            pattern_comboBox.Items.Add("Block");
            pattern_comboBox.Items.Add("Bee-hive");
            pattern_comboBox.Items.Add("Loaf");
            pattern_comboBox.Items.Add("Boat");
            pattern_comboBox.Items.Add("Tub");

            //Oscilators
            pattern_comboBox.Items.Add("Blinker");
            pattern_comboBox.Items.Add("Toad");
            pattern_comboBox.Items.Add("Beacon");
            pattern_comboBox.Items.Add("Pulsar");
            pattern_comboBox.Items.Add("Penta-decathlon");

            //Spaceships
            pattern_comboBox.Items.Add("Glider");
            pattern_comboBox.Items.Add("Light-weight spaceship");
            pattern_comboBox.Items.Add("Middle-weight spaceship");
            pattern_comboBox.Items.Add("Heavy-weight spaceship");

            pattern_comboBox.Items.Add("Gosper glider gun");

            pattern_comboBox.Items.Add("Random");
        }

        private void Start_Game()
        {
            while(run_game_box.Checked)
            {
                
                Check_conditions();
                Print();
                Thread.Sleep(speed_value * 100);
            }
        }

        private void Check_conditions()
        {
            bool[,] next_level_cells_status = new bool[horizontal_cells_num, vertical_cells_num];

            for (int i=0; i< horizontal_cells_num; i++)
            {
                for(int j=0; j<vertical_cells_num; j++)
                {
                    int cell_neighbours_count = Count_Neighbours(i, j);
                    bool is_cell_alive = cells_status[i, j];

                    if(is_cell_alive)
                    {
                        //Cell becomes a dead cell
                        if(cell_neighbours_count < 2)
                        {
                            next_level_cells_status[i, j] = false;
                        }
                        else if(cell_neighbours_count > 3)
                        {
                            next_level_cells_status[i, j] = false;
                        }
                        else
                        {
                            next_level_cells_status[i, j] = true;
                        }
                    }
                    else
                    {
                        //Cell becomes a live cell
                        if (cell_neighbours_count == 3)
                        {
                            next_level_cells_status[i, j] = true;
                        }
                        else
                        {
                            next_level_cells_status[i, j] = false;
                        }
                    }
                }
            }

            cells_status = next_level_cells_status;
        }

        private int Count_Neighbours(int x, int y)
        {
            int count = 0;

            for (int i=x-1; i<=x+1; i++)
            {
                for(int j=y-1; j<=y+1; j++)
                {
                    if(i==x && j == y)
                    {
                        continue;
                    }

                    int index_x = i;
                    int index_y = j;

                    if(i == -1)
                    {
                        index_x = horizontal_cells_num - 1;
                    }
                    else if(i == horizontal_cells_num)
                    {
                        index_x = 0;
                    }

                    if(j == -1)
                    {
                        index_y = vertical_cells_num - 1;
                    }
                    else if(j == vertical_cells_num)
                    {
                        index_y = 0;
                    }

                    if(cells_status[index_x, index_y])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void Print()
        {
            lock (graphics)
            {
                graphics.Clear(Color.White);
                Print_Cells();
                Print_Grid();
            }
        }

        private void Print_Grid()
        {
            Pen black_pen = new Pen(Color.Black);

            for (int i = 0; i < horizontal_cells_num + 1; i++)
            {
                graphics.DrawLine(black_pen, new Point(0, i * cell_size_value), new Point(vertical_cells_num * cell_size_value, i * cell_size_value));
            }

            for (int i = 0; i < vertical_cells_num + 1; i++)
            {
                graphics.DrawLine(black_pen, new Point(i * cell_size_value, 0), new Point(i * cell_size_value, horizontal_cells_num * cell_size_value));
            }

            pictureBox.Image = bitmap;
        }

        private void Print_Cells()
        {
            Brush red_brush = new SolidBrush(Color.Red);

            for (int i = 0; i < horizontal_cells_num; i++)
            {
                for (int j = 0; j < vertical_cells_num; j++)
                {
                    if (cells_status[i, j])
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

        private void Cell_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            run_game_box.Checked = false;
            cell_size_value = decimal.ToInt32(cell_numericUpDown.Value);
            Init_data();
        }

        private void Speed_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            speed_value = decimal.ToInt32(speed_numericUpDown.Value);
        }

        private void Run_game_box_CheckedChanged(object sender, EventArgs e)
        {
            if (run_game_box.Checked)
            {
                Thread thr = new Thread(Start_Game);
                thr.IsBackground = true;
                thr.Start();
            }
        }

        private void Pattern_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            run_game_box.Checked = false;
            pattern = pattern_comboBox.SelectedItem.ToString();
            Init_data();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            int i = coordinates.Y / cell_size_value;
            int j = coordinates.X / cell_size_value;

            bool status = cells_status[i, j];

            if(status)
            {
                cells_status[i, j] = false;
            }
            else
            {
                cells_status[i, j] = true;
            }

            Print();
        }
    }
}
