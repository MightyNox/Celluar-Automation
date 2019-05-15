namespace Celluar_Automation
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button = new System.Windows.Forms.Button();
            this.cell_size_label = new System.Windows.Forms.Label();
            this.cell_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rule_label = new System.Windows.Forms.Label();
            this.grid_checkbox = new System.Windows.Forms.CheckBox();
            this.grid_label = new System.Windows.Forms.Label();
            this.rule_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.vertical_cells_label = new System.Windows.Forms.Label();
            this.horizontal_cells_label = new System.Windows.Forms.Label();
            this.horizontal_cells_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.vertical_cells_numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rule_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontal_cells_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertical_cells_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox.Location = new System.Drawing.Point(12, 148);
            this.pictureBox.MinimumSize = new System.Drawing.Size(601, 401);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(601, 401);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(718, 402);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(100, 23);
            this.button.TabIndex = 1;
            this.button.Text = "start";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.Button_Click);
            // 
            // cell_size_label
            // 
            this.cell_size_label.AutoSize = true;
            this.cell_size_label.Location = new System.Drawing.Point(664, 301);
            this.cell_size_label.Name = "cell_size_label";
            this.cell_size_label.Size = new System.Drawing.Size(48, 13);
            this.cell_size_label.TabIndex = 4;
            this.cell_size_label.Text = "Cell size:";
            // 
            // cell_numericUpDown
            // 
            this.cell_numericUpDown.Location = new System.Drawing.Point(718, 299);
            this.cell_numericUpDown.Name = "cell_numericUpDown";
            this.cell_numericUpDown.Size = new System.Drawing.Size(100, 20);
            this.cell_numericUpDown.TabIndex = 6;
            this.cell_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cell_numericUpDown.ValueChanged += new System.EventHandler(this.Cell_ValueChanged);
            // 
            // rule_label
            // 
            this.rule_label.AutoSize = true;
            this.rule_label.Location = new System.Drawing.Point(677, 333);
            this.rule_label.Name = "rule_label";
            this.rule_label.Size = new System.Drawing.Size(35, 13);
            this.rule_label.TabIndex = 7;
            this.rule_label.Text = "Rule: ";
            // 
            // grid_checkbox
            // 
            this.grid_checkbox.AutoSize = true;
            this.grid_checkbox.Location = new System.Drawing.Point(728, 367);
            this.grid_checkbox.Name = "grid_checkbox";
            this.grid_checkbox.Size = new System.Drawing.Size(78, 17);
            this.grid_checkbox.TabIndex = 9;
            this.grid_checkbox.Text = "display grid";
            this.grid_checkbox.UseVisualStyleBackColor = true;
            // 
            // grid_label
            // 
            this.grid_label.AutoSize = true;
            this.grid_label.Location = new System.Drawing.Point(683, 367);
            this.grid_label.Name = "grid_label";
            this.grid_label.Size = new System.Drawing.Size(29, 13);
            this.grid_label.TabIndex = 10;
            this.grid_label.Text = "Grid:";
            // 
            // rule_numericUpDown
            // 
            this.rule_numericUpDown.Location = new System.Drawing.Point(718, 331);
            this.rule_numericUpDown.Name = "rule_numericUpDown";
            this.rule_numericUpDown.Size = new System.Drawing.Size(100, 20);
            this.rule_numericUpDown.TabIndex = 11;
            this.rule_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rule_numericUpDown.ValueChanged += new System.EventHandler(this.Rule_numericUpDown_ValueChanged);
            // 
            // vertical_cells_label
            // 
            this.vertical_cells_label.AutoSize = true;
            this.vertical_cells_label.Location = new System.Drawing.Point(643, 270);
            this.vertical_cells_label.Name = "vertical_cells_label";
            this.vertical_cells_label.Size = new System.Drawing.Size(69, 13);
            this.vertical_cells_label.TabIndex = 14;
            this.vertical_cells_label.Text = "Vertical cells:";
            // 
            // horizontal_cells_label
            // 
            this.horizontal_cells_label.AutoSize = true;
            this.horizontal_cells_label.Location = new System.Drawing.Point(631, 239);
            this.horizontal_cells_label.Name = "horizontal_cells_label";
            this.horizontal_cells_label.Size = new System.Drawing.Size(81, 13);
            this.horizontal_cells_label.TabIndex = 15;
            this.horizontal_cells_label.Text = "Horizontal cells:";
            // 
            // horizontal_cells_numericUpDown
            // 
            this.horizontal_cells_numericUpDown.Location = new System.Drawing.Point(718, 237);
            this.horizontal_cells_numericUpDown.Name = "horizontal_cells_numericUpDown";
            this.horizontal_cells_numericUpDown.Size = new System.Drawing.Size(100, 20);
            this.horizontal_cells_numericUpDown.TabIndex = 16;
            this.horizontal_cells_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.horizontal_cells_numericUpDown.ValueChanged += new System.EventHandler(this.vertical_cells_numericUpDown_ValueChanged);
            // 
            // vertical_cells_numericUpDown
            // 
            this.vertical_cells_numericUpDown.Location = new System.Drawing.Point(718, 268);
            this.vertical_cells_numericUpDown.Name = "vertical_cells_numericUpDown";
            this.vertical_cells_numericUpDown.Size = new System.Drawing.Size(100, 20);
            this.vertical_cells_numericUpDown.TabIndex = 17;
            this.vertical_cells_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.vertical_cells_numericUpDown.ValueChanged += new System.EventHandler(this.horizontal_cells_numericUpDown_ValueChanged);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(864, 561);
            this.Controls.Add(this.vertical_cells_numericUpDown);
            this.Controls.Add(this.horizontal_cells_numericUpDown);
            this.Controls.Add(this.horizontal_cells_label);
            this.Controls.Add(this.vertical_cells_label);
            this.Controls.Add(this.rule_numericUpDown);
            this.Controls.Add(this.grid_label);
            this.Controls.Add(this.grid_checkbox);
            this.Controls.Add(this.rule_label);
            this.Controls.Add(this.cell_numericUpDown);
            this.Controls.Add(this.cell_size_label);
            this.Controls.Add(this.button);
            this.Controls.Add(this.pictureBox);
            this.MaximumSize = new System.Drawing.Size(880, 600);
            this.MinimumSize = new System.Drawing.Size(880, 600);
            this.Name = "Form";
            this.Text = "Elementary Celluar Automation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rule_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontal_cells_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertical_cells_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label cell_size_label;
        private System.Windows.Forms.NumericUpDown cell_numericUpDown;
        private System.Windows.Forms.Label rule_label;
        private System.Windows.Forms.CheckBox grid_checkbox;
        private System.Windows.Forms.Label grid_label;
        private System.Windows.Forms.NumericUpDown rule_numericUpDown;
        private System.Windows.Forms.Label vertical_cells_label;
        private System.Windows.Forms.Label horizontal_cells_label;
        private System.Windows.Forms.NumericUpDown horizontal_cells_numericUpDown;
        private System.Windows.Forms.NumericUpDown vertical_cells_numericUpDown;
    }
}

