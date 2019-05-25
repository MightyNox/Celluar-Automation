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

            if(data.Colors == null)
            {
                return;
            }

            try
            {
                value = data.Grid_values[i, j];
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }

            if (value == 0)
            {
                data.Grid_values[i, j] = ++data.Current_index;
                data.Add_new_color();
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
                data.Add_new_color();
                data.Grid_values[rnd.Next(0, data.Horizontal_cells_num), rnd.Next(0, data.Vertical_cells_num)] = ++data.Current_index;
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
                    data.Add_new_color();
                    data.Grid_values[i * horizontal_space, j * vertical_space] = ++data.Current_index;
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
                        data.Add_new_color();
                        data.Grid_values[x, y] = ++data.Current_index;
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
                        if (data.Grid_values[i, j] != 0)
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
