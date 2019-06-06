using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beginning_of_Grain_Growth.src
{
    class Data
    {
        private int vertical_cells_num;
        private int horizontal_cells_num;
        private int cell_size;
        private bool is_periodic;
        private int current_index;
        private Cell[,] cells;
        private Cell[,] recrystallized_cells;
        private List<int> cells_quantity;
        private Point[,] grid_points;
        private int speed;

        private int rnd_cells_num;
        private int vertical_homogenous_cells_num;
        private int horiziontal_homogenous_cells_num;
        private int radius;
        private int radius_cells_num;

        private string neighborhood;
        private int neighborhood_radius;

        private double time_step;
        private bool show_density;
        private bool[,] DENSITY;
        private double[,] DENSITY2;

        private Random rnd;

        public Data()
        {
            rnd = new Random();

            is_periodic = false;
            current_index = 0;
            neighborhood = "Von Neumann";
        }

        public int Vertical_cells_num { get => vertical_cells_num; set => vertical_cells_num = value; }
        public int Horizontal_cells_num { get => horizontal_cells_num; set => horizontal_cells_num = value; }
        public int Cell_size { get => cell_size; set => cell_size = value; }
        public bool Is_periodic { get => is_periodic; set => is_periodic = value; }
        public int Current_index { get => current_index; set => current_index = value; }
        public Cell[,] Cells { get => cells; set => cells = value; }
        public int Speed { get => speed; set => speed = value; }

        public int Rnd_cells_num { get => rnd_cells_num; set => rnd_cells_num = value; }
        public int Vertical_homogenous_cells_num { get => vertical_homogenous_cells_num; set => vertical_homogenous_cells_num = value; }
        public int Horiziontal_homogenous_cells_num { get => horiziontal_homogenous_cells_num; set => horiziontal_homogenous_cells_num = value; }
        public int Radius { get => radius; set => radius = value; }
        public int Radius_cells_num { get => radius_cells_num; set => radius_cells_num = value; }
        public string Neighborhood { get => neighborhood; set => neighborhood = value; }
        public Point[,] Grid_points { get => grid_points; set => grid_points = value; }
        public int Neighborhood_radius { get => neighborhood_radius; set => neighborhood_radius = value; }
        public List<int> Cells_quantity { get => cells_quantity; set => cells_quantity = value; }
        public double Time_step { get => time_step; set => time_step = value; }
        public bool Show_density { get => show_density; set => show_density = value; }
        public bool[,] IS_RECRYSTALLIZED { get => DENSITY; set => DENSITY = value; }
        public double[,] DENSITY21 { get => DENSITY2; set => DENSITY2 = value; }
        internal Cell[,] Recrystallized_cells { get => recrystallized_cells; set => recrystallized_cells = value; }

        public void Initialize()
        {
            current_index = 0;
            cells = new Cell[horizontal_cells_num, vertical_cells_num];
            Recrystallized_cells = new Cell[horizontal_cells_num, vertical_cells_num];
            IS_RECRYSTALLIZED = new bool[horizontal_cells_num, vertical_cells_num];
            DENSITY = new bool[horizontal_cells_num, vertical_cells_num];
            DENSITY21 = new double[horizontal_cells_num, vertical_cells_num];
            for (int i =0; i<horizontal_cells_num; i++)
            {
                for(int j=0; j<vertical_cells_num; j++)
                {
                    cells[i, j] = new Cell();
                    recrystallized_cells[i, j] = new Cell();
                }
            }

            Cells_quantity = new List<int> { 0 };

            grid_points = new Point[horizontal_cells_num, vertical_cells_num];
            for(int i=0; i < horizontal_cells_num; i++)
            {
                for(int j=0; j < vertical_cells_num; j++)
                {
                    grid_points[i, j] = new Point(rnd.Next(i*cell_size, (i+1)*cell_size), rnd.Next(j*cell_size, (j+1)*cell_size));
                }
            }
        }
    }
}
