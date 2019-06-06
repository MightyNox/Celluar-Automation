using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginning_of_Grain_Growth.src
{
    class Cell
    {
        int value;
        Color color;
        double density;
        bool is_recrystallized;
        static Random rnd = new Random();

        public Cell()
        {
            this.Value = 0;
            this.Color = Color.White;
            this.Is_recrystallized = false;
            this.Density = 0;
        }

        public int Value { get => value; set => this.value = value; }
        public Color Color { get => color; set => color = value; }
        public double Density { get => density; set => density = value; }
        public bool Is_recrystallized { get => is_recrystallized; set => is_recrystallized = value; }

        public void set_unique_color()
        {
            this.color = Color.FromArgb(0, rnd.Next(256), rnd.Next(256));
        }

        public void set_red_color()
        {
            this.color = Color.FromArgb(rnd.Next(256), 0, 0);
            //this.color = Color.FromArgb(255, 0, 0);
        }
    }
}
