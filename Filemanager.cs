using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace MandelbrotFractalExplorer
{
    public static class Filemanager
    {
        public static string BaseDirectory { get; private set; } = Directory.GetCurrentDirectory();
        public static string CellDirectory { get; private set; } = BaseDirectory + "/cells";
        public static string ColumnDirectory { get; private set; } = BaseDirectory + "/columns";
        public static string FinalDirectory { get; private set; } = BaseDirectory + "/final";

        public static void Init()
        {
            if (!Directory.Exists(CellDirectory))
            {
                Directory.CreateDirectory(CellDirectory);
            }

            if (!Directory.Exists(ColumnDirectory))
            {
                Directory.CreateDirectory(ColumnDirectory);
            }

            if (!Directory.Exists(FinalDirectory))
            {
                Directory.CreateDirectory(FinalDirectory);
            }
        }

        public static async Task SaveCell(Bitmap bmp, int xId, int yId)
        {
            bmp.Save(CellDirectory + $"/{xId}x{yId}.jpeg");
            return;
        }

        public static async Task<Bitmap> ReadCell(int xId, int yId)
        {
            return new Bitmap(ColumnDirectory + $"/{xId}x{yId}.jpeg");
        }

        public static async Task SaveColumn(Bitmap bmp, int id)
        {
            bmp.Save(ColumnDirectory + $"/{id}.jpeg");
            return;
        }

        public static async Task<Bitmap> ReadColumn(string id)
        {
            return new Bitmap(ColumnDirectory + $"/{id}.jpeg");
        }

        public static async Task ClearCellDirectory()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(CellDirectory);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        public static async Task ClearColumnDirectory()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(ColumnDirectory);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
