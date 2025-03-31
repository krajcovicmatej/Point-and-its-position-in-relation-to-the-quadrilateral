namespace Krajcovic_Matej
{
    partial class MainForm_EN
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slovakToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm_EN));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slovakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_result = new System.Windows.Forms.Label();
            this.panelCanvas_1 = new System.Windows.Forms.Panel();
            this.Inputs = new System.Windows.Forms.GroupBox();
            this.PY_1 = new System.Windows.Forms.NumericUpDown();
            this.PX_1 = new System.Windows.Forms.NumericUpDown();
            this.DY_1 = new System.Windows.Forms.NumericUpDown();
            this.DX_1 = new System.Windows.Forms.NumericUpDown();
            this.CY_1 = new System.Windows.Forms.NumericUpDown();
            this.CX_1 = new System.Windows.Forms.NumericUpDown();
            this.BY_1 = new System.Windows.Forms.NumericUpDown();
            this.BX_1 = new System.Windows.Forms.NumericUpDown();
            this.AY_1 = new System.Windows.Forms.NumericUpDown();
            this.AX_1 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.Inputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PY_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PX_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DY_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DX_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CY_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CX_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BY_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BX_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AY_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AX_1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.slovakToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // slovakToolStripMenuItem
            // 
            this.slovakToolStripMenuItem.Name = "slovakToolStripMenuItem";
            this.slovakToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.slovakToolStripMenuItem.Text = "Slovak";
            this.slovakToolStripMenuItem.Click += new System.EventHandler(this.slovakToolStripMenuItem_Click);
            // 
            // lbl_result
            // 
            this.lbl_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_result.Location = new System.Drawing.Point(327, 512);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(449, 34);
            this.lbl_result.TabIndex = 1;
            this.lbl_result.Text = "Result";
            this.lbl_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCanvas_1
            // 
            this.panelCanvas_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCanvas_1.Location = new System.Drawing.Point(327, 40);
            this.panelCanvas_1.Name = "panelCanvas_1";
            this.panelCanvas_1.Size = new System.Drawing.Size(450, 450);
            this.panelCanvas_1.TabIndex = 2;
            this.panelCanvas_1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            // 
            // Inputs
            // 
            this.Inputs.Controls.Add(this.PY_1);
            this.Inputs.Controls.Add(this.PX_1);
            this.Inputs.Controls.Add(this.DY_1);
            this.Inputs.Controls.Add(this.DX_1);
            this.Inputs.Controls.Add(this.CY_1);
            this.Inputs.Controls.Add(this.CX_1);
            this.Inputs.Controls.Add(this.BY_1);
            this.Inputs.Controls.Add(this.BX_1);
            this.Inputs.Controls.Add(this.AY_1);
            this.Inputs.Controls.Add(this.AX_1);
            this.Inputs.Controls.Add(this.label15);
            this.Inputs.Controls.Add(this.label14);
            this.Inputs.Controls.Add(this.label13);
            this.Inputs.Controls.Add(this.label12);
            this.Inputs.Controls.Add(this.label11);
            this.Inputs.Controls.Add(this.label10);
            this.Inputs.Controls.Add(this.label9);
            this.Inputs.Controls.Add(this.label8);
            this.Inputs.Controls.Add(this.label7);
            this.Inputs.Controls.Add(this.label6);
            this.Inputs.Controls.Add(this.label5);
            this.Inputs.Controls.Add(this.label4);
            this.Inputs.Controls.Add(this.label3);
            this.Inputs.Controls.Add(this.label2);
            this.Inputs.Controls.Add(this.label1);
            this.Inputs.Location = new System.Drawing.Point(12, 40);
            this.Inputs.Name = "Inputs";
            this.Inputs.Size = new System.Drawing.Size(257, 418);
            this.Inputs.TabIndex = 27;
            this.Inputs.TabStop = false;
            // 
            // PY_1
            // 
            this.PY_1.DecimalPlaces = 2;
            this.PY_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.PY_1.Location = new System.Drawing.Point(103, 361);
            this.PY_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.PY_1.Name = "PY_1";
            this.PY_1.Size = new System.Drawing.Size(79, 20);
            this.PY_1.TabIndex = 60;
            this.PY_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PY_1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // PX_1
            // 
            this.PX_1.DecimalPlaces = 2;
            this.PX_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.PX_1.Location = new System.Drawing.Point(104, 332);
            this.PX_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.PX_1.Name = "PX_1";
            this.PX_1.Size = new System.Drawing.Size(79, 20);
            this.PX_1.TabIndex = 59;
            this.PX_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PX_1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // DY_1
            // 
            this.DY_1.DecimalPlaces = 2;
            this.DY_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.DY_1.Location = new System.Drawing.Point(104, 279);
            this.DY_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.DY_1.Name = "DY_1";
            this.DY_1.Size = new System.Drawing.Size(79, 20);
            this.DY_1.TabIndex = 58;
            this.DY_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DY_1.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // DX_1
            // 
            this.DX_1.DecimalPlaces = 2;
            this.DX_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.DX_1.Location = new System.Drawing.Point(104, 250);
            this.DX_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.DX_1.Name = "DX_1";
            this.DX_1.Size = new System.Drawing.Size(79, 20);
            this.DX_1.TabIndex = 57;
            this.DX_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DX_1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // CY_1
            // 
            this.CY_1.DecimalPlaces = 2;
            this.CY_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CY_1.Location = new System.Drawing.Point(104, 191);
            this.CY_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.CY_1.Name = "CY_1";
            this.CY_1.Size = new System.Drawing.Size(79, 20);
            this.CY_1.TabIndex = 56;
            this.CY_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CY_1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // CX_1
            // 
            this.CX_1.DecimalPlaces = 2;
            this.CX_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CX_1.Location = new System.Drawing.Point(103, 165);
            this.CX_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.CX_1.Name = "CX_1";
            this.CX_1.Size = new System.Drawing.Size(79, 20);
            this.CX_1.TabIndex = 55;
            this.CX_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CX_1.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // BY_1
            // 
            this.BY_1.DecimalPlaces = 2;
            this.BY_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.BY_1.Location = new System.Drawing.Point(104, 115);
            this.BY_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.BY_1.Name = "BY_1";
            this.BY_1.Size = new System.Drawing.Size(79, 20);
            this.BY_1.TabIndex = 54;
            this.BY_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BY_1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // BX_1
            // 
            this.BX_1.DecimalPlaces = 2;
            this.BX_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.BX_1.Location = new System.Drawing.Point(104, 89);
            this.BX_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.BX_1.Name = "BX_1";
            this.BX_1.Size = new System.Drawing.Size(79, 20);
            this.BX_1.TabIndex = 53;
            this.BX_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BX_1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // AY_1
            // 
            this.AY_1.DecimalPlaces = 2;
            this.AY_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.AY_1.Location = new System.Drawing.Point(104, 45);
            this.AY_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.AY_1.Name = "AY_1";
            this.AY_1.Size = new System.Drawing.Size(79, 20);
            this.AY_1.TabIndex = 52;
            this.AY_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AY_1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // AX_1
            // 
            this.AX_1.DecimalPlaces = 2;
            this.AX_1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.AX_1.Location = new System.Drawing.Point(103, 17);
            this.AX_1.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.AX_1.Name = "AX_1";
            this.AX_1.Size = new System.Drawing.Size(79, 20);
            this.AX_1.TabIndex = 51;
            this.AX_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AX_1.Value = new decimal(new int[] {
            10000,
            0,
            0,
            131072});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 334);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 50;
            this.label15.Text = "Point P";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(77, 363);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Y :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(77, 337);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "X :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(77, 281);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Y :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 255);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "X :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(77, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Y :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "X :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Point D";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Point C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Point B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Y :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "X :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Y :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "X :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Point A";
            // 
            // MainForm_EN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(804, 561);
            this.Controls.Add(this.Inputs);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lbl_result);
            this.Controls.Add(this.panelCanvas_1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm_EN";
            this.Text = "Point and Quadrilateral";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_EN_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_EN_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Inputs.ResumeLayout(false);
            this.Inputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PY_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PX_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DY_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DX_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CY_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CX_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BY_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BX_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AY_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AX_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Inputs;
        private System.Windows.Forms.NumericUpDown PY_1;
        private System.Windows.Forms.NumericUpDown PX_1;
        private System.Windows.Forms.NumericUpDown DY_1;
        private System.Windows.Forms.NumericUpDown DX_1;
        private System.Windows.Forms.NumericUpDown CY_1;
        private System.Windows.Forms.NumericUpDown CX_1;
        private System.Windows.Forms.NumericUpDown BY_1;
        private System.Windows.Forms.NumericUpDown BX_1;
        private System.Windows.Forms.NumericUpDown AY_1;
        private System.Windows.Forms.NumericUpDown AX_1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
