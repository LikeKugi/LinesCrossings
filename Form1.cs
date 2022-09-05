namespace LinesCrossings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen p = new Pen(Color.Black, 1);
            g.DrawLine(p, 0, 180, 600, 180);
            g.DrawLine(p, 300, 0, 300, 360);

            var lineOne = new Line(GetValue(textBox1.Text), GetValue(textBox2.Text));
            var lineTwo = new Line(GetValue(textBox4.Text), GetValue(textBox3.Text));

            DrawGraph(lineOne);
            DrawGraph(lineTwo);

            var crossing = Line.GetCross(lineOne, lineTwo);
            if (crossing[0] == double.MaxValue)
            {
                label9.Text = "Lines are parallel";
            } else if (crossing[0] == double.MinValue)
            {
                label9.Text = "Lines are same";
            } else 
                label9.Text = $"in point: ({crossing[0]:n3};{crossing[1]:n3})";
        }

        private int GetValue(string str) => Convert.ToInt32(str);
        private Random rnd = new Random();
        private void DrawGraph(Line a)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            var pOne = new Pen(randomColor, 2);

            var y1 = -(a.FIndY(-300) - 180);
            var y2 = -(a.FIndY(300) - 180);
          
            g.DrawLine(pOne, 0, y1, 600, y2);
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Text = String.Empty;
            pictureBox1.Image = null;
            
        }
    }
}