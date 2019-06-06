using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginning_of_Grain_Growth.src
{
    class DRX
    {
        private Data data;
        private Display display;
        private List<double> Rho;
        private double critical_Rho;
        private double A;
        private double B;
        private int iteration;
        private double x;

        private Random rnd;
        List<Cell> boundary;
        List<Point> POINT;
        List<Cell> inside;
        List<bool[,]> is_recrystallized_list;

        public DRX(Data data, Display display)
        {
            this.data = data;
            this.display = display;
            this.rnd = new Random();
            this.A = 86710969050178.5;
            this.B = 9.41268203527779;
            this.iteration = -1;
            this.Rho = new List<double> ();
            this.x = 0.3;
            this.is_recrystallized_list = new List<bool[,]>();

            CalculateRho();
        }

        public void NextStep()
        {
            if (data.Cells == null)
                return;

            for (int i = 0; i < data.Horizontal_cells_num; i++)
            {
                for (int j = 0; j < data.Vertical_cells_num; j++)
                {
                    if (data.Cells[i, j].Value == 0)
                        return;
                }
            }

            this.critical_Rho = 4.21584e+12 / (data.Horizontal_cells_num * data.Vertical_cells_num);

            set_boundary_and_inside();
            Calculate();

            if (data.Show_density)
            {
                display.Print_Density();
            }
            else
            {
                display.Print_Grid();
            }
        }

        private void Calculate()
        {
            for (int i = 0; i < data.Speed; i++)
            {
                CalculateRho();
                is_recrystallized_list.Add(new bool[data.Horizontal_cells_num, data.Vertical_cells_num]);
                double delta_Rho = Math.Abs(Rho[iteration] - Rho[iteration - 1]);
                double cell_dislocation_value = delta_Rho / (data.Horizontal_cells_num * data.Vertical_cells_num);
                double dislocation_value_remnant = cell_dislocation_value * (1 - x) * (data.Horizontal_cells_num * data.Vertical_cells_num);
                double package = dislocation_value_remnant * rnd.NextDouble();
                int package_quantity = (int)(dislocation_value_remnant / package);

                set_dislocation_for_all_cells(cell_dislocation_value);
                for (int k = 0; k < package_quantity; k++)
                {
                    set_random_dislocation(package);
                }

                run();
            }
        }

        private void set_dislocation_for_all_cells(double cell_dislocation_value)
        {
            for (int k = 0; k < data.Horizontal_cells_num; k++)
            {
                for (int l = 0; l < data.Vertical_cells_num; l++)
                {
                    data.Cells[k, l].Density += x * cell_dislocation_value;
                }
            }
        }

        private void CalculateRho()
        {
            iteration++;
            Rho.Add( A / B + (1 - A / B) * Math.Exp(-B * data.Time_step * iteration));
        }

        private void set_boundary_and_inside()
        {
            boundary = new List<Cell>();
            POINT = new List<Point>();
            inside = new List<Cell>();
            bool is_boundary;
            for (int i = 0; i < data.Horizontal_cells_num; i++)
            {
                for (int j = 0; j < data.Vertical_cells_num; j++)
                {
                    is_boundary = false;
                    if (data.Neighborhood == "Moore")
                    {
                        for (int k = i - 1; k < i + 1; k++)
                        {
                            if (k < 0 || k >= data.Horizontal_cells_num)
                                continue;

                            for (int l = j - 1; l < j + 1; l++)
                            {
                                if (l < 0 || l >= data.Vertical_cells_num || (k == i && l == j))
                                    continue;

                                if (data.Cells[k, l].Value != data.Cells[i, j].Value)
                                {
                                    is_boundary = true;
                                    break;
                                }
                            }

                            if (is_boundary)
                                break;
                        }
                    }
                    else
                    {
                        Cell[] neighbours = new Cell[4];
                        for (int z = 0; z < 4; z++)
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

                        for(int k=0; k<4; k++)
                        {
                            if (neighbours[k].Value == 0)
                                continue;

                            if (data.Cells[i, j].Value != neighbours[k].Value)
                            {
                                is_boundary = true;
                                break;
                            }
                        }
                    }


                    //Console.Write(is_boundary + "\t");

                    if (is_boundary)
                    {
                        //data.Cells[i, j].Is_recrystallized = true;
                        boundary.Add(data.Cells[i, j]);
                        POINT.Add(new Point(i, j));
                    }
                    else
                    {
                        //data.Cells[i, j].Is_recrystallized = false;
                        inside.Add(data.Cells[i, j]);
                    }
                }
                //Console.WriteLine();
            }
        }

        private void set_random_dislocation(double package)
        {
            int value = rnd.Next(1, 101);
            if (value <= 80)
            {
                int index = rnd.Next(0, boundary.Count);
                boundary[index].Density += package;

                if (boundary[index].Density > critical_Rho)
                {
                    data.IS_RECRYSTALLIZED[POINT[index].X, POINT[index].Y] = true;
                    is_recrystallized_list[iteration-1][POINT[index].X, POINT[index].Y] = true;
                    data.Recrystallized_cells[POINT[index].X, POINT[index].Y].Value = ++data.Current_index;
                    data.Recrystallized_cells[POINT[index].X, POINT[index].Y].set_red_color();
                    //boundary[index].Is_recrystallized = true;
                    boundary[index].Density = 0;
                }

            }
            else
            {
                int index = rnd.Next(0, inside.Count);
                inside[index].Density += package;
            }
        }

        private void run()
        {
            if (iteration <= 1)
                return;

            for (int i = 0; i < data.Horizontal_cells_num; i++)
            {
                for (int j = 0; j < data.Vertical_cells_num; j++)
                {
                    bool did_recrystallized = false;
                    int w =0, g =0;
                    bool is_lower_density = true;

                    if (data.Neighborhood == "Moore")
                    {
                        for (int k = i - 1; k < i + 1; k++)
                        {
                            if (k < 0 || k >= data.Horizontal_cells_num)
                                continue;

                            for (int l = j - 1; l < j + 1; l++)
                            {
                                if (l < 0 || l >= data.Vertical_cells_num || (k == i && l == j))
                                    continue;

                                if (is_recrystallized_list[iteration-2][k, l])
                                {
                                    did_recrystallized = true;
                                    w = k;
                                    g = l;
                                }

                                if (data.Cells[i, j].Density < data.Cells[k, l].Density)
                                {
                                    is_lower_density = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        Cell[] neighbours = new Cell[4];
                        for (int z = 0; z < 4; z++)
                        {
                            neighbours[z] = new Cell();
                        }

                        if (i > 0)
                        {
                            neighbours[0] = data.Cells[i - 1, j];
                            if (is_recrystallized_list[iteration - 2][i - 1, j])
                            {
                                did_recrystallized = true;
                                w = i - 1;
                                g = j;
                            }
                        }
                        if (i < data.Cells.GetLength(0) - 1)
                        {
                            neighbours[1] = data.Cells[i + 1, j];
                            if (is_recrystallized_list[iteration - 2][i + 1, j])
                            {
                                did_recrystallized = true;
                                w = i + 1;
                                g = j;
                            }
                        }
                        if (j > 0)
                        {
                            neighbours[2] = data.Cells[i, j - 1];
                            if (is_recrystallized_list[iteration - 2][i, j - 1])
                            {
                                did_recrystallized = true;
                                w = i;
                                g = j - 1;
                            }
                        }
                        if (j < data.Cells.GetLength(1) - 1)
                        {
                            neighbours[3] = data.Cells[i, j + 1];
                            if (is_recrystallized_list[iteration - 2][i, j + 1])
                            {
                                did_recrystallized = true;
                                w = i;
                                g = j + 1;
                            }
                        }

                        for (int k = 0; k < 4; k++)
                        {
                            if (data.Cells[i, j].Density < neighbours[k].Density)
                            {
                                is_lower_density = false;
                            }
                        }
                    }

                    if (!did_recrystallized)
                        continue;

                    if (!is_lower_density)
                        continue;

                    //
                    data.Cells[i, j].Density = 0;
                    data.IS_RECRYSTALLIZED[i, j] = true;
                    is_recrystallized_list[iteration-1][i,j]=true;

                    data.Recrystallized_cells[i, j].Value = data.Recrystallized_cells[w, g].Value;
                    data.Recrystallized_cells[i, j].Color = data.Recrystallized_cells[w, g].Color;

                }
            }
        }

        public void Save()
        {
            if (Rho.Count == 0)
                return;

            var csv = new StringBuilder();

            String newLine = string.Format("Time;Rho");
            csv.AppendLine(newLine);

            for (int i=0; i<Rho.Count; i++)
            {
                newLine = string.Format($"{i*data.Time_step};{Rho[i]}");
                csv.AppendLine(newLine);
            }

            File.WriteAllText("file.csv", csv.ToString());
        }
    }
}
