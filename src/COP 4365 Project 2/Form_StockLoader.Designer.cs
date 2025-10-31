namespace COP_4365_Project_2
{
    partial class Form_StockLoader
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
            this.button_Load = new System.Windows.Forms.Button();
            this.openFileDialog_StockSelector = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Load
            // 
            this.button_Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Load.Location = new System.Drawing.Point(413, 154);
            this.button_Load.Margin = new System.Windows.Forms.Padding(4);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(225, 81);
            this.button_Load.TabIndex = 0;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // openFileDialog_StockSelector
            // 
            this.openFileDialog_StockSelector.FileName = "openFileDialog1";
            this.openFileDialog_StockSelector.Multiselect = true;
            this.openFileDialog_StockSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_StockSelector_FileOk);
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(35, 184);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(347, 30);
            this.dateTimePicker_StartDate.TabIndex = 1;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(678, 184);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(341, 30);
            this.dateTimePicker_EndDate.TabIndex = 2;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StartDate.Location = new System.Drawing.Point(166, 156);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(99, 25);
            this.label_StartDate.TabIndex = 3;
            this.label_StartDate.Text = "Start Date";
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EndDate.Location = new System.Drawing.Point(805, 156);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(93, 25);
            this.label_EndDate.TabIndex = 4;
            this.label_EndDate.Text = "End Date";
            // 
            // Form_StockLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 414);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.button_Load);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_StockLoader";
            this.Text = "Pick a Stock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.OpenFileDialog openFileDialog_StockSelector;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.Label label_EndDate;
    }
}

