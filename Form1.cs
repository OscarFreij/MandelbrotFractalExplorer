using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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

            //fractal = new Fractal(0,0,1,64,64,100,100,2048);
            ChangeWorkStatus("IDLE");
        }

        private async void generateBtn_Click(object sender, EventArgs e)
        {
            SetFractalSettings();
            ChangeWorkStatus("WORKING");
            StatusProgressBar.Value = 0;
            await fractal.CreateTasks();
            SetProgressStepMaxSafe(fractal.Cells.Count());
            await Generate();
            ChangeWorkStatus("IDLE");
        }

        private void SetFractalSettings()
        {
            fractal = new Fractal(
                (double)this.centerXNumInput.Value,
                (double)this.centerYNumInput.Value,
                (double)this.zoomNumInput.Value,
                (int)this.cellWidthNumInput.Value,
                (int)this.cellHeightNumInput.Value,
                (int)this.horizontalCellCountNumInput.Value,
                (int)this.verticalCellCountNumInput.Value,
                (int)this.iterationsNumInput.Value
                );

            System.Diagnostics.Debug.WriteLine(
                $"CX: {(double)this.centerXNumInput.Value}\n" +
                $"CY: {(double)this.centerYNumInput.Value}\n" +
                $"Z: {(double)this.zoomNumInput.Value}\n" +
                $"pWH: {(int)this.cellWidthNumInput.Value}/{(int)this.cellHeightNumInput.Value}\n" +
                $"cWH: {(int)this.horizontalCellCountNumInput.Value}/{(int)this.verticalCellCountNumInput.Value}\n" +
                $"I: {(int)this.iterationsNumInput.Value}");    
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

        public void SetPictureSafe(Bitmap bitmap)
        {
            if (pixelBox1.InvokeRequired)
            {
                Action safeDraw = delegate { SetPicture(bitmap); };
                pixelBox1.Invoke(safeDraw);
            }
            else
            {
                SetPicture(bitmap);
            }
        }

        public void SetPicture(Bitmap bitmap)
        {
            pixelBox1.Image = bitmap;
            pixelBox1.Refresh();
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
            }

            Task.Delay(1000).Wait();

            

            do
            {
                System.Diagnostics.Debug.WriteLine("Current col count: "+Directory.GetFiles(Filemanager.ColumnDirectory).Length);
                if (columnTasks.Count() == 0 && Directory.GetFiles(Filemanager.ColumnDirectory).Length == fractal.XCells)
                {
                    result = await ImageProcessor.CreateResult(fractal.Xres, fractal.Yres, fractal.YCells, fractal.XCells, "testImage");
                    break;
                }
            }
            while (true);


            SetPictureSafe(result);
            
            
            Task.Delay(1000).Wait();
            result = null;
            System.Diagnostics.Debug.WriteLine("Cleared result variable");
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
