using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Beginning_of_Grain_Growth.src
{
    class Solver
    {
        private Display display;
        private Data data;
        private Random rnd;

        public Solver(Display display, Data data)
        {
            this.display = display;
            this.data = data;
            rnd = new Random();
        }

        public void Calculate()
        {
            display.Print_Grid();

            for(int k=0; k<data.Speed; k++)
            {
                int[,] next_level_Grid = new int[data.Horizontal_cells_num, data.Vertical_cells_num];

                for (int i = 0; i < data.Horizontal_cells_num; i++)
                {
                    for (int j = 0; j < data.Vertical_cells_num; j++)
                    {
                        int current_cell = data.Grid_values[i, j];
                        next_level_Grid[i, j] = current_cell;

                        if (current_cell != 0)
                        {
                            continue;
                        }

                        int value = 0;
                        if(data.Neighborhood == "Von Neumann")
                        {
                            value = VonNeumann(i, j);
                        }
                        if(data.Neighborhood == "Moore")
                        {
                            value = Moore(i, j);
                        }
                        if(data.Neighborhood == "Random Pentagonal")
                        {
                            value = RndPentagonal(i, j);
                        }
                        if(data.Neighborhood == "Left Hexagonal")
                        {
                            value = LeftHexagonal(i, j);
                        }
                        if (data.Neighborhood == "Right Hexagonal")
                        {
                            value = RightHexagonal(i, j);
                        }
                        if (data.Neighborhood == "Random Hexagonal")
                        {
                            value = RndHexagonal(i, j);
                        }
                        if (data.Neighborhood == "Radius")
                        {
                            value = Radius(i, j);
                        }

                        if (value != 0)
                        {
                            next_level_Grid[i, j] = value;
                            data.Cells[value]++;
                        }
                    }
                }

                data.Grid_values = next_level_Grid;
                display.Print_Grid();
            }
        }

        private int VonNeumann(int i, int j)
        {
            int[] neighbours = { 0, 0, 0, 0 };

            if (i > 0)
            {
                neighbours[0] = data.Grid_values[i - 1, j];
            }
            if (i < data.Grid_values.GetLength(0) - 1)
            {
                neighbours[1] = data.Grid_values[i + 1, j];
            }
            if (j > 0)
            {
                neighbours[2] = data.Grid_values[i, j - 1];
            }
            if (j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[3] = data.Grid_values[i, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[0] = data.Grid_values[data.Grid_values.GetLength(0) - 1, j];
                }
                if (i == data.Grid_values.GetLength(0) - 1)
                {
                    neighbours[1] = data.Grid_values[0, j];
                }
                if (j == 0)
                {
                    neighbours[2] = data.Grid_values[i, data.Grid_values.GetLength(1) - 1];
                }
                if (j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[3] = data.Grid_values[i, 0];
                }
            }

            return select_neighbour(neighbours);
        }

        private int Moore(int i, int j)
        {
            int[] neighbours = new int[8];

            if (i > 0)
            {
                neighbours[0] = data.Grid_values[i - 1, j];
            }
            if (i < data.Grid_values.GetLength(0) - 1)
            {
                neighbours[1] = data.Grid_values[i + 1, j];
            }
            if (j > 0)
            {
                neighbours[2] = data.Grid_values[i, j - 1];
            }
            if (j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[3] = data.Grid_values[i, j + 1];
            }
            if (i > 0 && j > 0)
            {
                neighbours[4] = data.Grid_values[i - 1, j - 1];
            }
            if (i < data.Grid_values.GetLength(0) - 1 && j > 0)
            {
                neighbours[5] = data.Grid_values[i + 1, j - 1];
            }
            if (i > 0 && j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[6] = data.Grid_values[i - 1, j + 1];
            }
            if (i < data.Grid_values.GetLength(0) - 1 && j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[7] = data.Grid_values[i + 1, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[0] = data.Grid_values[data.Grid_values.GetLength(0) - 1, j];
                }
                if (i == data.Grid_values.GetLength(0) - 1)
                {
                    neighbours[1] = data.Grid_values[0, j];
                }
                if (j == 0)
                {
                    neighbours[2] = data.Grid_values[i, data.Grid_values.GetLength(1) - 1];
                }
                if (j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[3] = data.Grid_values[i, 0];
                }

                if (i == 0 && j == 0)
                {
                    neighbours[4] = data.Grid_values[data.Grid_values.GetLength(0) - 1, data.Grid_values.GetLength(1) - 1];
                }
                if (i == data.Grid_values.GetLength(0) - 1 && j == 0)
                {
                    neighbours[5] = data.Grid_values[0, data.Grid_values.GetLength(1) - 1];
                }
                if (i == 0 && j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[6] = data.Grid_values[data.Grid_values.GetLength(0) - 1, 0];
                }
                if (i == data.Grid_values.GetLength(0) - 1 && j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[7] = data.Grid_values[data.Grid_values.GetLength(0) - 1, data.Grid_values.GetLength(1) - 1];
                }
            }

            return select_neighbour(neighbours);
        }

        private int RndPentagonal(int i, int j)
        {
            int[] neighbours = new int[8];
            int option = rnd.Next(1, 4);

            if (i > 0 && (option == 1 || option == 3 || option == 4))
            {
                neighbours[0] = data.Grid_values[i - 1, j];
            }
            if (i < data.Grid_values.GetLength(0) - 1 && (option == 2 || option == 3 || option == 4))
            {
                neighbours[1] = data.Grid_values[i + 1, j];
            }
            if (j > 0 && (option == 1 || option == 2 || option == 4))
            {
                neighbours[2] = data.Grid_values[i, j - 1];
            }
            if (j < data.Grid_values.GetLength(1) - 1 && (option == 1 || option == 2 || option == 3))
            {
                neighbours[3] = data.Grid_values[i, j + 1];
            }
            if (i > 0 && j > 0 && (option == 1 || option == 4))
            {
                neighbours[4] = data.Grid_values[i - 1, j - 1];
            }
            if (i < data.Grid_values.GetLength(0) - 1 && j > 0 && (option == 2 || option == 4))
            {
                neighbours[5] = data.Grid_values[i + 1, j - 1];
            }
            if (i > 0 && j < data.Grid_values.GetLength(1) - 1 && (option == 1 || option == 3))
            {
                neighbours[6] = data.Grid_values[i - 1, j + 1];
            }
            if (i < data.Grid_values.GetLength(0) - 1 && j < data.Grid_values.GetLength(1) - 1 && (option == 2 || option == 3))
            {
                neighbours[7] = data.Grid_values[i + 1, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0 && (option == 1 || option == 3 || option == 4))
                {
                    neighbours[0] = data.Grid_values[data.Grid_values.GetLength(0) - 1, j];
                }
                if (i == data.Grid_values.GetLength(0) - 1 && (option == 2 || option == 3 || option == 4))
                {
                    neighbours[1] = data.Grid_values[0, j];
                }
                if (j == 0 && (option == 1 || option == 2 || option == 4))
                {
                    neighbours[2] = data.Grid_values[i, data.Grid_values.GetLength(1) - 1];
                }
                if (j == data.Grid_values.GetLength(1) - 1 && (option == 1 || option == 2 || option == 3))
                {
                    neighbours[3] = data.Grid_values[i, 0];
                }

                if (i == 0 && j == 0 && (option == 1 || option == 4))
                {
                    neighbours[4] = data.Grid_values[data.Grid_values.GetLength(0) - 1, data.Grid_values.GetLength(1) - 1];
                }
                if (i == data.Grid_values.GetLength(0) - 1 && j == 0 && (option == 2 || option == 4))
                {
                    neighbours[5] = data.Grid_values[0, data.Grid_values.GetLength(1) - 1];
                }
                if (i == 0 && j == data.Grid_values.GetLength(1) - 1 && (option == 1 || option == 3))
                {
                    neighbours[6] = data.Grid_values[data.Grid_values.GetLength(0) - 1, 0];
                }
                if (i == data.Grid_values.GetLength(0) - 1 && j == data.Grid_values.GetLength(1) - 1 && (option == 2 || option == 3))
                {
                    neighbours[7] = data.Grid_values[data.Grid_values.GetLength(0) - 1, data.Grid_values.GetLength(1) - 1];
                }
            }

            return select_neighbour(neighbours);
        }

        private int LeftHexagonal(int i, int j)
        {
            int[] neighbours = new int[6];

            if (i > 0)
            {
                neighbours[0] = data.Grid_values[i - 1, j];
            }
            if (i < data.Grid_values.GetLength(0) - 1)
            {
                neighbours[1] = data.Grid_values[i + 1, j];
            }
            if (j > 0)
            {
                neighbours[2] = data.Grid_values[i, j - 1];
            }
            if (j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[3] = data.Grid_values[i, j + 1];
            }
            if (i < data.Grid_values.GetLength(0) - 1 && j > 0)
            {
                neighbours[4] = data.Grid_values[i + 1, j - 1];
            }
            if (i > 0 && j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[5] = data.Grid_values[i - 1, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[0] = data.Grid_values[data.Grid_values.GetLength(0) - 1, j];
                }
                if (i == data.Grid_values.GetLength(0) - 1)
                {
                    neighbours[1] = data.Grid_values[0, j];
                }
                if (j == 0)
                {
                    neighbours[2] = data.Grid_values[i, data.Grid_values.GetLength(1) - 1];
                }
                if (j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[3] = data.Grid_values[i, 0];
                }

                if (i == data.Grid_values.GetLength(0) - 1 && j == 0)
                {
                    neighbours[4] = data.Grid_values[0, data.Grid_values.GetLength(1) - 1];
                }
                if (i == 0 && j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[5] = data.Grid_values[data.Grid_values.GetLength(0) - 1, 0];
                }
            }

            return select_neighbour(neighbours);
        }

        private int RightHexagonal(int i, int j)
        {
            int[] neighbours = new int[8];

            if (i > 0)
            {
                neighbours[0] = data.Grid_values[i - 1, j];
            }
            if (i < data.Grid_values.GetLength(0) - 1)
            {
                neighbours[1] = data.Grid_values[i + 1, j];
            }
            if (j > 0)
            {
                neighbours[2] = data.Grid_values[i, j - 1];
            }
            if (j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[3] = data.Grid_values[i, j + 1];
            }
            if (i > 0 && j > 0)
            {
                neighbours[4] = data.Grid_values[i - 1, j - 1];
            }
            if (i < data.Grid_values.GetLength(0) - 1 && j < data.Grid_values.GetLength(1) - 1)
            {
                neighbours[7] = data.Grid_values[i + 1, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[0] = data.Grid_values[data.Grid_values.GetLength(0) - 1, j];
                }
                if (i == data.Grid_values.GetLength(0) - 1)
                {
                    neighbours[1] = data.Grid_values[0, j];
                }
                if (j == 0)
                {
                    neighbours[2] = data.Grid_values[i, data.Grid_values.GetLength(1) - 1];
                }
                if (j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[3] = data.Grid_values[i, 0];
                }

                if (i == 0 && j == 0)
                {
                    neighbours[4] = data.Grid_values[data.Grid_values.GetLength(0) - 1, data.Grid_values.GetLength(1) - 1];
                }
                if (i == data.Grid_values.GetLength(0) - 1 && j == data.Grid_values.GetLength(1) - 1)
                {
                    neighbours[7] = data.Grid_values[data.Grid_values.GetLength(0) - 1, data.Grid_values.GetLength(1) - 1];
                }
            }

            return select_neighbour(neighbours);
        }

        private int RndHexagonal(int i, int j)
        {
            int value = rnd.Next(2);

            if(value == 0)
            {
                return LeftHexagonal(i, j);
            }
            else
            {
                return RightHexagonal(i, j);
            }
        }

        private int Radius(int i, int j)
        {
            int[] neighbours = new int[(int)Math.Pow(2*data.Radius, 2)];

            int index = 0;
            for(int k=i-data.Radius; k < i+data.Radius; k++)
            {
                if (k < 0 || k > data.Grid_values.GetLength(0) - 1)
                {
                    continue;
                }

                for (int l=j-data.Radius; l < j+data.Radius; l++)
                {
                    if(l<0 || l > data.Grid_values.GetLength(1)-1)
                    {
                        continue;
                    }

                    double length = Math.Sqrt(Math.Pow(data.Grid_points[i, j].X-data.Grid_points[k, l].X, 2)+Math.Pow(data.Grid_points[i, j].Y-data.Grid_points[k, l].Y, 2));
                    if(length <= data.Radius*data.Cell_size)
                    {
                        neighbours[index] = data.Grid_values[k, l];
                        index++;
                    }
                }
            }

            return select_neighbour(neighbours);
        }

        private int select_neighbour(int[] neighbours)
        {
            int index = 0;
            for(int i=1; i<neighbours.Length; i++)
            {
                if(data.Cells[neighbours[i]] > data.Cells[neighbours[index]])
                {
                    index = i;
                }
            }

            return neighbours[index];
        }
    }
}
