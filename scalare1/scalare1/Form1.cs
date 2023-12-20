namespace scalare1
{
    public partial class Form1 : Form
    {

        private float scaleX = 1.0f;
        private float scaleY = 1.0f;
        public Form1()
        {
            InitializeComponent();
            Scalling();
        }

        private void Scalling()
        {
            this.Text = "Scaling Circle";
            this.Size = new Size(1000, 1000);

            TextBox txtScaleX = new TextBox();
            txtScaleX.Location = new Point(20, 20);
            txtScaleX.Size = new Size(50, 20);
            this.Controls.Add(txtScaleX);

            TextBox txtScaleY = new TextBox();
            txtScaleY.Location = new Point(90, 20);
            txtScaleY.Size = new Size(50, 20);
            this.Controls.Add(txtScaleY);

            Button btnScale = new Button();
            btnScale.Location = new Point(160, 20);
            btnScale.Size = new Size(80, 30);
            btnScale.Text = "Scale Circle";
            btnScale.Click += new EventHandler(btnScale_Click);
            this.Controls.Add(btnScale);

            this.Paint += new PaintEventHandler(this.DrawScaledCircle);
        }


        private void btnScale_Click(object sender, EventArgs e)
        {
            if (float.TryParse(((TextBox)Controls[0]).Text, out float x) && float.TryParse(((TextBox)Controls[1]).Text, out float y))
            {
                scaleX = x;
                scaleY = y;
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid scaling factors.");
            }
        }

        private void DrawScaledCircle(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;
            int radius = 5;

            g.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, 2 * radius, 2 * radius);

            float scaledRadius1 = radius * scaleX;
            float scaledRadius2 = radius * scaleY;

            g.DrawEllipse(Pens.Red, centerX - scaledRadius1, centerY - scaledRadius2, 2 * scaledRadius1, 2 * scaledRadius2);
        }

        private void DrawEllipse(Graphics g, int centerX, int centerY, int radiusX, int radiusY, bool drawCircle)
        {
            int diameterX = 2 * radiusX;
            int diameterY = 2 * radiusY;

            if (drawCircle)
            {
                
                for (int angle = 0; angle <= 360; angle++)
                {
                    float radians = angle * (float)Math.PI / 180;
                    int x = (int)(centerX + radiusX * Math.Cos(radians));
                    int y = (int)(centerY + radiusX * Math.Sin(radians));
                    g.FillRectangle(Brushes.Black, x, y, 1, 1);
                }
            }
            else
            {
                
                for (int angle = 0; angle <= 360; angle++)
                {
                    float radians = angle * (float)Math.PI / 180;
                    int x = (int)(centerX + radiusX * Math.Cos(radians));
                    int y = (int)(centerY + radiusY * Math.Sin(radians));
                    g.FillRectangle(Brushes.Black, x, y, 1, 1);
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}