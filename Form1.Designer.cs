
namespace Simulation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label8 = new System.Windows.Forms.Label();
            this.latencyUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.daysUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.maskUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.infectionUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Start = new System.Windows.Forms.Button();
            this.asymptomaticUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.vaccineUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.distanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.Lockdown = new System.Windows.Forms.Button();
            this.Freedom = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.Pandemic = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.ImmunityUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.InfectedUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.large = new System.Windows.Forms.RadioButton();
            this.medium = new System.Windows.Forms.RadioButton();
            this.small = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.latencyUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infectionUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asymptomaticUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImmunityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfectedUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "- Asymptomatic period (days):";
            // 
            // latencyUpDown
            // 
            this.latencyUpDown.Location = new System.Drawing.Point(176, 71);
            this.latencyUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.latencyUpDown.Name = "latencyUpDown";
            this.latencyUpDown.Size = new System.Drawing.Size(69, 27);
            this.latencyUpDown.TabIndex = 14;
            this.latencyUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.latencyUpDown.ValueChanged += new System.EventHandler(this.latencyUpDown_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "- Latency period (days):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = " Infection settings:";
            // 
            // daysUpDown
            // 
            this.daysUpDown.Location = new System.Drawing.Point(213, 101);
            this.daysUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.daysUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.daysUpDown.Name = "daysUpDown";
            this.daysUpDown.Size = new System.Drawing.Size(69, 27);
            this.daysUpDown.TabIndex = 11;
            this.daysUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.daysUpDown.ValueChanged += new System.EventHandler(this.daysUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "- Symptomatic period (days):";
            // 
            // maskUpDown
            // 
            this.maskUpDown.Location = new System.Drawing.Point(190, 258);
            this.maskUpDown.Name = "maskUpDown";
            this.maskUpDown.Size = new System.Drawing.Size(81, 27);
            this.maskUpDown.TabIndex = 9;
            this.maskUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.maskUpDown.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "- Mask uptake percentage:";
            // 
            // infectionUpDown
            // 
            this.infectionUpDown.Location = new System.Drawing.Point(172, 37);
            this.infectionUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.infectionUpDown.Name = "infectionUpDown";
            this.infectionUpDown.Size = new System.Drawing.Size(81, 27);
            this.infectionUpDown.TabIndex = 7;
            this.infectionUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.infectionUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "- Infection percentage:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "R_0 = ";
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(112, 460);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(98, 38);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(306, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(595, 420);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(12, 460);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(94, 38);
            this.Start.TabIndex = 0;
            this.Start.Text = "Simulate";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // asymptomaticUpDown
            // 
            this.asymptomaticUpDown.Location = new System.Drawing.Point(216, 134);
            this.asymptomaticUpDown.Name = "asymptomaticUpDown";
            this.asymptomaticUpDown.Size = new System.Drawing.Size(82, 27);
            this.asymptomaticUpDown.TabIndex = 16;
            this.asymptomaticUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.asymptomaticUpDown.ValueChanged += new System.EventHandler(this.asymptomaticUpDown_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(6, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = " Safety Guideline Settings:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "- Distance uptake percentage:\r\n";
            // 
            // vaccineUpDown
            // 
            this.vaccineUpDown.Location = new System.Drawing.Point(213, 323);
            this.vaccineUpDown.Name = "vaccineUpDown";
            this.vaccineUpDown.Size = new System.Drawing.Size(75, 27);
            this.vaccineUpDown.TabIndex = 19;
            this.vaccineUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.vaccineUpDown.ValueChanged += new System.EventHandler(this.vaccineUpDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 323);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "- Vaccine uptake percentage:";
            // 
            // distanceUpDown
            // 
            this.distanceUpDown.Location = new System.Drawing.Point(213, 291);
            this.distanceUpDown.Name = "distanceUpDown";
            this.distanceUpDown.Size = new System.Drawing.Size(78, 27);
            this.distanceUpDown.TabIndex = 21;
            this.distanceUpDown.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.distanceUpDown.ValueChanged += new System.EventHandler(this.distanceUpDown_ValueChanged);
            // 
            // Lockdown
            // 
            this.Lockdown.Enabled = false;
            this.Lockdown.Location = new System.Drawing.Point(336, 461);
            this.Lockdown.Name = "Lockdown";
            this.Lockdown.Size = new System.Drawing.Size(121, 38);
            this.Lockdown.TabIndex = 22;
            this.Lockdown.Text = "Start Lockdown\r\n";
            this.Lockdown.UseVisualStyleBackColor = true;
            this.Lockdown.Click += new System.EventHandler(this.Lockdown_Click);
            // 
            // Freedom
            // 
            this.Freedom.Enabled = false;
            this.Freedom.Location = new System.Drawing.Point(463, 461);
            this.Freedom.Name = "Freedom";
            this.Freedom.Size = new System.Drawing.Size(115, 38);
            this.Freedom.TabIndex = 23;
            this.Freedom.Text = "End Lockdown";
            this.Freedom.UseVisualStyleBackColor = true;
            this.Freedom.Click += new System.EventHandler(this.Freedom_Click);
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(584, 461);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(104, 37);
            this.Restart.TabIndex = 24;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // Pandemic
            // 
            this.Pandemic.Location = new System.Drawing.Point(216, 461);
            this.Pandemic.Name = "Pandemic";
            this.Pandemic.Size = new System.Drawing.Size(114, 37);
            this.Pandemic.TabIndex = 25;
            this.Pandemic.Text = "Call Pandemic";
            this.Pandemic.UseVisualStyleBackColor = true;
            this.Pandemic.Click += new System.EventHandler(this.Pandemic_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "- Immunity period (days):";
            // 
            // ImmunityUpDown
            // 
            this.ImmunityUpDown.Location = new System.Drawing.Point(188, 167);
            this.ImmunityUpDown.Name = "ImmunityUpDown";
            this.ImmunityUpDown.Size = new System.Drawing.Size(69, 27);
            this.ImmunityUpDown.TabIndex = 27;
            this.ImmunityUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ImmunityUpDown.ValueChanged += new System.EventHandler(this.ImmunityUpDown_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "- Number of infected:";
            // 
            // InfectedUpDown
            // 
            this.InfectedUpDown.Location = new System.Drawing.Point(166, 197);
            this.InfectedUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InfectedUpDown.Name = "InfectedUpDown";
            this.InfectedUpDown.Size = new System.Drawing.Size(79, 27);
            this.InfectedUpDown.TabIndex = 29;
            this.InfectedUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InfectedUpDown.ValueChanged += new System.EventHandler(this.InfectedUpDown_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.small);
            this.groupBox1.Controls.Add(this.large);
            this.groupBox1.Controls.Add(this.medium);
            this.groupBox1.Location = new System.Drawing.Point(7, 356);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 49);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Population Size";
            // 
            // large
            // 
            this.large.AutoSize = true;
            this.large.Location = new System.Drawing.Point(209, 23);
            this.large.Name = "large";
            this.large.Size = new System.Drawing.Size(64, 24);
            this.large.TabIndex = 2;
            this.large.Text = "large";
            this.large.UseVisualStyleBackColor = true;
            // 
            // medium
            // 
            this.medium.AutoSize = true;
            this.medium.Checked = true;
            this.medium.Location = new System.Drawing.Point(98, 23);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(85, 24);
            this.medium.TabIndex = 1;
            this.medium.TabStop = true;
            this.medium.Text = "medium";
            this.medium.UseVisualStyleBackColor = true;
            // 
            // small
            // 
            this.small.AutoSize = true;
            this.small.Location = new System.Drawing.Point(6, 23);
            this.small.Name = "small";
            this.small.Size = new System.Drawing.Size(65, 24);
            this.small.TabIndex = 3;
            this.small.TabStop = true;
            this.small.Text = "small";
            this.small.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(915, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InfectedUpDown);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ImmunityUpDown);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Pandemic);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.Freedom);
            this.Controls.Add(this.Lockdown);
            this.Controls.Add(this.distanceUpDown);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.vaccineUpDown);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.asymptomaticUpDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.latencyUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.daysUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.infectionUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Pandemic Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.latencyUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infectionUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asymptomaticUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImmunityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfectedUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown latencyUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown daysUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown maskUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown infectionUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.NumericUpDown asymptomaticUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown vaccineUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown distanceUpDown;
        private System.Windows.Forms.Button Lockdown;
        private System.Windows.Forms.Button Freedom;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button Pandemic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown ImmunityUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown InfectedUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton large;
        private System.Windows.Forms.RadioButton medium;
        private System.Windows.Forms.RadioButton small;
    }
}

