using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace MandelbrotFractalExplorer
{
    public class Fractal
    {
        public double XCenter { get; private set; }
        public double YCenter { get; private set; }
        public double Zoom { get; private set; }
        public int Xres { get; private set; }
        public int Yres { get; private set; }
        public int XCells { get; private set; }
        public int YCells { get; private set; }
        public int I { get; private set; }
        public List<Cell> Cells { get; private set; }


        public Fractal(double xCenter, double yCenter, double zoom, int xRes, int yRes, int xCells, int yCells, int i)
        {
            XCenter = xCenter;
            YCenter = yCenter;
            Zoom = zoom;
            Xres = xRes;
            Yres = yRes;
            XCells = xCells;
            YCells = yCells;
            I = i;
            Cells = new List<Cell>();
        }

        public Fractal()
        {
            XCenter = 0;
            YCenter = 0;
            Zoom = 1;
            Xres = 256;
            Yres = 256;
            XCells = 10;
            YCells = 10;
            I = 256;
            Cells = new List<Cell>();
        }
        public async Task CreateTasks()
        {
            int id = 0;

            /*
            double xMax = 1;
            double xMin = -2;
            double yMax = 1.5;
            double yMin = -1.5;
            */

            double xMax = Math.Round(XCenter + (2 / Zoom));
            double xMin = Math.Round(XCenter - (2 / Zoom));
            double yMax = Math.Round(YCenter + (2 / Zoom));
            double yMin = Math.Round(YCenter - (2 / Zoom));


            double xStep;
            double yStep;
            double xDelta = Math.Abs(xMin - xMax);
            double yDelta = Math.Abs(yMin - yMax);

            xStep = xDelta / XCells;
            yStep = yDelta / YCells;

            double xTempMin;
            double xTempMax = xMin;

            for (int x = 0; x < XCells; x++)
            {
                xTempMin = xTempMax;
                xTempMax = xTempMax + xStep;

                double yTempMin;
                double yTempMax = yMin;


                for (int y = 0; y < YCells; y++)
                {
                    yTempMin = yTempMax;
                    yTempMax = yTempMax + yStep;

                    Cells.Add(new Cell(id, x, y, Math.Round(xTempMax, 8), Math.Round(xTempMin, 8), Math.Round(yTempMax, 8), Math.Round(yTempMin, 8), Xres, Yres, I));
                    id++;
                }
            }

            return;
        }

    }

    public class Cell
    {
        public CellData CellData { get; private set; }
        public Task Task { get; private set; }

        public Cell (int id, int xId, int yId, double xStart, double xEnd, double yStart, double yEnd, int height, int width, int iterations)
        {
            this.CellData = new CellData(id, xId, yId, xStart, xEnd, yStart, yEnd, height, width, iterations);
            this.Task = new Task(action: () =>
            {
                _ = Calculations.Mandelbrot(this.CellData);
            });
        }
        public Cell(CellData cellData)
        {
            this.CellData = cellData;
            this.Task = new Task(action: () =>
            {
                _ = Calculations.Mandelbrot(this.CellData);
            });
        }
    }

    public class CellData
    {
        public int Id { get; private set; }
        public int XId { get; private set; }
        public int YId { get; private set; }
        public double XStart { get; private set; }
        public double XEnd { get; private set; }
        public double YStart { get; private set; }
        public double YEnd { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Iterations { get; private set; }

        public CellData(int id, int xId, int yId, double xStart, double xEnd, double yStart, double yEnd, int height, int width, int iterations)
        {
            Id = id;
            XId = xId;
            YId = yId;
            XStart = xStart;
            XEnd = xEnd;
            YStart = yStart;
            YEnd = yEnd;
            Height = height;
            Width = width;
            Iterations = iterations;
        }
    }

    public static class Calculations
    {
        public static async Task Mandelbrot(CellData cellData)
        {
            System.Diagnostics.Debug.WriteLine(cellData.Id + " : Started");
            Bitmap bitmap = new Bitmap(cellData.Width, cellData.Height);
            for (int y = cellData.Height - 1; y >= 0; y--)
            {
                double zy = y * (cellData.YStart - cellData.YEnd) / (cellData.Height - 1) + cellData.YEnd;
                for (int x = 1; x < cellData.Width; x++)
                {
                    double zx = x * (cellData.XStart - cellData.XEnd) / (cellData.Width - 1) + cellData.XEnd;
                    Complex c = new Complex(zx, zy);
                    Complex z = c;
                    int i = 0;
                    for (i = 0; i < cellData.Iterations; i++)
                    {
                        if (z.Magnitude > 2.0)
                        {
                            break; 
                        }
                        else
                        {
                            z = z * z + c;
                        }
                    }
                    Color color;
                    if (i > cellData.Iterations)
                    {
                        color = Color.Black;
                    }
                    else
                    {
                        /*
                        double p = (i / cellData.Iterations)*Math.PI;
                        int r = Convert.ToInt32(Math.Sin(p)*255);
                        int g = Convert.ToInt32(Math.Sin(p * 2)*255);
                        int b = Convert.ToInt32(Math.Cos(p)*255);

                        if (r < 0)
                        {
                            r = 0;
                        }
                        if (g < 0)
                        {
                            g = 0;
                        }
                        if (b < 0)
                        {
                            b = 0;
                        }

                        color = Color.FromArgb(r, g, b);
                        */
                        color = Color.FromArgb((i % 4) * 64, (i % 8) * 32, (i % 16) * 16);
                    }
                    bitmap.SetPixel(x, y, color);
                }
            }
            System.Diagnostics.Debug.WriteLine(cellData.Id + " : Done");
            await Filemanager.SaveCell(bitmap, cellData.Id);
            return;
        }
    }
}
