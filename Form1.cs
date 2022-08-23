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
        public List<Cell> cellList = new List<Cell>();
        public Form1()
        {
            InitializeComponent();
            int id = 0;
            int xSections = 10;
            int ySections = 10;

            int maxIt = 256;

            int resX = 16;
            int resY = 16;

            double xMax = 1;
            double xMin = -2;
            double yMax = 1.5;
            double yMin = -1.5;

            double xStep = 0;
            double yStep = 0;
            double xStepStart = 0;
            double xStepEnd = 0;
            double yStepStart = 0;
            double yStepEnd = 0;
            double xDelta = Math.Abs(xMin - xMax);
            double yDelta = Math.Abs(yMin - yMax);

            xStep = xDelta / xSections;
            yStep = yDelta / ySections;

            double xTempMin = xMin - xStep;
            double xTempMax = xMin;

            for (int x = 0; x < xSections; x++)
            {
                xTempMin = xTempMax;
                xTempMax = xTempMax + xStep;

                double yTempMin = yMin - yStep;
                double yTempMax = yMin;


                for (int y = 0; y < ySections; y++)
                {
                    yTempMin = yTempMax;
                    yTempMax = yTempMax + yStep;

                    cellList.Add(new Cell(id, x, y, Math.Round(xTempMax,8), Math.Round(xTempMin,8), Math.Round(yTempMax,8), Math.Round(yTempMin,8), resX, resY, maxIt));
                }
            }

            foreach (Cell item in cellList)
            {
                System.Diagnostics.Debug.WriteLine($"IDx: {item.CellData.XId} | IDy: {item.CellData.YId} | {item.CellData.XStart} {item.CellData.XEnd} : {item.CellData.YStart} {item.CellData.YEnd}");
            }
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
