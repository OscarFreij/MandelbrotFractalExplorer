using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MandelbrotFractalExplorer
{
    public static class ImageProcessor
    {
        public static async Task CreateCollumn(int xId, int xRes, int yRes, int height)
        {
            System.Diagnostics.Debug.WriteLine(xId + " : Started");
            try
            {
                Bitmap bitmap = new Bitmap(xRes, yRes * height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    for (int y = 0; y < height; y++)
                    {
                        Bitmap bmp = await Filemanager.ReadCell(xId, y);
                        g.DrawImage(bmp, 0, yRes * y);
                    }
                }

                await Filemanager.SaveColumn(bitmap, xId);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("err when creating column " + xId + " with msg: " + e.Message);
            }

            System.Diagnostics.Debug.WriteLine(xId + " : Done");
            return;
        }

        public static async Task<Bitmap> CreateResult(int xRes, int yRes, int height, int width, string resultName)
        {
            System.Diagnostics.Debug.WriteLine("Final image creation started");
            Bitmap bitmap = new Bitmap(xRes * width, yRes * height);
            try
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    for (int x = 0; x < width; x++)
                    {
                        Bitmap bmp = await Filemanager.ReadColumn(x);
                        g.DrawImage(bmp, (xRes * x), 0);
                    }
                }

                await Filemanager.SaveFinal(bitmap, resultName);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("err when creating final image with msg: " + e.Message);
            }

            System.Diagnostics.Debug.WriteLine("Final image creation completed");
            return bitmap;
        }
    }
}
