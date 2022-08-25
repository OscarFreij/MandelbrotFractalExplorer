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
        public Fractal fractal;
        
        public List<Cell> cellList = new List<Cell>();
        public List<Task<Bitmap>> cellTasks = new List<Task<Bitmap>>();

        
        public Form1()
        {
            InitializeComponent();
            Filemanager.Init();

            fractal = new Fractal(0,0,1,1024,1024,10,10,2048);
            ChangeWorkStatus("IDLE");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ChangeWorkStatus("WORKING");
            StatusProgressBar.Value = 0;
            await fractal.CreateTasks();
            StatusProgressBar.Maximum = fractal.Cells.Count();
            await Generate();
            ChangeWorkStatus("IDLE");
        }

        public void AddProgressStep()
        {
            if (StatusProgressBar.InvokeRequired)
            {
                Action safeStep = delegate { StatusProgressBar.PerformStep(); };
                StatusProgressBar.Invoke(safeStep);
            }
            else
            {
                StatusProgressBar.PerformStep();
            }
        }

        public void ChangeWorkStatus(string status)
        {
            if (StatusLable.InvokeRequired)
            {
                Action safeWrite = delegate { WriteTOStatusLable(status); };
                StatusLable.Invoke(safeWrite);
            }
            else
            {
                WriteTOStatusLable(status);
            }
        }

        public void WriteTOStatusLable(string status)
        {
            StatusLable.Text = $"Status: [{status}]";
        }


        private async Task Generate()
        {
            List<Task> cellTasks = new List<Task>();
            foreach (Cell item in fractal.Cells)
            {
                System.Diagnostics.Debug.WriteLine($"IDx: {item.CellData.XId} | IDy: {item.CellData.YId} | {item.CellData.XStart} {item.CellData.XEnd} : {item.CellData.YStart} {item.CellData.YEnd}");
                cellTasks.Add(item.Task);
            }

            foreach (Task t in cellTasks)
            {
                t.Start();
            }

            while (cellTasks.Any())
            {
                Task completedTask = await Task.WhenAny(cellTasks).ConfigureAwait(false);
                cellTasks.Remove(completedTask);
                AddProgressStep();
            }

            /*
            for (int i = 0; i < results.Length; i++)
            {
                System.Diagnostics.Debug.WriteLine("Displaying: " + i);
                pixelBox1.Image = results[i];
                Task.Delay(100).Wait();
            }
            */

            System.Diagnostics.Debug.WriteLine("Final Cell completed");
            Task.Delay(1000).Wait();
            System.Diagnostics.Debug.WriteLine("Cell directory cleared");
            this.fractal.Cells.Clear();
            await Filemanager.ClearCellDirectory();

            return;
        }
    }
}
