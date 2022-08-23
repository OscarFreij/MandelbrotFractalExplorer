using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing.Drawing2D;

namespace MandelbrotFractalExplorer
{
    public class Fractal
    {
        public double XCenter { get; private set; }
        public double YCenter { get; private set; }
        public double Zoom { get; private set; }

        
    }

    public class Cell
    {
        public CellData CellData { get; private set; }
        public Bitmap Bitmap { get; private set; }
        public Task<Bitmap> Task { get; private set; }

        public Cell (int id, int xId, int yId, double xStart, double xEnd, double yStart, double yEnd, int height, int width, int iterations)
        {
            this.CellData = new CellData(id, xId, yId, xStart, xEnd, yStart, yEnd, height, width, iterations);
            this.Task = new Task<Bitmap>(() => Calculations.Mandelbrot(this.CellData).Result);
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
        public static async Task<Bitmap> Mandelbrot(CellData cellData)
        {
            double XStart = cellData.XStart;
            double XEnd = cellData.XEnd;
            double YStart = cellData.YStart;
            double YEnd = cellData.YEnd;
            int Height = cellData.Height;
            int Width = cellData.Width;
            int Iterations = cellData.Iterations;
            Bitmap bitmap = new Bitmap(Width, Height);
            for (int y = Height-1; y >= 0; y--)
            {
                double zy = y * (YStart - YEnd) / (Height - 1) + YEnd;
                for (int x = 1; x < Width; x++)
                {
                    double zx = x * (XStart - XEnd) / (Width - 1) + XEnd;
                    Complex c = new Complex(zx, zy);
                    Complex z = c;
                    int i = 0;
                    for (i = 0; i < Iterations; i++)
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
                    if (i > Iterations)
                    {
                        color = Color.Black;
                    }
                    else
                    {
                        double p = i / Iterations;
                        int r = Convert.ToInt32(Math.Sin(p)*255);
                        int g = Convert.ToInt32(Math.Sin(p * 2)*255);
                        int b = Convert.ToInt32(Math.Cos(p)*255);

                        color = Color.FromArgb(r, g, b);
                    }
                    System.Diagnostics.Debug.WriteLine(x);
                    System.Diagnostics.Debug.WriteLine(y);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }
    }
}
