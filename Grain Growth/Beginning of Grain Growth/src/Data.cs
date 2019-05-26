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
        private List<Brush> colors;
        private List<int> cells;
        private int[,] grid_values;
        private Point[,] grid_points;
        private int speed;

        private int rnd_cells_num;
        private int vertical_homogenous_cells_num;
        private int horiziontal_homogenous_cells_num;
        private int radius;
        private int radius_cells_num;

        private string neighborhood;
        private int neighborhood_radius;

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
        public List<Brush> Colors { get => colors; set => colors = value; }
        public List<int> Cells { get => cells; set => cells = value; }
        public int[,] Grid_values { get => grid_values; set => grid_values = value; }
        public int Speed { get => speed; set => speed = value; }

        public int Rnd_cells_num { get => rnd_cells_num; set => rnd_cells_num = value; }
        public int Vertical_homogenous_cells_num { get => vertical_homogenous_cells_num; set => vertical_homogenous_cells_num = value; }
        public int Horiziontal_homogenous_cells_num { get => horiziontal_homogenous_cells_num; set => horiziontal_homogenous_cells_num = value; }
        public int Radius { get => radius; set => radius = value; }
        public int Radius_cells_num { get => radius_cells_num; set => radius_cells_num = value; }
        public string Neighborhood { get => neighborhood; set => neighborhood = value; }
        public Point[,] Grid_points { get => grid_points; set => grid_points = value; }
        public int Neighborhood_radius { get => neighborhood_radius; set => neighborhood_radius = value; }

        public void Initialize()
        {
            Colors = new List<Brush>
            {
                new SolidBrush(Color.FromArgb(255, 255, 255))
            };

            cells = new List<int>
            {
                new int()
            };

            current_index = 0;
            grid_values = new int[horizontal_cells_num, vertical_cells_num];
            grid_points = new Point[horizontal_cells_num, vertical_cells_num];
            for(int i=0; i < horizontal_cells_num; i++)
            {
                for(int j=0; j < vertical_cells_num; j++)
                {
                    grid_points[i, j] = new Point(rnd.Next(i*cell_size, (i+1)*cell_size), rnd.Next(j*cell_size, (j+1)*cell_size));
                }
            }
        }

        public void Add_new_color()
        {
            cells.Add(1);
            colors.Add(new SolidBrush(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))));
        }
    }
}
