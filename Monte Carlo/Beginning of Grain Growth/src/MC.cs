using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginning_of_Grain_Growth.src
{
    class MC
    {
        private Display display;
        private Data data;
        private Random rnd;
        private List<Point> rnd_points;
        //private int[,] next_level_Grid;
        //private int[,] next_level_Energy;

        public MC(Display display, Data data)
        {
            this.display = display;
            this.data = data;
            rnd = new Random();
        }

        public void Next_step()
        {
            if (data.Grid_values == null)
                return;

            for(int i=0; i<data.Horizontal_cells_num; i++)
            {
                for(int j=0; j<data.Vertical_cells_num; j++)
                {
                    if (data.Grid_values[i, j] == 0)
                        return;
                }
            }

            Calculate();
        }

        private void Calculate()
        {
            for (int k = 0; k < data.Speed; k++)
            {
                rnd_order();

                for (int i=0; i<rnd_points.Count; i++)
                {
                    int current_cell = data.Grid_values[rnd_points[i].X, rnd_points[i].Y];


                    if (data.Neighborhood == "Von Neumann")
                    {
                        data.Energy_max = 4;
                        VonNeumann(rnd_points[i].X, rnd_points[i].Y);
                    }
                    if (data.Neighborhood == "Moore")
                    {
                        data.Energy_max = 8;
                        Moore(rnd_points[i].X, rnd_points[i].Y);
                    }
                }

                if (!data.Show_energy)
                    display.Print_Grid();
                else
                    display.Print_Energry();
            }
        }

        private void VonNeumann(int i, int j)
        {
            Point[] neighbours = {new Point(-1, -1), new Point(-1, -1), new Point(-1, -1), new Point(-1, -1) };

            if (i > 0)
            {
                neighbours[0] = new Point(i-1, j);
            }
            if (i < data.Grid_values.GetLength(0) - 1)
            {
                neighbours[1] = new Point(i+1, j);
            }
            if (j > 0)
            {
                neighbours[2] = new Point(i, j - 1);
            }
            if (j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[3] = new Point(i, j + 1);
            }

            if (data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[0] = new Point(data.Grid_values.GetLength(0) - 1, j);
                }
                if (i == data.Grid_values.GetLength(0) - 1)
                {
                    neighbours[1] = new Point(0, j);
                }
                if (j == 0)
                {
                    neighbours[2] = new Point(i, data.Grid_values.GetLength(1) - 1);
                }
                if (j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[3] = new Point(i, 0);
                }
            }

            select_neighbour(neighbours, new Point(i, j));
        }

        private void Moore(int i, int j)
        {
            Point[] neighbours = new Point[8];
            for (int k=0; k<8; k++)
            {
                neighbours[k] = new Point(-1, -1);
            }

            if (i > 0)
            {
                neighbours[0] = new Point(i - 1, j);
            }
            if (i < data.Grid_values.GetLength(0) - 1)
            {
                neighbours[1] = new Point(i + 1, j);
            }
            if (j > 0)
            {
                neighbours[2] = new Point(i, j - 1);
            }
            if (j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[3] = new Point(i, j + 1);
            }

            if (i > 0 && j > 0)
            {
                neighbours[4] = new Point(i - 1, j - 1);
            }
            if (i < data.Grid_values.GetLength(0) - 1 && j > 0)
            {
                neighbours[5] = new Point(i + 1, j - 1);
            }
            if (i > 0 && j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[6] = new Point(i - 1, j + 1);
            }
            if (i < data.Grid_values.GetLength(0) - 1 && j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[7] = new Point(i + 1, j + 1);
            }

            if(data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[4] = new Point(data.Grid_values.GetLength(0) - 1, j - 1);
                    neighbours[0] = new Point(data.Grid_values.GetLength(0) - 1, j);
                    neighbours[6] = new Point(data.Grid_values.GetLength(0) - 1, j + 1);
                }
                if (i == data.Grid_values.GetLength(0) - 1)
                {
                    neighbours[5] = new Point(0, j - 1);
                    neighbours[1] = new Point(0, j);
                    neighbours[7] = new Point(0, j + 1);
                }
                if (j == 0)
                {
                    neighbours[4] = new Point(i - 1, data.Grid_values.GetLength(1) - 1);
                    neighbours[2] = new Point(i, data.Grid_values.GetLength(1) - 1);
                    neighbours[5] = new Point(i + 1, data.Grid_values.GetLength(1) - 1);
                }
                if (j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[6] = new Point(i - 1,0);
                    neighbours[3] = new Point(i, 0);
                    neighbours[7] = new Point(i + 1, 0);
                }

                if (i == 0 && j == 0)
                {
                    neighbours[4] = new Point(data.Grid_values.GetLength(0) - 1, data.Grid_values.GetLength(1) - 1);
                }
                if (i == data.Grid_values.GetLength(0) - 1 && j == 0)
                {
                    neighbours[5] = new Point(0, data.Grid_values.GetLength(1) - 1);
                }
                if (i == 0 && j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[6] = new Point(data.Grid_values.GetLength(0) - 1, 0);
                }
                if (i == data.Grid_values.GetLength(0) - 1 && j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[7] = new Point(0, 0);
                }
            }

            select_neighbour(neighbours, new Point(i, j));
        }

        private void select_neighbour(Point[] neighbours, Point current)
        {
            int index;
            if(data.Is_periodic)
            {
                index = rnd.Next(neighbours.Length);
            }
            else
            {
                do
                {
                    index = rnd.Next(neighbours.Length);
                } while (neighbours[index].X == -1 || neighbours[index].Y == -1);
            }

            int current_value = data.Grid_values[current.X, current.Y];
            int neighbour_value = data.Grid_values[neighbours[index].X, neighbours[index].Y];

            int energry_before = count_energy(neighbours, current_value);
            int energy_after = count_energy(neighbours, neighbour_value);
            int energy_diff = energy_after - energry_before;
            data.Grid_energy[current.X, current.Y] = energry_before;
            if (energy_diff <= 0 )
            {
                data.Grid_values[current.X, current.Y] = neighbour_value;
                data.Grid_energy[current.X, current.Y] = energy_after;
            }
            else
            {
                double value = rnd.NextDouble();
                if(Math.Exp(-1*energy_diff/data.Kt) < value)
                {
                    data.Grid_values[current.X, current.Y] = neighbour_value;
                    data.Grid_energy[current.X, current.Y] = energy_after;
                }
            }

        }

        private int count_energy(Point[] neighbours, int value)
        {
            int energy = 0;
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (neighbours[i].X == -1 || neighbours[i].Y == -1)
                    continue;

                if (value != data.Grid_values[neighbours[i].X, neighbours[i].Y])
                    energy++;
            }

            return energy;
        }

        private void rnd_order()
        {
            rnd_points = new List<Point>();

            for (int i = 0; i < data.Horizontal_cells_num; i++)
            {
                for (int j = 0; j < data.Vertical_cells_num; j++)
                {
                    Point point;
                    do
                    {
                        int horizontal_index = rnd.Next(data.Horizontal_cells_num);
                        int vertical_index = rnd.Next(data.Vertical_cells_num);
                        point = new Point(horizontal_index, vertical_index);
                    } while (rnd_points.Contains(point));

                    rnd_points.Add(point);
                }
            }
        }
    }
}
