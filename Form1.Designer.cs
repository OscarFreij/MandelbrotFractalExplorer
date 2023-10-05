namespace MandelbrotFractalExplorer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StatusProgressBar = new System.Windows.Forms.ProgressBar();
            this.StatusLable = new System.Windows.Forms.Label();
            this.pixelBox1 = new PixelBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.generateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.centerXNumInput = new System.Windows.Forms.NumericUpDown();
            this.centerYNumInput = new System.Windows.Forms.NumericUpDown();
            this.horizontalCellCountNumInput = new System.Windows.Forms.NumericUpDown();
            this.verticalCellCountNumInput = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cellWidthNumInput = new System.Windows.Forms.NumericUpDown();
            this.cellHeightNumInput = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.zoomNumInput = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.iterationsNumInput = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.centerXNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerYNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalCellCountNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalCellCountNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellWidthNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellHeightNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsNumInput)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.StatusProgressBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.StatusLable, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pixelBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusProgressBar.Location = new System.Drawing.Point(5, 421);
            this.StatusProgressBar.Name = "StatusProgressBar";
            this.StatusProgressBar.Size = new System.Drawing.Size(589, 24);
            this.StatusProgressBar.Step = 1;
            this.StatusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.StatusProgressBar.TabIndex = 0;
            // 
            // StatusLable
            // 
            this.StatusLable.AutoSize = true;
            this.StatusLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusLable.Location = new System.Drawing.Point(602, 418);
            this.StatusLable.Name = "StatusLable";
            this.StatusLable.Size = new System.Drawing.Size(193, 30);
            this.StatusLable.TabIndex = 1;
            this.StatusLable.Text = "Status: {STATE]";
            this.StatusLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pixelBox1
            // 
            this.pixelBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pixelBox1.Location = new System.Drawing.Point(5, 5);
            this.pixelBox1.Name = "pixelBox1";
            this.pixelBox1.Size = new System.Drawing.Size(589, 408);
            this.pixelBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pixelBox1.TabIndex = 4;
            this.pixelBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.generateBtn, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.centerXNumInput, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.centerYNumInput, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.horizontalCellCountNumInput, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.verticalCellCountNumInput, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.cellWidthNumInput, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.cellHeightNumInput, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.zoomNumInput, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.iterationsNumInput, 0, 11);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(602, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 14;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(193, 408);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // generateBtn
            // 
            this.generateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.generateBtn, 2);
            this.generateBtn.Location = new System.Drawing.Point(3, 382);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(187, 23);
            this.generateBtn.TabIndex = 4;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "X Center";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y Center";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Horizontal Cells";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(99, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Vertical Cells";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // centerXNumInput
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.centerXNumInput, 2);
            this.centerXNumInput.DecimalPlaces = 5;
            this.centerXNumInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerXNumInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.centerXNumInput.Location = new System.Drawing.Point(3, 28);
            this.centerXNumInput.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.centerXNumInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.centerXNumInput.Name = "centerXNumInput";
            this.centerXNumInput.Size = new System.Drawing.Size(187, 20);
            this.centerXNumInput.TabIndex = 9;
            // 
            // centerYNumInput
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.centerYNumInput, 2);
            this.centerYNumInput.DecimalPlaces = 5;
            this.centerYNumInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerYNumInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.centerYNumInput.Location = new System.Drawing.Point(3, 78);
            this.centerYNumInput.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.centerYNumInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.centerYNumInput.Name = "centerYNumInput";
            this.centerYNumInput.Size = new System.Drawing.Size(187, 20);
            this.centerYNumInput.TabIndex = 10;
            // 
            // horizontalCellCountNumInput
            // 
            this.horizontalCellCountNumInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalCellCountNumInput.Location = new System.Drawing.Point(3, 128);
            this.horizontalCellCountNumInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.horizontalCellCountNumInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.horizontalCellCountNumInput.Name = "horizontalCellCountNumInput";
            this.horizontalCellCountNumInput.Size = new System.Drawing.Size(90, 20);
            this.horizontalCellCountNumInput.TabIndex = 11;
            this.horizontalCellCountNumInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // verticalCellCountNumInput
            // 
            this.verticalCellCountNumInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verticalCellCountNumInput.Location = new System.Drawing.Point(99, 128);
            this.verticalCellCountNumInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.verticalCellCountNumInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.verticalCellCountNumInput.Name = "verticalCellCountNumInput";
            this.verticalCellCountNumInput.Size = new System.Drawing.Size(91, 20);
            this.verticalCellCountNumInput.TabIndex = 12;
            this.verticalCellCountNumInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cell Width";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(99, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Cell Height";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cellWidthNumInput
            // 
            this.cellWidthNumInput.Location = new System.Drawing.Point(3, 178);
            this.cellWidthNumInput.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.cellWidthNumInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cellWidthNumInput.Name = "cellWidthNumInput";
            this.cellWidthNumInput.Size = new System.Drawing.Size(90, 20);
            this.cellWidthNumInput.TabIndex = 15;
            this.cellWidthNumInput.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // cellHeightNumInput
            // 
            this.cellHeightNumInput.Location = new System.Drawing.Point(99, 178);
            this.cellHeightNumInput.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.cellHeightNumInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cellHeightNumInput.Name = "cellHeightNumInput";
            this.cellHeightNumInput.Size = new System.Drawing.Size(91, 20);
            this.cellHeightNumInput.TabIndex = 16;
            this.cellHeightNumInput.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label7, 2);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Zoom";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zoomNumInput
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.zoomNumInput, 2);
            this.zoomNumInput.DecimalPlaces = 2;
            this.zoomNumInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomNumInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.zoomNumInput.Location = new System.Drawing.Point(3, 228);
            this.zoomNumInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.zoomNumInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomNumInput.Name = "zoomNumInput";
            this.zoomNumInput.Size = new System.Drawing.Size(187, 20);
            this.zoomNumInput.TabIndex = 18;
            this.zoomNumInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label8, 2);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Iterations";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iterationsNumInput
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.iterationsNumInput, 2);
            this.iterationsNumInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iterationsNumInput.Location = new System.Drawing.Point(3, 278);
            this.iterationsNumInput.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.iterationsNumInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iterationsNumInput.Name = "iterationsNumInput";
            this.iterationsNumInput.Size = new System.Drawing.Size(187, 20);
            this.iterationsNumInput.TabIndex = 20;
            this.iterationsNumInput.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Mandelbrot Fractal Explorer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.centerXNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerYNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalCellCountNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalCellCountNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellWidthNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellHeightNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsNumInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ProgressBar StatusProgressBar;
        public System.Windows.Forms.Label StatusLable;
        private PixelBox pixelBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown centerXNumInput;
        private System.Windows.Forms.NumericUpDown centerYNumInput;
        private System.Windows.Forms.NumericUpDown horizontalCellCountNumInput;
        private System.Windows.Forms.NumericUpDown verticalCellCountNumInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown cellWidthNumInput;
        private System.Windows.Forms.NumericUpDown cellHeightNumInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown zoomNumInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown iterationsNumInput;
    }
}

