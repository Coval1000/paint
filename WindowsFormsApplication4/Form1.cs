using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        enum Utility
        {
            None,
            Grab,
            Lines,
            Rectangle,
            Pen,
            Text,
            Color_Picker
        }

        enum Complex
        {
            TwoPoints,
            FourPoints,
            RealTime,
            Select,
            Fill,
            None
        }

        enum Mode
        {
            Border,Fill,Both
        }

        private class Vectoral
        {
            private Utility _tool;
            public Utility tool
            {
                get { return _tool; }
                set
                {
                    _tool = value;
                    _stage = 0;
                    points.Clear();
                }
            }
            public Mode mode;
            public List<PointF> points;
            public Color color;
            public Color color2;
            private int _stage;
            public int stage
            {
                get { return _stage; }
            }

            public Vectoral(PointF p1, PointF p2)
            {
                points = new List<PointF>(new PointF[] {p1, p2});
                _stage = 0;
            }

            public Vectoral()
            {
                points = new List<PointF>();
                _stage = 0;
            }

            public void Input(PointF p, bool onDown = false, MouseEventArgs e = null)
            {
                switch (_tool)
                {
                    case Utility.Color_Picker:
                        break;
                    case Utility.Lines:
                        if(points.Count<2)
                        {
                            points.Add(p);
                        }
                        break;
                    case Utility.Pen:
                        points.Add(p);
                        break;
                    case Utility.Rectangle:
                        if (points.Count < 2)
                        {
                            points.Add(p);
                        }
                        break;
                    case Utility.Text:
                        if (points.Count < 2)
                        {
                            points.Add(p);
                        }
                        break;
                    default:
                        throw new Exception("Unknown utility case on Vector.Input =" + _tool.ToString());
                }
            }

            public void flat()
            {
                if (points.Count < 2) return;

                Graphics g = Graphics.FromImage(flatten);

                Pen pen = new Pen(color, line_thickness);
                SolidBrush brush = new SolidBrush(color2);

                switch (_tool)
                {
                    case Utility.Lines:
                        g.DrawLine(pen, points[0], points[1]);
                        break;

                    case Utility.Rectangle:
                        pen.Alignment = PenAlignment.Inset;
                        if (mode == Mode.Fill)
                        {
                            g.FillRectangle(brush, points[0].X < points[1].X ? points[0].X : points[1].X,
                            points[0].Y < points[1].Y ? points[0].Y : points[1].Y,
                            Math.Abs(points[0].X - points[1].X),
                            Math.Abs(points[0].Y - points[1].Y));
                        }
                        if (mode == Mode.Both)
                        {
                            g.FillRectangle(brush, points[0].X < points[1].X ? points[0].X + line_thickness : points[1].X + line_thickness,
                            points[0].Y < points[1].Y ? points[0].Y + line_thickness : points[1].Y + line_thickness,
                            Math.Abs(points[0].X - points[1].X)+1 - 2 * line_thickness,
                            Math.Abs(points[0].Y - points[1].Y)+1 - 2 * line_thickness);
                        }
                        if (mode == Mode.Border || mode == Mode.Both)
                            g.DrawRectangle(pen, points[0].X < points[1].X ? points[0].X : points[1].X,
                                points[0].Y < points[1].Y ? points[0].Y : points[1].Y,
                                Math.Abs(points[0].X - points[1].X),
                                Math.Abs(points[0].Y - points[1].Y));
                        break;

                    case Utility.Pen:
                        if (points.Count > 1)
                            g.DrawLines(pen, points.ToArray());
                        points.Clear();
                        break;

                    case Utility.Text:
                        if(_stage == 1)
                        {
                            g.DrawString(text, new Font("Arial", 10), pen.Brush,
                                    new RectangleF(points[0].X < points[1].X ? points[0].X : points[1].X,
                                                    points[0].Y < points[1].Y ? points[0].Y : points[1].Y,
                                                    Math.Abs(points[0].X - points[1].X),
                                                    Math.Abs(points[0].Y - points[1].Y)));
                            text = "";
                            _stage = 0;
                        }
                        else if(_stage == 0)
                        {
                            _stage = 1;
                        }
                        break;
                }
            }
        }

        static private Bitmap flatten;

        private Color primary_color
        {
            get
            {
                return Color.FromArgb(hSB_Alpha.Value,p_Color.BackColor);
            }
            set
            {
                p_Color.BackColor = value;

                b_Shape_border.FlatAppearance.BorderColor = value;
                b_Shape_both.FlatAppearance.BorderColor = value;
                try { vect.color = Color.FromArgb(hSB_Alpha.Value, value); }
                catch { }
            }

        }
        private Color secondary_color
        {
            get { return Color.FromArgb(hSB_Alpha.Value, p_Color2.BackColor); }
            set
            {
                p_Color2.BackColor = value;

                b_Shape_fill.BackColor = value;
                b_Shape_both.BackColor = value;
                try { vect.color2 = Color.FromArgb(hSB_Alpha.Value, value); }
                catch { }
            }

        }

        static private float line_thickness;

        private Bitmap buffor;
        private Bitmap background;
        private List<Bitmap> layers;
        private List<Vectoral> lines;
        private Utility _drawing_mode;
        private Complex drawing_complex;
        private PointF onDown;
        private PointF onUp;
        private PointF possFix;

        private RectangleF selected;
        private Utility drawing_mode
        {
            get { return _drawing_mode; }
            set
            {
                _drawing_mode = value;
                vect.tool = value;
                
                switch(value)
                {
                    case Utility.Lines:
                    case Utility.Rectangle:
                        drawing_complex = Complex.TwoPoints;
                        break;
                    case Utility.Pen:
                        drawing_complex = Complex.RealTime;
                        break;
                    case Utility.Text:
                    case Utility.Grab:
                        drawing_complex = Complex.Select;
                        break;
                    case Utility.Color_Picker:
                        drawing_complex = Complex.None;
                        break;
                }
            }
        }
        private Mode mode
        {
            get
            {
                if (b_Shape_both.Enabled)
                    if (b_Shape_fill.Enabled)
                        return Mode.Border;
                    else return Mode.Fill;
                else return Mode.Both;
            }
            set
            {
                switch(value)
                {
                    case Mode.Both:
                        b_Shape_border.Enabled = true;
                        b_Shape_both.Enabled = false;
                        b_Shape_fill.Enabled = true;
                        break;
                    case Mode.Fill:
                        b_Shape_border.Enabled = true;
                        b_Shape_both.Enabled = true;
                        b_Shape_fill.Enabled = false;
                        break;
                    case Mode.Border:
                        b_Shape_border.Enabled = false;
                        b_Shape_both.Enabled = true;
                        b_Shape_fill.Enabled = true;
                        break;
                }
                vect.mode = value;
            }
        }
        private Vectoral vect;

        static private string text;

        private bool lmb;
        private bool rmb;
        private bool mmb;
        //
        //Constructor
        //
        public Form1()
        {
            vect = new Vectoral();
            InitializeComponent();
            flatten = new Bitmap(pB_canvas.Width, pB_canvas.Height);
            layers = new List<Bitmap>();
            lines = new List<Vectoral>();
            primary_color = Color.Black;
            pB_canvas.Image = buffor;
            line_thickness = 1;
            
            saveFileDialog1.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            drawing_mode = Utility.Lines;


            background = new Bitmap(pB_canvas.Width, pB_canvas.Height);
            Graphics g = Graphics.FromImage(background);
            SolidBrush s1 = new SolidBrush(Color.Silver);
            SolidBrush s2 = new SolidBrush(Color.DarkGray);
            g.FillRectangle(s1, new Rectangle(0, 0, pB_canvas.Width, pB_canvas.Height));
            for (int y = 0; y < pB_canvas.Height ; y +=5)
            {
                for (int x = 0; x < pB_canvas.Width; x += 10)
                {
                    g.FillRectangle(s2, new Rectangle(y%10 == 0 ? x : x+5, y, 5, 5));
                }
            }
            s1.Dispose();
            s2.Dispose();
            g.Dispose();
            pB_canvas.BackgroundImage = background;
        }
        //
        //Methods
        //  
        private void t_Graphic_Tick(object sender, EventArgs e)
        {
            if (lmb)
            {
                draw_buffor();
            }
        }

        private void pB_canvas_MouseDown(object sender, MouseEventArgs e)
        {
            onDown = e.Location;
            possFix = new PointF(e.X - MousePosition.X, e.Y - MousePosition.Y);
            switch (e.Button)
            {
                case MouseButtons.Left:
                    lmb = true;
                    if (drawing_mode == Utility.Text && vect.stage == 1)
                    {
                        vect.flat();
                    }
                    break;
                case MouseButtons.Right:
                    rmb = true;
                    break;
                case MouseButtons.Middle:
                    mmb = true;
                    break;
            }
            
        }

        private void pB_canvas_MouseUp(object sender, MouseEventArgs e)
        {
            onUp = e.Location;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    lmb = false;
                    break;
                case MouseButtons.Right:
                    rmb = false;
                    break;
                case MouseButtons.Middle:
                    mmb = false;
                    break;
            }
            lines.Add(new Vectoral(onDown, onUp));
            vect.flat();
        }

        private void draw_buffor()
        {
            buffor?.Dispose();

            buffor = flatten.Clone(new Rectangle(0, 0, flatten.Width, flatten.Height),
                flatten.PixelFormat);

            Graphics g = Graphics.FromImage(buffor);
            

            Pen pen = new Pen(primary_color, line_thickness);
            SolidBrush brush = new SolidBrush(secondary_color);
            //
            //Modes
            //
            switch (drawing_complex)
            {
                //TwoPoints
                case Complex.TwoPoints:
                    vect.points.Clear();
                    vect.Input(onDown);
                    vect.Input(new PointF(MousePosition.X + possFix.X,
                                          MousePosition.Y + possFix.Y));
                    switch (drawing_mode)
                    {
                        case Utility.Lines:
                            g.DrawLine(pen, vect.points[0], vect.points[1]);
                            break;

                        case Utility.Rectangle:
                            pen.Alignment = PenAlignment.Inset;
                            if(mode == Mode.Fill )
                            {
                                g.FillRectangle(brush, vect.points[0].X < vect.points[1].X ? vect.points[0].X : vect.points[1].X,
                                vect.points[0].Y < vect.points[1].Y ? vect.points[0].Y : vect.points[1].Y,
                                Math.Abs(vect.points[0].X - vect.points[1].X),
                                Math.Abs(vect.points[0].Y - vect.points[1].Y));
                            }
                            if(mode == Mode.Both)
                            {
                                g.FillRectangle(brush, vect.points[0].X < vect.points[1].X ? vect.points[0].X + line_thickness : vect.points[1].X + line_thickness,
                                vect.points[0].Y < vect.points[1].Y ? vect.points[0].Y + line_thickness : vect.points[1].Y + line_thickness,
                                Math.Abs(vect.points[0].X - vect.points[1].X)+1 - 2 * line_thickness,
                                Math.Abs(vect.points[0].Y - vect.points[1].Y)+1 - 2 * line_thickness);
                            }
                            if(mode == Mode.Border || mode == Mode.Both)                     
                            g.DrawRectangle(pen, vect.points[0].X < vect.points[1].X ? vect.points[0].X : vect.points[1].X,
                                vect.points[0].Y < vect.points[1].Y ? vect.points[0].Y : vect.points[1].Y,
                                Math.Abs(vect.points[0].X - vect.points[1].X),
                                Math.Abs(vect.points[0].Y - vect.points[1].Y));
                            break;
                    }
                    break;

                
                //RealTime
                case Complex.RealTime:

                    this.vect.Input(new PointF(MousePosition.X + possFix.X,
                                                            MousePosition.Y + possFix.Y));

                    switch (drawing_mode)
                    {
                        case Utility.Pen:
                            if (this.vect.points.Count > 1)
                                g.DrawLines(pen, this.vect.points.ToArray());
                            break;
                    }

                    break;

                case Complex.Fill:

                    fill(ref flatten, (int)(MousePosition.X + possFix.X), (int)(MousePosition.Y + possFix.Y));

                    break;
                
                //None
                case Complex.None:

                    switch (drawing_mode)
                    {
                        case Utility.Color_Picker:
                            primary_color = flatten.GetPixel((int)onDown.X, (int)onDown.Y);
                            break;
                    }

                    break;
                
                //Select
                case Complex.Select:

                    switch(drawing_mode)
                    {
                        case Utility.Text:
                            Pen pen1 = new Pen(Color.Black, 1.5f);
                            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                            if (vect.stage == 0)
                            {
                                vect.points.Clear();
                                vect.Input(onDown);
                                vect.Input(new PointF(MousePosition.X + possFix.X,
                                                      MousePosition.Y + possFix.Y));  
                            }
                            g.DrawRectangle(pen1, vect.points[0].X < vect.points[1].X ? vect.points[0].X : vect.points[1].X,
                                    vect.points[0].Y < vect.points[1].Y ? vect.points[0].Y : vect.points[1].Y,
                                    Math.Abs(vect.points[0].X - vect.points[1].X),
                                    Math.Abs(vect.points[0].Y - vect.points[1].Y));

                            if (vect.stage == 1)
                            {
                                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                                g.DrawString(text, new Font("Arial", 10), pen.Brush,
                                    new RectangleF(vect.points[0].X < vect.points[1].X ? vect.points[0].X : vect.points[1].X,
                                                    vect.points[0].Y < vect.points[1].Y ? vect.points[0].Y : vect.points[1].Y,
                                                    Math.Abs(vect.points[0].X - vect.points[1].X),
                                                    Math.Abs(vect.points[0].Y - vect.points[1].Y)));
                            }

                            break;
                    }

                    break;

            }



            pB_canvas.Image = buffor;
            g.Dispose();
            pen.Dispose();
            brush.Dispose();

        }

        private void fill(ref Bitmap bm, int x, int y)
        {
            Color c = bm.GetPixel(x, y);

            if (primary_color != c)
            bm.SetPixel(x, y, primary_color);

            if (x < bm.Width - 1 && c == bm.GetPixel(x + 1, y))
            {
                fill(ref bm, x + 1, y);
                return;
            }
            if (x > 0 && c == bm.GetPixel(x - 1, y))
            {
                fill(ref bm, x - 1, y);
                return;
            }
            if (y < bm.Height - 1 && c == bm.GetPixel(x, y + 1))
            {
                fill(ref bm, x, y + 1);
                return;
            }
            if (y > 0 && c == bm.GetPixel(x, y - 1))
            {
                fill(ref bm, x, y - 1);
                return;
            }

            

        }
        //
        //Tools
        //
        #region Tools
        private void panel1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                primary_color = colorDialog1.Color;
            }
        }

        private void b_rect_Click(object sender, EventArgs e)
        {
            drawing_mode = Utility.Rectangle;
        }

        private void b_Grab_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(flatten);
            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);
            Pen bluePen = new Pen(Color.Blue, 3);

            // Create points that define curve.
            Point point1 = new Point(50, 100);
            Point point2 = new Point(100, 50);
            Point point3 = new Point(200, 10);
            Point point4 = new Point(250, 100);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints = { point1, point2, point3, point4, point5, point6, point7 };

            // Draw lines between original points to screen.
            g.DrawLines(redPen, curvePoints);

            // Draw curve to screen.
            g.DrawCurve(greenPen, curvePoints);

            g.DrawCurve(bluePen, curvePoints,2);

            pB_canvas.Image = flatten;
        }

        private void b_line_Click(object sender, EventArgs e)
        {
            drawing_mode = Utility.Lines;
        }

        private void b_pen_Click(object sender, EventArgs e)
        {
            drawing_mode = Utility.Pen;
        }

        private void p_Color2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                secondary_color = colorDialog1.Color;
            }
        }
        #endregion

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            line_thickness = trackBar1.Value;
        }

        private void b_pick_color_Click(object sender, EventArgs e)
        {
            drawing_mode = Utility.Color_Picker;
        }

        private void b_text_Click(object sender, EventArgs e)
        {
            drawing_mode = Utility.Text;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (vect.stage == 1 && vect.tool == Utility.Text)
            {
                if (e.KeyChar == '\b')
                {
                    if(text.Length > 0)
                    text = text.Remove(text.Length - 1);
                }
                else text += e.KeyChar;
                draw_buffor();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                flatten.Save(saveFileDialog1.FileName);
            }
        }


        private void b_Shape_fill_Click(object sender, EventArgs e)
        {
            mode = Mode.Fill;
        }

        private void b_Shape_border_Click(object sender, EventArgs e)
        {
            mode = Mode.Border;
        }

        private void b_Shape_both_Click(object sender, EventArgs e)
        {
            mode = Mode.Both;
        }

        private void p_canvas_SizeChanged(object sender, EventArgs e)
        {
            pB_canvas.Location = new Point((p_canvas.Width - pB_canvas.Width)/2, 
                (p_canvas.Height - pB_canvas.Height) / 2);
        }

        private void hSB_Alpha_ValueChanged(object sender, EventArgs e)
        {
            vect.color = Color.FromArgb(hSB_Alpha.Value, vect.color.R, vect.color.G, vect.color.B);
            vect.color2 = Color.FromArgb(hSB_Alpha.Value, vect.color2.R, vect.color2.G, vect.color2.B);
        }

        private void b_fill_Click(object sender, EventArgs e)
        {
            drawing_complex = Complex.Fill;
        }
    }
}
