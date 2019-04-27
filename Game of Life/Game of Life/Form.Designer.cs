namespace Game_of_Life
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
            this.run_game_box = new System.Windows.Forms.CheckBox();
            this.speed_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.speed_label = new System.Windows.Forms.Label();
            this.pattern_comboBox = new System.Windows.Forms.ComboBox();
            this.pattern_label = new System.Windows.Forms.Label();
            this.cell_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cell_size_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox.Location = new System.Drawing.Point(12, 94);
            this.pictureBox.MinimumSize = new System.Drawing.Size(601, 401);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(601, 401);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // run_game_box
            // 
            this.run_game_box.AutoSize = true;
            this.run_game_box.Location = new System.Drawing.Point(740, 355);
            this.run_game_box.Name = "run_game_box";
            this.run_game_box.Size = new System.Drawing.Size(46, 17);
            this.run_game_box.TabIndex = 29;
            this.run_game_box.Text = "Run";
            this.run_game_box.UseVisualStyleBackColor = true;
            this.run_game_box.CheckedChanged += new System.EventHandler(this.Run_game_box_CheckedChanged);
            // 
            // speed_numericUpDown
            // 
            this.speed_numericUpDown.Location = new System.Drawing.Point(706, 279);
            this.speed_numericUpDown.Name = "speed_numericUpDown";
            this.speed_numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.speed_numericUpDown.TabIndex = 30;
            this.speed_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.speed_numericUpDown.ValueChanged += new System.EventHandler(this.Speed_numericUpDown_ValueChanged);
            // 
            // speed_label
            // 
            this.speed_label.AutoSize = true;
            this.speed_label.Location = new System.Drawing.Point(634, 281);
            this.speed_label.Name = "speed_label";
            this.speed_label.Size = new System.Drawing.Size(66, 13);
            this.speed_label.TabIndex = 31;
            this.speed_label.Text = "Speed level:";
            // 
            // pattern_comboBox
            // 
            this.pattern_comboBox.FormattingEnabled = true;
            this.pattern_comboBox.Location = new System.Drawing.Point(706, 237);
            this.pattern_comboBox.Name = "pattern_comboBox";
            this.pattern_comboBox.Size = new System.Drawing.Size(120, 21);
            this.pattern_comboBox.TabIndex = 32;
            this.pattern_comboBox.Text = "Empty";
            this.pattern_comboBox.SelectedIndexChanged += new System.EventHandler(this.Pattern_comboBox_SelectedIndexChanged);
            // 
            // pattern_label
            // 
            this.pattern_label.AutoSize = true;
            this.pattern_label.Location = new System.Drawing.Point(656, 240);
            this.pattern_label.Name = "pattern_label";
            this.pattern_label.Size = new System.Drawing.Size(44, 13);
            this.pattern_label.TabIndex = 33;
            this.pattern_label.Text = "Pattern:";
            // 
            // cell_numericUpDown
            // 
            this.cell_numericUpDown.Location = new System.Drawing.Point(706, 316);
            this.cell_numericUpDown.Name = "cell_numericUpDown";
            this.cell_numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.cell_numericUpDown.TabIndex = 35;
            this.cell_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cell_numericUpDown.ValueChanged += new System.EventHandler(this.Cell_numericUpDown_ValueChanged);
            // 
            // cell_size_label
            // 
            this.cell_size_label.AutoSize = true;
            this.cell_size_label.Location = new System.Drawing.Point(652, 318);
            this.cell_size_label.Name = "cell_size_label";
            this.cell_size_label.Size = new System.Drawing.Size(48, 13);
            this.cell_size_label.TabIndex = 34;
            this.cell_size_label.Text = "Cell size:";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 507);
            this.Controls.Add(this.cell_numericUpDown);
            this.Controls.Add(this.cell_size_label);
            this.Controls.Add(this.pattern_label);
            this.Controls.Add(this.pattern_comboBox);
            this.Controls.Add(this.speed_label);
            this.Controls.Add(this.speed_numericUpDown);
            this.Controls.Add(this.run_game_box);
            this.Controls.Add(this.pictureBox);
            this.MaximumSize = new System.Drawing.Size(899, 546);
            this.MinimumSize = new System.Drawing.Size(899, 546);
            this.Name = "Form";
            this.Text = "Game of Life";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox run_game_box;
        private System.Windows.Forms.NumericUpDown speed_numericUpDown;
        private System.Windows.Forms.Label speed_label;
        private System.Windows.Forms.ComboBox pattern_comboBox;
        private System.Windows.Forms.Label pattern_label;
        private System.Windows.Forms.NumericUpDown cell_numericUpDown;
        private System.Windows.Forms.Label cell_size_label;
    }
}

