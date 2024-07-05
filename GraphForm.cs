using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAWProject
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
        }

        private void GraphForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private List<DateTime> _dates;
        private List<decimal> _balances;
        private int _drawnGraphs = 0;

        public GraphForm(List<DateTime> dates, List<decimal> balances)
        {
            InitializeComponent();
            _dates = dates;
            _balances = balances;
            Text = "Portfolio Profit Evolution";
            Size = new Size(800, 600);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(_drawnGraphs == 0)
                DrawGraph(e.Graphics);
        }

        private void DrawGraph(Graphics g)
        {
            int margin = 50;
            int width = ClientSize.Width - 2 * margin;
            int height = ClientSize.Height - 2 * margin;

            g.TranslateTransform(margin, margin);

            g.DrawLine(Pens.Black, 0, height, width, height);
            g.DrawLine(Pens.Black, 0, 0, 0, height);

            DateTime minDate = _dates[0];
            DateTime maxDate = _dates[_dates.Count - 1];
            decimal minBalance = decimal.MaxValue;
            decimal maxBalance = decimal.MinValue;

            foreach (var balance in _balances)
            {
                if (balance < minBalance) minBalance = balance;
                if (balance > maxBalance) maxBalance = balance;
            }

            TimeSpan dateRange = maxDate - minDate;
            decimal balanceRange = maxBalance - minBalance;

            if (balanceRange == 0) balanceRange = 1;

            float xScale = 0;
            if (dateRange.TotalDays != 0)
                xScale = width / (float)dateRange.TotalDays;
            else
                xScale = width;
            float yScale = height / (float)balanceRange;

            List<PointF> points = new List<PointF>();
            for (int i = 0; i < _dates.Count; i++)
            {
                float x = (float)(_dates[i] - minDate).TotalDays * xScale;
                float y = height - ((float)(_balances[i] - minBalance) * yScale);
                points.Add(new PointF(x, y));
            }

            if (points.Count > 1)
            {
                g.DrawLines(Pens.Blue, points.ToArray());
            }

            for (int i = 0; i < points.Count; i++)
            {
                if (i % Math.Max(1, points.Count / 10) == 0)
                {
                    g.DrawString(_dates[i].ToShortDateString(), Font, Brushes.Black, points[i].X, height + 5);
                }
            }
            _drawnGraphs++;
        }
    }
}

