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

        
        public Form1()
        {
            InitializeComponent();
            Filemanager.Init();

            fractal = new Fractal(0,0,1,64,64,100,100,2048);
            ChangeWorkStatus("IDLE");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ChangeWorkStatus("WORKING");
            StatusProgressBar.Value = 0;
            await fractal.CreateTasks();
            SetProgressStepMaxSafe(fractal.Cells.Count());
            await Generate();
            ChangeWorkStatus("IDLE");
        }

        public void AddProgressStep()
        {
            //ToDo: Fix speed, it is to slow
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

        public void SetProgressStepNowSafe(int count)
        {
            if (StatusProgressBar.InvokeRequired)
            {
                Action safeStep = delegate { SetProgressStepNow(count); };
                StatusProgressBar.Invoke(safeStep);
            }
            else
            {
                SetProgressStepNow(count);
            }
        }

        public void SetProgressStepNow(int count)
        {
            StatusProgressBar.Value = count;
        }


        public void SetProgressStepMaxSafe(int count)
        {
            if (StatusProgressBar.InvokeRequired)
            {
                Action safeStep = delegate { SetProgressStepMax(count); };
                StatusProgressBar.Invoke(safeStep);
            }
            else
            {
                SetProgressStepMax(count);
            }
        }

        public void SetProgressStepMax(int count)
        {
            StatusProgressBar.Maximum = count;
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

            SetProgressStepNowSafe(0);
            SetProgressStepMaxSafe(cellTasks.Count());

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

            List<Task> columnTasks = new List<Task>();

            for (int i = 0; i < fractal.XCells; i++)
            {
                int j = i; // Because C# is weird...
                Task task = new Task(action: () =>
                {
                    _ = ImageProcessor.CreateCollumn(j, fractal.Xres, fractal.Yres, fractal.YCells);
                });

                columnTasks.Add(task);
            }

            SetProgressStepNowSafe(0);
            SetProgressStepMaxSafe(columnTasks.Count());

            foreach (Task t in columnTasks)
            {
                t.Start();
            }

            Bitmap result = new Bitmap(64,64);
            while (columnTasks.Any())
            {
                Task completedTask = await Task.WhenAny(columnTasks).ConfigureAwait(false);
                columnTasks.Remove(completedTask);
                AddProgressStep();

                if (columnTasks.Count() == 0)
                {
                    result = await ImageProcessor.CreateResult(fractal.Xres, fractal.Yres, fractal.YCells, fractal.XCells, "testImage");
                }
            }            

            pixelBox1.Image = result;

            Task.Delay(1000).Wait();
            
            this.fractal.Cells.Clear();
            System.Diagnostics.Debug.WriteLine("Cell list cleared");
            await Filemanager.ClearCellDirectory();
            System.Diagnostics.Debug.WriteLine("Cell directory cleared");
            await Filemanager.ClearColumnDirectory();
            System.Diagnostics.Debug.WriteLine("Column directory cleared");

            return;
        }


    }
}
