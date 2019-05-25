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

        public Solver(Display display, Data data)
        {
            this.display = display;
            this.data = data;
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

                        int value = select_neighbour(neighbours);
                        
                        if(value != 0)
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

        private int select_neighbour(int[] neighbours)
        {
            int index = 0;
            for(int i=1; i<4; i++)
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
