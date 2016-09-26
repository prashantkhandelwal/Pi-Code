namespace ADXLVisualizer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.ADXLViz = new LiveCharts.WinForms.CartesianChart();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.X_Label = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.Y_Label = new System.Windows.Forms.Label();
            this.ZLabel = new System.Windows.Forms.Label();
            this.Z_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ADXLViz
            // 
            this.ADXLViz.Dock = System.Windows.Forms.DockStyle.Top;
            this.ADXLViz.Location = new System.Drawing.Point(0, 0);
            this.ADXLViz.Name = "ADXLViz";
            this.ADXLViz.Size = new System.Drawing.Size(991, 244);
            this.ADXLViz.TabIndex = 0;
            this.ADXLViz.Text = "ADXL345 Visualizer";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // X_Label
            // 
            this.X_Label.AutoSize = true;
            this.X_Label.Font = new System.Drawing.Font("Digital-7", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X_Label.Location = new System.Drawing.Point(104, 418);
            this.X_Label.Name = "X_Label";
            this.X_Label.Size = new System.Drawing.Size(146, 49);
            this.X_Label.TabIndex = 1;
            this.X_Label.Text = "000.00";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XLabel.Location = new System.Drawing.Point(157, 356);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(40, 45);
            this.XLabel.TabIndex = 2;
            this.XLabel.Text = "X";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YLabel.Location = new System.Drawing.Point(469, 356);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(39, 45);
            this.YLabel.TabIndex = 4;
            this.YLabel.Text = "Y";
            // 
            // Y_Label
            // 
            this.Y_Label.AutoSize = true;
            this.Y_Label.Font = new System.Drawing.Font("Digital-7", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y_Label.Location = new System.Drawing.Point(415, 418);
            this.Y_Label.Name = "Y_Label";
            this.Y_Label.Size = new System.Drawing.Size(146, 49);
            this.Y_Label.TabIndex = 3;
            this.Y_Label.Text = "000.00";
            // 
            // ZLabel
            // 
            this.ZLabel.AutoSize = true;
            this.ZLabel.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZLabel.Location = new System.Drawing.Point(780, 356);
            this.ZLabel.Name = "ZLabel";
            this.ZLabel.Size = new System.Drawing.Size(38, 45);
            this.ZLabel.TabIndex = 6;
            this.ZLabel.Text = "Z";
            // 
            // Z_Label
            // 
            this.Z_Label.AutoSize = true;
            this.Z_Label.Font = new System.Drawing.Font("Digital-7", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z_Label.Location = new System.Drawing.Point(726, 418);
            this.Z_Label.Name = "Z_Label";
            this.Z_Label.Size = new System.Drawing.Size(146, 49);
            this.Z_Label.TabIndex = 5;
            this.Z_Label.Text = "000.00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 492);
            this.Controls.Add(this.ZLabel);
            this.Controls.Add(this.Z_Label);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.Y_Label);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.X_Label);
            this.Controls.Add(this.ADXLViz);
            this.Name = "MainForm";
            this.Text = "ADXL345 Visualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart ADXLViz;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label X_Label;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label Y_Label;
        private System.Windows.Forms.Label ZLabel;
        private System.Windows.Forms.Label Z_Label;
    }
}

