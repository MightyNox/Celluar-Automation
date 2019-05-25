namespace Beginning_of_Grain_Growth
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.conditions_label = new System.Windows.Forms.Label();
            this.periodic_checkbox = new System.Windows.Forms.CheckBox();
            this.cell_size_box = new System.Windows.Forms.NumericUpDown();
            this.cell_size_label = new System.Windows.Forms.Label();
            this.custom_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Nucleation_Box = new System.Windows.Forms.GroupBox();
            this.radius_box = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radius_cells_num_box = new System.Windows.Forms.NumericUpDown();
            this.radius_button = new System.Windows.Forms.Button();
            this.vertical_homogenous_cells_box = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.horizontal_homogenous_cells_box = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.homogeneous_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rnd_cells_num_box = new System.Windows.Forms.NumericUpDown();
            this.random_button = new System.Windows.Forms.Button();
            this.speed_box = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.vertical_cells_box = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.horizontal_cells_box = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.clear_button = new System.Windows.Forms.Button();
            this.neighborhood_box = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cell_size_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.Nucleation_Box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radius_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radius_cells_num_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertical_homogenous_cells_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontal_homogenous_cells_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rnd_cells_num_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertical_cells_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontal_cells_box)).BeginInit();
            this.SuspendLayout();
            // 
            // conditions_label
            // 
            this.conditions_label.AutoSize = true;
            this.conditions_label.Location = new System.Drawing.Point(807, 485);
            this.conditions_label.Name = "conditions_label";
            this.conditions_label.Size = new System.Drawing.Size(107, 13);
            this.conditions_label.TabIndex = 23;
            this.conditions_label.Text = "Boundary Conditions:";
            // 
            // periodic_checkbox
            // 
            this.periodic_checkbox.AutoSize = true;
            this.periodic_checkbox.Location = new System.Drawing.Point(791, 509);
            this.periodic_checkbox.Name = "periodic_checkbox";
            this.periodic_checkbox.Size = new System.Drawing.Size(123, 17);
            this.periodic_checkbox.TabIndex = 22;
            this.periodic_checkbox.Text = "periodic /  absorbing";
            this.periodic_checkbox.UseVisualStyleBackColor = true;
            this.periodic_checkbox.CheckedChanged += new System.EventHandler(this.periodic_checkbox_CheckedChanged);
            // 
            // cell_size_box
            // 
            this.cell_size_box.Location = new System.Drawing.Point(600, 518);
            this.cell_size_box.Name = "cell_size_box";
            this.cell_size_box.Size = new System.Drawing.Size(100, 20);
            this.cell_size_box.TabIndex = 20;
            this.cell_size_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cell_size_box.ValueChanged += new System.EventHandler(this.Cell_size_box_ValueChanged);
            // 
            // cell_size_label
            // 
            this.cell_size_label.AutoSize = true;
            this.cell_size_label.Location = new System.Drawing.Point(546, 520);
            this.cell_size_label.Name = "cell_size_label";
            this.cell_size_label.Size = new System.Drawing.Size(48, 13);
            this.cell_size_label.TabIndex = 19;
            this.cell_size_label.Text = "Cell size:";
            // 
            // custom_button
            // 
            this.custom_button.Location = new System.Drawing.Point(6, 139);
            this.custom_button.Name = "custom_button";
            this.custom_button.Size = new System.Drawing.Size(100, 23);
            this.custom_button.TabIndex = 18;
            this.custom_button.Text = "Next step";
            this.custom_button.UseVisualStyleBackColor = true;
            this.custom_button.Click += new System.EventHandler(this.custom_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(800, 529);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "checked / unchecked";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox.Location = new System.Drawing.Point(42, 41);
            this.pictureBox.MinimumSize = new System.Drawing.Size(601, 401);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(750, 401);
            this.pictureBox.TabIndex = 30;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // Nucleation_Box
            // 
            this.Nucleation_Box.Controls.Add(this.radius_box);
            this.Nucleation_Box.Controls.Add(this.label6);
            this.Nucleation_Box.Controls.Add(this.label5);
            this.Nucleation_Box.Controls.Add(this.radius_cells_num_box);
            this.Nucleation_Box.Controls.Add(this.radius_button);
            this.Nucleation_Box.Controls.Add(this.vertical_homogenous_cells_box);
            this.Nucleation_Box.Controls.Add(this.label4);
            this.Nucleation_Box.Controls.Add(this.horizontal_homogenous_cells_box);
            this.Nucleation_Box.Controls.Add(this.label3);
            this.Nucleation_Box.Controls.Add(this.homogeneous_button);
            this.Nucleation_Box.Controls.Add(this.label2);
            this.Nucleation_Box.Controls.Add(this.rnd_cells_num_box);
            this.Nucleation_Box.Controls.Add(this.random_button);
            this.Nucleation_Box.Controls.Add(this.custom_button);
            this.Nucleation_Box.Location = new System.Drawing.Point(42, 474);
            this.Nucleation_Box.Name = "Nucleation_Box";
            this.Nucleation_Box.Size = new System.Drawing.Size(432, 168);
            this.Nucleation_Box.TabIndex = 31;
            this.Nucleation_Box.TabStop = false;
            this.Nucleation_Box.Text = "Nucleation";
            // 
            // radius_box
            // 
            this.radius_box.Location = new System.Drawing.Point(324, 75);
            this.radius_box.Name = "radius_box";
            this.radius_box.Size = new System.Drawing.Size(100, 20);
            this.radius_box.TabIndex = 36;
            this.radius_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.radius_box.ValueChanged += new System.EventHandler(this.radius_box_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Radius:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Number:";
            // 
            // radius_cells_num_box
            // 
            this.radius_cells_num_box.Location = new System.Drawing.Point(324, 32);
            this.radius_cells_num_box.Name = "radius_cells_num_box";
            this.radius_cells_num_box.Size = new System.Drawing.Size(100, 20);
            this.radius_cells_num_box.TabIndex = 33;
            this.radius_cells_num_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.radius_cells_num_box.ValueChanged += new System.EventHandler(this.radius_cells_num_box_ValueChanged);
            // 
            // radius_button
            // 
            this.radius_button.Location = new System.Drawing.Point(324, 139);
            this.radius_button.Name = "radius_button";
            this.radius_button.Size = new System.Drawing.Size(100, 23);
            this.radius_button.TabIndex = 32;
            this.radius_button.Text = "Radius";
            this.radius_button.UseVisualStyleBackColor = true;
            this.radius_button.Click += new System.EventHandler(this.radius_button_Click);
            // 
            // vertical_homogenous_cells_box
            // 
            this.vertical_homogenous_cells_box.Location = new System.Drawing.Point(218, 75);
            this.vertical_homogenous_cells_box.Name = "vertical_homogenous_cells_box";
            this.vertical_homogenous_cells_box.Size = new System.Drawing.Size(100, 20);
            this.vertical_homogenous_cells_box.TabIndex = 26;
            this.vertical_homogenous_cells_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.vertical_homogenous_cells_box.ValueChanged += new System.EventHandler(this.vertical_homogenous_cells_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Verical number:";
            // 
            // horizontal_homogenous_cells_box
            // 
            this.horizontal_homogenous_cells_box.Location = new System.Drawing.Point(218, 32);
            this.horizontal_homogenous_cells_box.Name = "horizontal_homogenous_cells_box";
            this.horizontal_homogenous_cells_box.Size = new System.Drawing.Size(100, 20);
            this.horizontal_homogenous_cells_box.TabIndex = 24;
            this.horizontal_homogenous_cells_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.horizontal_homogenous_cells_box.ValueChanged += new System.EventHandler(this.horizontal_homogenous_cells_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Horizontal number:";
            // 
            // homogeneous_button
            // 
            this.homogeneous_button.Location = new System.Drawing.Point(218, 139);
            this.homogeneous_button.Name = "homogeneous_button";
            this.homogeneous_button.Size = new System.Drawing.Size(100, 23);
            this.homogeneous_button.TabIndex = 22;
            this.homogeneous_button.Text = "Homogeneous";
            this.homogeneous_button.UseVisualStyleBackColor = true;
            this.homogeneous_button.Click += new System.EventHandler(this.homogeneous_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Number:";
            // 
            // rnd_cells_num_box
            // 
            this.rnd_cells_num_box.Location = new System.Drawing.Point(107, 32);
            this.rnd_cells_num_box.Name = "rnd_cells_num_box";
            this.rnd_cells_num_box.Size = new System.Drawing.Size(100, 20);
            this.rnd_cells_num_box.TabIndex = 20;
            this.rnd_cells_num_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rnd_cells_num_box.ValueChanged += new System.EventHandler(this.Rnd_cells_num_box_ValueChanged);
            // 
            // random_button
            // 
            this.random_button.Location = new System.Drawing.Point(112, 139);
            this.random_button.Name = "random_button";
            this.random_button.Size = new System.Drawing.Size(100, 23);
            this.random_button.TabIndex = 19;
            this.random_button.Text = "Random";
            this.random_button.UseVisualStyleBackColor = true;
            this.random_button.Click += new System.EventHandler(this.random_button_Click);
            // 
            // speed_box
            // 
            this.speed_box.Location = new System.Drawing.Point(600, 483);
            this.speed_box.Name = "speed_box";
            this.speed_box.Size = new System.Drawing.Size(100, 20);
            this.speed_box.TabIndex = 33;
            this.speed_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.speed_box.ValueChanged += new System.EventHandler(this.speed_box_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 485);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Speed:";
            // 
            // vertical_cells_box
            // 
            this.vertical_cells_box.Location = new System.Drawing.Point(600, 590);
            this.vertical_cells_box.Name = "vertical_cells_box";
            this.vertical_cells_box.Size = new System.Drawing.Size(100, 20);
            this.vertical_cells_box.TabIndex = 37;
            this.vertical_cells_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.vertical_cells_box.ValueChanged += new System.EventHandler(this.vertical_cells_box_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(514, 556);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Verical number:";
            // 
            // horizontal_cells_box
            // 
            this.horizontal_cells_box.Location = new System.Drawing.Point(600, 554);
            this.horizontal_cells_box.Name = "horizontal_cells_box";
            this.horizontal_cells_box.Size = new System.Drawing.Size(100, 20);
            this.horizontal_cells_box.TabIndex = 35;
            this.horizontal_cells_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.horizontal_cells_box.ValueChanged += new System.EventHandler(this.horizontal_cells_box_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(499, 592);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Horizontal number:";
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(810, 603);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(104, 23);
            this.clear_button.TabIndex = 38;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // neighborhood_box
            // 
            this.neighborhood_box.FormattingEnabled = true;
            this.neighborhood_box.Location = new System.Drawing.Point(600, 621);
            this.neighborhood_box.Name = "neighborhood_box";
            this.neighborhood_box.Size = new System.Drawing.Size(100, 21);
            this.neighborhood_box.TabIndex = 39;
            this.neighborhood_box.SelectedIndexChanged += new System.EventHandler(this.neighborhood_box_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(514, 623);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Neighborhood:";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 654);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.neighborhood_box);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.vertical_cells_box);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.horizontal_cells_box);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.speed_box);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Nucleation_Box);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.conditions_label);
            this.Controls.Add(this.periodic_checkbox);
            this.Controls.Add(this.cell_size_box);
            this.Controls.Add(this.cell_size_label);
            this.Name = "Form";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cell_size_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.Nucleation_Box.ResumeLayout(false);
            this.Nucleation_Box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radius_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radius_cells_num_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertical_homogenous_cells_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontal_homogenous_cells_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rnd_cells_num_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertical_cells_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontal_cells_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label conditions_label;
        private System.Windows.Forms.CheckBox periodic_checkbox;
        private System.Windows.Forms.NumericUpDown cell_size_box;
        private System.Windows.Forms.Label cell_size_label;
        private System.Windows.Forms.Button custom_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox Nucleation_Box;
        private System.Windows.Forms.Button random_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown rnd_cells_num_box;
        private System.Windows.Forms.NumericUpDown vertical_homogenous_cells_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown horizontal_homogenous_cells_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button homogeneous_button;
        private System.Windows.Forms.NumericUpDown radius_box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown radius_cells_num_box;
        private System.Windows.Forms.Button radius_button;
        private System.Windows.Forms.NumericUpDown speed_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown vertical_cells_box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown horizontal_cells_box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.ComboBox neighborhood_box;
        private System.Windows.Forms.Label label10;
    }
}

