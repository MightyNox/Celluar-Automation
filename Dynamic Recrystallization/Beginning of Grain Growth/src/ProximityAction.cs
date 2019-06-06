using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginning_of_Grain_Growth.src
{
    class ProximityAction
    {
        private Data data;
        private Solver solver;

        public ProximityAction(Data data, Solver solver)
        {
            this.data = data;
            this.solver = solver;
        }

        public void CustomProximityClick(Point coordinates, Display display)
        {
            int i = coordinates.Y / data.Cell_size;
            int j = coordinates.X / data.Cell_size;
            int value;

            try
            {
                value = data.Cells[i, j].Value;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }

            if (value == 0)
            {
                data.Cells[i, j].Value = ++data.Current_index;
                data.Cells[i, j].set_unique_color();
                data.Cells_quantity.Add(1);
            }

            display.Print_Grid();
        }

        public void CustomProximity()
        {
            if (data.Current_index > 0)
            {
                solver.Calculate();
            }
        }

        public void RandomProximity()
        {
            data.Initialize();
            Random rnd = new Random();

            for (int i = 0; i < data.Rnd_cells_num; i++)
            {
                int x = rnd.Next(0, data.Horizontal_cells_num);
                int y = rnd.Next(0, data.Vertical_cells_num);

                data.Cells[x, y].Value = ++data.Current_index;
                data.Cells[x, y].set_unique_color();
                data.Cells_quantity.Add(1);
            }

            solver.Calculate();
        }

        public void HomogenousProximity()
        {
            data.Initialize();

            int horizontal_space = data.Horizontal_cells_num / data.Horiziontal_homogenous_cells_num;
            int vertical_space = data.Vertical_cells_num / data.Vertical_homogenous_cells_num;

            for (int i = 0; i < data.Horiziontal_homogenous_cells_num; i++)
            {
                for (int j = 0; j < data.Vertical_homogenous_cells_num; j++)
                {
                    data.Cells[i * horizontal_space, j * vertical_space].Value = ++data.Current_index;
                    data.Cells[i * horizontal_space, j * vertical_space].set_unique_color();
                    data.Cells_quantity.Add(1);
                }
            }

            if (data.Current_index > 1)
            {
                solver.Calculate();
            }
        }

        public void RadiusProximity()
        {
            data.Initialize();
            Random rnd = new Random();

            int LIMIT = 20;

            for (int i = 0; i < data.Radius_cells_num; i++)
            {
                bool generated = false;
                int iteration = 0;
                while (!generated && iteration < LIMIT)
                {
                    iteration++;

                    int x = rnd.Next(0, data.Horizontal_cells_num);
                    int y = rnd.Next(0, data.Vertical_cells_num);

                    if (check_radius(x, y))
                    {
                        data.Cells[x, y].Value = ++data.Current_index;
                        data.Cells[x, y].set_unique_color();
                        data.Cells_quantity.Add(1);
                        generated = true;
                    }
                }
            }

            if (data.Current_index > 1)
            {
                solver.Calculate();
            }
        }

        private bool check_radius(int x, int y)
        {
            for (int i = x - data.Radius; i <= x + data.Radius; ++i)
            {
                for (int j = y - data.Radius; j <= y + data.Radius; ++j)
                {
                    try
                    {
                        if (data.Cells[i, j].Value != 0)
                            return false;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        continue;
                    }
                }
            }

            return true;
        }
    }
}
