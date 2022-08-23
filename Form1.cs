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
        public List<Task<Bitmap>> cellTasks = new List<Task<Bitmap>>();

        
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
                    id++;
                }
            }

            
            foreach (Cell item in cellList)
            {
                System.Diagnostics.Debug.WriteLine($"IDx: {item.CellData.XId} | IDy: {item.CellData.YId} | {item.CellData.XStart} {item.CellData.XEnd} : {item.CellData.YStart} {item.CellData.YEnd}");
                cellTasks.Add(item.Task);
            }
            
            //cell = new Cell(0, 0, 0, 1, -2, 1.5, -1.5, 256, 256, 255);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /*
            if (cell.Bitmap != null)
            {
                System.Diagnostics.Debug.WriteLine("cell.Bitmap not null!");
            }
            */

            await Generate();

            //cell.Task.Start();
            
            //pixelBox1.Image = await cell.Task;
        }

        private async Task Generate()
        {
            foreach (Task t in cellTasks)
            {
                t.Start();
            }

            List<Task<Bitmap>> indexingArray = new List<Task<Bitmap>>(cellTasks);
            var results = new Bitmap[cellTasks.Count];

            while (cellTasks.Any())
            {
                Task<Bitmap> completedTask = await Task.WhenAny(cellTasks).ConfigureAwait(false);
                results[indexingArray.IndexOf(completedTask)] = completedTask.Result;
                cellTasks.Remove(completedTask);
            }

            for (int i = 0; i < results.Length; i++)
            {
                System.Diagnostics.Debug.WriteLine("Displaying: " + i);
                pixelBox1.Image = results[i];
                Task.Delay(100).Wait();
            }

            return;
        }
    }
}
