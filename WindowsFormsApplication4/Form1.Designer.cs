namespace WindowsFormsApplication4
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.p_tools = new System.Windows.Forms.Panel();
            this.b_fill = new System.Windows.Forms.Button();
            this.p_Shape_fill = new System.Windows.Forms.Panel();
            this.b_Shape_both = new System.Windows.Forms.Button();
            this.b_Shape_fill = new System.Windows.Forms.Button();
            this.b_Shape_border = new System.Windows.Forms.Button();
            this.hSB_Alpha = new System.Windows.Forms.HScrollBar();
            this.b_pick_color = new System.Windows.Forms.Button();
            this.b_text = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.p_Color2 = new System.Windows.Forms.Panel();
            this.b_pen = new System.Windows.Forms.Button();
            this.b_rect = new System.Windows.Forms.Button();
            this.p_Color = new System.Windows.Forms.Panel();
            this.b_line = new System.Windows.Forms.Button();
            this.pB_canvas = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.t_Graphic = new System.Windows.Forms.Timer(this.components);
            this.p_canvas = new System.Windows.Forms.Panel();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.p_tools.SuspendLayout();
            this.p_Shape_fill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_canvas)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.p_canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_tools
            // 
            this.p_tools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_tools.Controls.Add(this.b_fill);
            this.p_tools.Controls.Add(this.p_Shape_fill);
            this.p_tools.Controls.Add(this.hSB_Alpha);
            this.p_tools.Controls.Add(this.b_pick_color);
            this.p_tools.Controls.Add(this.b_text);
            this.p_tools.Controls.Add(this.trackBar1);
            this.p_tools.Controls.Add(this.p_Color2);
            this.p_tools.Controls.Add(this.b_pen);
            this.p_tools.Controls.Add(this.b_rect);
            this.p_tools.Controls.Add(this.p_Color);
            this.p_tools.Controls.Add(this.b_line);
            this.p_tools.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_tools.Location = new System.Drawing.Point(0, 27);
            this.p_tools.Name = "p_tools";
            this.p_tools.Size = new System.Drawing.Size(215, 484);
            this.p_tools.TabIndex = 0;
            // 
            // b_fill
            // 
            this.b_fill.Location = new System.Drawing.Point(11, 15);
            this.b_fill.Name = "b_fill";
            this.b_fill.Size = new System.Drawing.Size(75, 23);
            this.b_fill.TabIndex = 12;
            this.b_fill.TabStop = false;
            this.b_fill.Text = "Wypełnij";
            this.b_fill.UseVisualStyleBackColor = true;
            this.b_fill.MouseClick += new System.Windows.Forms.MouseEventHandler(this.b_fill_Click);
            // 
            // p_Shape_fill
            // 
            this.p_Shape_fill.AutoScroll = true;
            this.p_Shape_fill.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.p_Shape_fill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p_Shape_fill.Controls.Add(this.b_Shape_both);
            this.p_Shape_fill.Controls.Add(this.b_Shape_fill);
            this.p_Shape_fill.Controls.Add(this.b_Shape_border);
            this.p_Shape_fill.Location = new System.Drawing.Point(11, 255);
            this.p_Shape_fill.Name = "p_Shape_fill";
            this.p_Shape_fill.Size = new System.Drawing.Size(196, 69);
            this.p_Shape_fill.TabIndex = 10;
            // 
            // b_Shape_both
            // 
            this.b_Shape_both.BackColor = System.Drawing.Color.Gray;
            this.b_Shape_both.FlatAppearance.BorderSize = 5;
            this.b_Shape_both.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Shape_both.Location = new System.Drawing.Point(129, 3);
            this.b_Shape_both.Name = "b_Shape_both";
            this.b_Shape_both.Size = new System.Drawing.Size(60, 60);
            this.b_Shape_both.TabIndex = 2;
            this.b_Shape_both.TabStop = false;
            this.b_Shape_both.UseVisualStyleBackColor = false;
            this.b_Shape_both.Click += new System.EventHandler(this.b_Shape_both_Click);
            // 
            // b_Shape_fill
            // 
            this.b_Shape_fill.BackColor = System.Drawing.Color.Gray;
            this.b_Shape_fill.FlatAppearance.BorderSize = 0;
            this.b_Shape_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Shape_fill.Location = new System.Drawing.Point(66, 3);
            this.b_Shape_fill.Name = "b_Shape_fill";
            this.b_Shape_fill.Size = new System.Drawing.Size(60, 60);
            this.b_Shape_fill.TabIndex = 1;
            this.b_Shape_fill.TabStop = false;
            this.b_Shape_fill.UseVisualStyleBackColor = false;
            this.b_Shape_fill.Click += new System.EventHandler(this.b_Shape_fill_Click);
            // 
            // b_Shape_border
            // 
            this.b_Shape_border.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.b_Shape_border.FlatAppearance.BorderSize = 5;
            this.b_Shape_border.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Shape_border.Location = new System.Drawing.Point(3, 3);
            this.b_Shape_border.Name = "b_Shape_border";
            this.b_Shape_border.Size = new System.Drawing.Size(60, 60);
            this.b_Shape_border.TabIndex = 0;
            this.b_Shape_border.TabStop = false;
            this.b_Shape_border.UseVisualStyleBackColor = true;
            this.b_Shape_border.Click += new System.EventHandler(this.b_Shape_border_Click);
            // 
            // hSB_Alpha
            // 
            this.hSB_Alpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hSB_Alpha.Location = new System.Drawing.Point(11, 340);
            this.hSB_Alpha.Maximum = 255;
            this.hSB_Alpha.Name = "hSB_Alpha";
            this.hSB_Alpha.Size = new System.Drawing.Size(191, 21);
            this.hSB_Alpha.TabIndex = 9;
            this.hSB_Alpha.Value = 255;
            this.hSB_Alpha.ValueChanged += new System.EventHandler(this.hSB_Alpha_ValueChanged);
            // 
            // b_pick_color
            // 
            this.b_pick_color.Location = new System.Drawing.Point(92, 73);
            this.b_pick_color.Name = "b_pick_color";
            this.b_pick_color.Size = new System.Drawing.Size(75, 23);
            this.b_pick_color.TabIndex = 8;
            this.b_pick_color.TabStop = false;
            this.b_pick_color.Text = "Próbnik";
            this.b_pick_color.UseVisualStyleBackColor = true;
            this.b_pick_color.Click += new System.EventHandler(this.b_pick_color_Click);
            // 
            // b_text
            // 
            this.b_text.Location = new System.Drawing.Point(11, 73);
            this.b_text.Name = "b_text";
            this.b_text.Size = new System.Drawing.Size(75, 23);
            this.b_text.TabIndex = 7;
            this.b_text.TabStop = false;
            this.b_text.Text = "Tekst";
            this.b_text.UseVisualStyleBackColor = true;
            this.b_text.MouseClick += new System.Windows.Forms.MouseEventHandler(this.b_text_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar1.Location = new System.Drawing.Point(11, 364);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(191, 56);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // p_Color2
            // 
            this.p_Color2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p_Color2.BackColor = System.Drawing.Color.White;
            this.p_Color2.Location = new System.Drawing.Point(92, 426);
            this.p_Color2.Name = "p_Color2";
            this.p_Color2.Size = new System.Drawing.Size(75, 45);
            this.p_Color2.TabIndex = 5;
            this.p_Color2.Click += new System.EventHandler(this.p_Color2_Click);
            // 
            // b_pen
            // 
            this.b_pen.Location = new System.Drawing.Point(92, 44);
            this.b_pen.Name = "b_pen";
            this.b_pen.Size = new System.Drawing.Size(75, 23);
            this.b_pen.TabIndex = 4;
            this.b_pen.TabStop = false;
            this.b_pen.Text = "Ołówek";
            this.b_pen.UseVisualStyleBackColor = true;
            this.b_pen.Click += new System.EventHandler(this.b_pen_Click);
            // 
            // b_rect
            // 
            this.b_rect.Location = new System.Drawing.Point(11, 44);
            this.b_rect.Name = "b_rect";
            this.b_rect.Size = new System.Drawing.Size(75, 23);
            this.b_rect.TabIndex = 3;
            this.b_rect.TabStop = false;
            this.b_rect.Text = "Prostokąt";
            this.b_rect.UseVisualStyleBackColor = true;
            this.b_rect.Click += new System.EventHandler(this.b_rect_Click);
            // 
            // p_Color
            // 
            this.p_Color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p_Color.BackColor = System.Drawing.Color.Black;
            this.p_Color.Location = new System.Drawing.Point(11, 426);
            this.p_Color.Name = "p_Color";
            this.p_Color.Size = new System.Drawing.Size(75, 45);
            this.p_Color.TabIndex = 2;
            this.p_Color.Click += new System.EventHandler(this.panel1_Click);
            // 
            // b_line
            // 
            this.b_line.Location = new System.Drawing.Point(92, 15);
            this.b_line.Name = "b_line";
            this.b_line.Size = new System.Drawing.Size(75, 23);
            this.b_line.TabIndex = 1;
            this.b_line.TabStop = false;
            this.b_line.Text = "Linia";
            this.b_line.UseVisualStyleBackColor = true;
            this.b_line.Click += new System.EventHandler(this.b_line_Click);
            // 
            // pB_canvas
            // 
            this.pB_canvas.BackColor = System.Drawing.Color.Transparent;
            this.pB_canvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pB_canvas.Location = new System.Drawing.Point(33, 45);
            this.pB_canvas.Name = "pB_canvas";
            this.pB_canvas.Size = new System.Drawing.Size(378, 411);
            this.pB_canvas.TabIndex = 1;
            this.pB_canvas.TabStop = false;
            this.pB_canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pB_canvas_MouseDown);
            this.pB_canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pB_canvas_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(667, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // t_Graphic
            // 
            this.t_Graphic.Enabled = true;
            this.t_Graphic.Interval = 16;
            this.t_Graphic.Tick += new System.EventHandler(this.t_Graphic_Tick);
            // 
            // p_canvas
            // 
            this.p_canvas.AutoScroll = true;
            this.p_canvas.BackColor = System.Drawing.Color.DimGray;
            this.p_canvas.Controls.Add(this.pB_canvas);
            this.p_canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_canvas.Location = new System.Drawing.Point(215, 27);
            this.p_canvas.Name = "p_canvas";
            this.p_canvas.Size = new System.Drawing.Size(452, 484);
            this.p_canvas.TabIndex = 3;
            this.p_canvas.SizeChanged += new System.EventHandler(this.p_canvas_SizeChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 511);
            this.Controls.Add(this.p_canvas);
            this.Controls.Add(this.p_tools);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.p_tools.ResumeLayout(false);
            this.p_tools.PerformLayout();
            this.p_Shape_fill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_canvas)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.p_canvas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_tools;
        private System.Windows.Forms.Button b_line;
        private System.Windows.Forms.PictureBox pB_canvas;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Timer t_Graphic;
        private System.Windows.Forms.Panel p_Color;
        private System.Windows.Forms.Button b_rect;
        private System.Windows.Forms.Panel p_canvas;
        private System.Windows.Forms.Button b_pen;
        private System.Windows.Forms.Panel p_Color2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button b_text;
        private System.Windows.Forms.Button b_pick_color;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.HScrollBar hSB_Alpha;
        private System.Windows.Forms.Panel p_Shape_fill;
        private System.Windows.Forms.Button b_Shape_both;
        private System.Windows.Forms.Button b_Shape_fill;
        private System.Windows.Forms.Button b_Shape_border;
        private System.Windows.Forms.Button b_fill;
    }
}

