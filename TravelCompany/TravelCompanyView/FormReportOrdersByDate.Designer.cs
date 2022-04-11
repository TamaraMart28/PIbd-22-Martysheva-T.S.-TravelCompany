namespace TravelCompanyView
{
    partial class FormReportOrdersByDate
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
            this.panelROBD = new System.Windows.Forms.Panel();
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.panelROBD.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelROBD
            // 
            this.panelROBD.Controls.Add(this.buttonToPdf);
            this.panelROBD.Controls.Add(this.buttonMake);
            this.panelROBD.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelROBD.Location = new System.Drawing.Point(0, 0);
            this.panelROBD.Name = "panelROBD";
            this.panelROBD.Size = new System.Drawing.Size(800, 49);
            this.panelROBD.TabIndex = 0;
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(207, 12);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(113, 23);
            this.buttonMake.TabIndex = 0;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(478, 12);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(75, 23);
            this.buttonToPdf.TabIndex = 1;
            this.buttonToPdf.Text = "В Pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // FormReportOrdersByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelROBD);
            this.Name = "FormReportOrdersByDate";
            this.Text = "Заказы, объединенные по датам";
            this.panelROBD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelROBD;
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.Button buttonMake;
    }
}