namespace COP_4365_Project_2
{
    partial class Form_StockViewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_Update = new System.Windows.Forms.Button();
            this.chart_StockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.label_Filter = new System.Windows.Forms.Label();
            this.comboBox_Filter = new System.Windows.Forms.ComboBox();
            this.bindingSource_SmartCandlestick = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_StockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SmartCandlestick)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Update
            // 
            this.button_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.Location = new System.Drawing.Point(440, 483);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(161, 61);
            this.button_Update.TabIndex = 0;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // chart_StockData
            // 
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_StockData.ChartAreas.Add(chartArea1);
            this.chart_StockData.ChartAreas.Add(chartArea2);
            this.chart_StockData.Location = new System.Drawing.Point(0, 1);
            this.chart_StockData.Name = "chart_StockData";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series1.IsXValueIndexed = true;
            series1.Name = "Series_OHLC";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.IsXValueIndexed = true;
            series2.Name = "Series_Volume";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chart_StockData.Series.Add(series1);
            this.chart_StockData.Series.Add(series2);
            this.chart_StockData.Size = new System.Drawing.Size(1052, 389);
            this.chart_StockData.TabIndex = 1;
            this.chart_StockData.Text = "Chart";
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(44, 432);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(345, 26);
            this.dateTimePicker_StartDate.TabIndex = 2;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2024, 3, 6, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(662, 432);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(344, 26);
            this.dateTimePicker_EndDate.TabIndex = 3;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2024, 3, 6, 0, 0, 0, 0);
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StartDate.Location = new System.Drawing.Point(172, 404);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(83, 20);
            this.label_StartDate.TabIndex = 4;
            this.label_StartDate.Text = "Start Date";
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EndDate.Location = new System.Drawing.Point(783, 404);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(77, 20);
            this.label_EndDate.TabIndex = 5;
            this.label_EndDate.Text = "End Date";
            // 
            // label_Filter
            // 
            this.label_Filter.AutoSize = true;
            this.label_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Filter.Location = new System.Drawing.Point(500, 404);
            this.label_Filter.Name = "label_Filter";
            this.label_Filter.Size = new System.Drawing.Size(44, 20);
            this.label_Filter.TabIndex = 7;
            this.label_Filter.Text = "Filter";
            // 
            // comboBox_Filter
            // 
            this.comboBox_Filter.FormattingEnabled = true;
            this.comboBox_Filter.Location = new System.Drawing.Point(433, 432);
            this.comboBox_Filter.Name = "comboBox_Filter";
            this.comboBox_Filter.Size = new System.Drawing.Size(183, 24);
            this.comboBox_Filter.TabIndex = 8;
            this.comboBox_Filter.SelectedIndexChanged += new System.EventHandler(this.comboBox_Filter_SelectedIndexChanged);
            // 
            // bindingSource_SmartCandlestick
            // 
            this.bindingSource_SmartCandlestick.DataSource = typeof(COP_4365_Project_2.SmartCandlestick);
            // 
            // Form_StockViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1052, 556);
            this.Controls.Add(this.comboBox_Filter);
            this.Controls.Add(this.label_Filter);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.chart_StockData);
            this.Controls.Add(this.button_Update);
            this.Name = "Form_StockViewer";
            this.Text = "Form_StockViewer";
            ((System.ComponentModel.ISupportInitialize)(this.chart_StockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SmartCandlestick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_StockData;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.Label label_EndDate;
        private System.Windows.Forms.Label label_Filter;
        private System.Windows.Forms.ComboBox comboBox_Filter;
        private System.Windows.Forms.BindingSource bindingSource_SmartCandlestick;
    }
}