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

namespace MandelbrotFractalExplorer
{
    public partial class Form1 : Form
    {
        public Cell cell;
        public Form1()
        {
            InitializeComponent();
            cell = new Cell(0, 0, 0, 1, -2, 1.5, -1.5, 256, 256, 255);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (cell.Bitmap != null)
            {
                System.Diagnostics.Debug.WriteLine("cell.Bitmap not null!");
            }
            cell.Task.Start();
            pixelBox1.Image = await cell.Task;
        }
    }
}
