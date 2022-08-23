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
        public static string TempDirectory { get; private set; } = Directory.GetCurrentDirectory() + "/temp";

        public static void Init()
        {
            if (!Directory.Exists(TempDirectory))
            {
                Directory.CreateDirectory(TempDirectory);
            }
        }

        public static async Task SaveToTemp(Bitmap bmp, int id)
        {
            bmp.Save(TempDirectory+$"/{id}.jpeg");
            return;
        }


        public static async Task ClearTemp()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(TempDirectory);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
