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

        public static void Init()
        {
            if (!Directory.Exists(CellDirectory))
            {
                Directory.CreateDirectory(CellDirectory);
            }
        }

        public static async Task SaveCell(Bitmap bmp, int id)
        {
            bmp.Save(CellDirectory + $"/{id}.jpeg");
            return;
        }

        public static async Task SaveColumn(Bitmap bmp, int id)
        {
            bmp.Save(ColumnDirectory + $"/{id}.jpeg");
            return;
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
