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
                Cell[,] next_level_Grid = new Cell[data.Horizontal_cells_num, data.Vertical_cells_num];

                for (int i = 0; i < data.Horizontal_cells_num; i++)
                {
                    for (int j = 0; j < data.Vertical_cells_num; j++)
                    {
                        next_level_Grid[i, j] = data.Cells[i, j];

                        if (next_level_Grid[i, j].Value != 0)
                        {
                            continue;
                        }

                        Cell cell = null;
                        if(data.Neighborhood == "Von Neumann")
                        {
                            cell = VonNeumann(i, j);
                        }
                        if(data.Neighborhood == "Moore")
                        {
                            cell = Moore(i, j);
                        }
                        if(data.Neighborhood == "Random Pentagonal")
                        {
                            cell = RndPentagonal(i, j);
                        }
                        if(data.Neighborhood == "Left Hexagonal")
                        {
                            cell = LeftHexagonal(i, j);
                        }
                        if (data.Neighborhood == "Right Hexagonal")
                        {
                            cell = RightHexagonal(i, j);
                        }
                        if (data.Neighborhood == "Random Hexagonal")
                        {
                            cell = RndHexagonal(i, j);
                        }
                        if (data.Neighborhood == "Radius")
                        {
                            cell = Radius(i, j);
                        }

                        if (cell != null && cell.Value != 0)
                        {
                            next_level_Grid[i, j] = cell;
                            data.Cells_quantity[cell.Value]++;
                        }
                    }
                }

                data.Cells = next_level_Grid;
                display.Print_Grid();
            }
        }

        private Cell VonNeumann(int i, int j)
        {
            Cell[] neighbours = new Cell[4];
            for(int z =0; z<4; z++)
            {
                neighbours[z] = new Cell();
            }

            if (i > 0)
            {
                neighbours[0] = data.Cells[i - 1, j];
            }
            if (i < data.Cells.GetLength(0) - 1)
            {
                neighbours[1] = data.Cells[i + 1, j];
            }
            if (j > 0)
            {
                neighbours[2] = data.Cells[i, j - 1];
            }
            if (j < data.Cells.GetLength(1) - 1)
            {
                neighbours[3] = data.Cells[i, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[0] = data.Cells[data.Cells.GetLength(0) - 1, j];
                }
                if (i == data.Cells.GetLength(0) - 1)
                {
                    neighbours[1] = data.Cells[0, j];
                }
                if (j == 0)
                {
                    neighbours[2] = data.Cells[i, data.Cells.GetLength(1) - 1];
                }
                if (j == data.Cells.GetLength(1) - 1)
                {
                    neighbours[3] = data.Cells[i, 0];
                }
            }

            return select_neighbour(neighbours);
        }

        private Cell Moore(int i, int j)
        {
            Cell[] neighbours = new Cell[8];
            for (int z = 0; z < 8; z++)
            {
                neighbours[z] = new Cell();
            }

            if (i > 0)
            {
                neighbours[0] = data.Cells[i - 1, j];
            }
            if (i < data.Cells.GetLength(0) - 1)
            {
                neighbours[1] = data.Cells[i + 1, j];
            }
            if (j > 0)
            {
                neighbours[2] = data.Cells[i, j - 1];
            }
            if (j < data.Cells.GetLength(1) - 1)
            {
                neighbours[3] = data.Cells[i, j + 1];
            }
            if (i > 0 && j > 0)
            {
                neighbours[4] = data.Cells[i - 1, j - 1];
            }
            if (i < data.Cells.GetLength(0) - 1 && j > 0)
            {
                neighbours[5] = data.Cells[i + 1, j - 1];
            }
            if (i > 0 && j < data.Cells.GetLength(1) - 1)
            {
                neighbours[6] = data.Cells[i - 1, j + 1];
            }
            if (i < data.Cells.GetLength(0) - 1 && j < data.Cells.GetLength(1) - 1)
            {
                neighbours[7] = data.Cells[i + 1, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[0] = data.Cells[data.Cells.GetLength(0) - 1, j];
                }
                if (i == data.Cells.GetLength(0) - 1)
                {
                    neighbours[1] = data.Cells[0, j];
                }
                if (j == 0)
                {
                    neighbours[2] = data.Cells[i, data.Cells.GetLength(1) - 1];
                }
                if (j == data.Cells.GetLength(1) - 1)
                {
                    neighbours[3] = data.Cells[i, 0];
                }

                if (i == 0 && j == 0)
                {
                    neighbours[4] = data.Cells[data.Cells.GetLength(0) - 1, data.Cells.GetLength(1) - 1];
                }
                if (i == data.Cells.GetLength(0) - 1 && j == 0)
                {
                    neighbours[5] = data.Cells[0, data.Cells.GetLength(1) - 1];
                }
                if (i == 0 && j == data.Cells.GetLength(1) - 1)
                {
                    neighbours[6] = data.Cells[data.Cells.GetLength(0) - 1, 0];
                }
                if (i == data.Cells.GetLength(0) - 1 && j == data.Cells.GetLength(1) - 1)
                {
                    neighbours[7] = data.Cells[data.Cells.GetLength(0) - 1, data.Cells.GetLength(1) - 1];
                }
            }

            return select_neighbour(neighbours);
        }

        private Cell RndPentagonal(int i, int j)
        {
            Cell[] neighbours = new Cell[8];
            for (int z = 0; z < 8; z++)
            {
                neighbours[z] = new Cell();
            }
            int option = rnd.Next(1, 4);

            if (i > 0 && (option == 1 || option == 3 || option == 4))
            {
                neighbours[0] = data.Cells[i - 1, j];
            }
            if (i < data.Cells.GetLength(0) - 1 && (option == 2 || option == 3 || option == 4))
            {
                neighbours[1] = data.Cells[i + 1, j];
            }
            if (j > 0 && (option == 1 || option == 2 || option == 4))
            {
                neighbours[2] = data.Cells[i, j - 1];
            }
            if (j < data.Cells.GetLength(1) - 1 && (option == 1 || option == 2 || option == 3))
            {
                neighbours[3] = data.Cells[i, j + 1];
            }
            if (i > 0 && j > 0 && (option == 1 || option == 4))
            {
                neighbours[4] = data.Cells[i - 1, j - 1];
            }
            if (i < data.Cells.GetLength(0) - 1 && j > 0 && (option == 2 || option == 4))
            {
                neighbours[5] = data.Cells[i + 1, j - 1];
            }
            if (i > 0 && j < data.Cells.GetLength(1) - 1 && (option == 1 || option == 3))
            {
                neighbours[6] = data.Cells[i - 1, j + 1];
            }
            if (i < data.Cells.GetLength(0) - 1 && j < data.Cells.GetLength(1) - 1 && (option == 2 || option == 3))
            {
                neighbours[7] = data.Cells[i + 1, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0 && (option == 1 || option == 3 || option == 4))
                {
                    neighbours[0] = data.Cells[data.Cells.GetLength(0) - 1, j];
                }
                if (i == data.Cells.GetLength(0) - 1 && (option == 2 || option == 3 || option == 4))
                {
                    neighbours[1] = data.Cells[0, j];
                }
                if (j == 0 && (option == 1 || option == 2 || option == 4))
                {
                    neighbours[2] = data.Cells[i, data.Cells.GetLength(1) - 1];
                }
                if (j == data.Cells.GetLength(1) - 1 && (option == 1 || option == 2 || option == 3))
                {
                    neighbours[3] = data.Cells[i, 0];
                }

                if (i == 0 && j == 0 && (option == 1 || option == 4))
                {
                    neighbours[4] = data.Cells[data.Cells.GetLength(0) - 1, data.Cells.GetLength(1) - 1];
                }
                if (i == data.Cells.GetLength(0) - 1 && j == 0 && (option == 2 || option == 4))
                {
                    neighbours[5] = data.Cells[0, data.Cells.GetLength(1) - 1];
                }
                if (i == 0 && j == data.Cells.GetLength(1) - 1 && (option == 1 || option == 3))
                {
                    neighbours[6] = data.Cells[data.Cells.GetLength(0) - 1, 0];
                }
                if (i == data.Cells.GetLength(0) - 1 && j == data.Cells.GetLength(1) - 1 && (option == 2 || option == 3))
                {
                    neighbours[7] = data.Cells[data.Cells.GetLength(0) - 1, data.Cells.GetLength(1) - 1];
                }
            }

            return select_neighbour(neighbours);
        }

        private Cell LeftHexagonal(int i, int j)
        {
            Cell[] neighbours = new Cell[6];
            for (int z = 0; z < 6; z++)
            {
                neighbours[z] = new Cell();
            }

            if (i > 0)
            {
                neighbours[0] = data.Cells[i - 1, j];
            }
            if (i < data.Cells.GetLength(0) - 1)
            {
                neighbours[1] = data.Cells[i + 1, j];
            }
            if (j > 0)
            {
                neighbours[2] = data.Cells[i, j - 1];
            }
            if (j < data.Cells.GetLength(1) - 1)
            {
                neighbours[3] = data.Cells[i, j + 1];
            }
            if (i < data.Cells.GetLength(0) - 1 && j > 0)
            {
                neighbours[4] = data.Cells[i + 1, j - 1];
            }
            if (i > 0 && j < data.Cells.GetLength(1) - 1)
            {
                neighbours[5] = data.Cells[i - 1, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[0] = data.Cells[data.Cells.GetLength(0) - 1, j];
                }
                if (i == data.Cells.GetLength(0) - 1)
                {
                    neighbours[1] = data.Cells[0, j];
                }
                if (j == 0)
                {
                    neighbours[2] = data.Cells[i, data.Cells.GetLength(1) - 1];
                }
                if (j == data.Cells.GetLength(1) - 1)
                {
                    neighbours[3] = data.Cells[i, 0];
                }

                if (i == data.Cells.GetLength(0) - 1 && j == 0)
                {
                    neighbours[4] = data.Cells[0, data.Cells.GetLength(1) - 1];
                }
                if (i == 0 && j == data.Cells.GetLength(1) - 1)
                {
                    neighbours[5] = data.Cells[data.Cells.GetLength(0) - 1, 0];
                }
            }

            return select_neighbour(neighbours);
        }

        private Cell RightHexagonal(int i, int j)
        {
            Cell[] neighbours = new Cell[8];
            for (int z = 0; z < 8; z++)
            {
                neighbours[z] = new Cell();
            }

            if (i > 0)
            {
                neighbours[0] = data.Cells[i - 1, j];
            }
            if (i < data.Cells.GetLength(0) - 1)
            {
                neighbours[1] = data.Cells[i + 1, j];
            }
            if (j > 0)
            {
                neighbours[2] = data.Cells[i, j - 1];
            }
            if (j < data.Cells.GetLength(1) - 1)
            {
                neighbours[3] = data.Cells[i, j + 1];
            }
            if (i > 0 && j > 0)
            {
                neighbours[4] = data.Cells[i - 1, j - 1];
            }
            if (i < data.Cells.GetLength(0) - 1 && j < data.Cells.GetLength(1) - 1)
            {
                neighbours[7] = data.Cells[i + 1, j + 1];
            }

            if (data.Is_periodic)
            {
                if (i == 0)
                {
                    neighbours[0] = data.Cells[data.Cells.GetLength(0) - 1, j];
                }
                if (i == data.Cells.GetLength(0) - 1)
                {
                    neighbours[1] = data.Cells[0, j];
                }
                if (j == 0)
                {
                    neighbours[2] = data.Cells[i, data.Cells.GetLength(1) - 1];
                }
                if (j == data.Cells.GetLength(1) - 1)
                {
                    neighbours[3] = data.Cells[i, 0];
                }

                if (i == 0 && j == 0)
                {
                    neighbours[4] = data.Cells[data.Cells.GetLength(0) - 1, data.Cells.GetLength(1) - 1];
                }
                if (i == data.Cells.GetLength(0) - 1 && j == data.Cells.GetLength(1) - 1)
                {
                    neighbours[7] = data.Cells[data.Cells.GetLength(0) - 1, data.Cells.GetLength(1) - 1];
                }
            }

            return select_neighbour(neighbours);
        }

        private Cell RndHexagonal(int i, int j)
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

        private Cell Radius(int i, int j)
        {
            int count = (int)Math.Pow(2 * data.Neighborhood_radius, 2);
            Cell[] neighbours = new Cell[count];
            for (int z = 0; z < count; z++)
            {
                neighbours[z] = new Cell();
            }

            int index = 0;
            for(int k=i- data.Neighborhood_radius; k < i+ data.Neighborhood_radius; k++)
            {
                if (k < 0 || k > data.Cells.GetLength(0) - 1)
                {
                    continue;
                }

                for (int l=j- data.Neighborhood_radius; l < j+ data.Neighborhood_radius; l++)
                {
                    if(l<0 || l > data.Cells.GetLength(1)-1)
                    {
                        continue;
                    }

                    double length = Math.Sqrt(Math.Pow(data.Grid_points[i, j].X-data.Grid_points[k, l].X, 2)+Math.Pow(data.Grid_points[i, j].Y-data.Grid_points[k, l].Y, 2));
                    if(length <= data.Neighborhood_radius * data.Cell_size)
                    {
                        neighbours[index] = data.Cells[k, l];
                        index++;
                    }
                }
            }

            return select_neighbour(neighbours);
        }

        private Cell select_neighbour(Cell[] neighbours)
        {
            int index = 0;
            for(int i=1; i<neighbours.Length; i++)
            {
                if(data.Cells_quantity[neighbours[i].Value] > data.Cells_quantity[neighbours[index].Value])
                {
                    index = i;
                }
            }

            return neighbours[index];
        }
    }
}
