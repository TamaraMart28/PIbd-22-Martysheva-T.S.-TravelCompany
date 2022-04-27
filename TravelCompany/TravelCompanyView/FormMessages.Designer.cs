namespace TravelCompanyView
{
    partial class FormMessages
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
            this.dataGridViewM = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewM)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewM
            // 
            this.dataGridViewM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewM.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewM.Name = "dataGridViewM";
            this.dataGridViewM.RowTemplate.Height = 25;
            this.dataGridViewM.Size = new System.Drawing.Size(500, 426);
            this.dataGridViewM.TabIndex = 0;
            // 
            // FormMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 450);
            this.Controls.Add(this.dataGridViewM);
            this.Name = "FormMessages";
            this.Text = "Письма";
            this.Load += new System.EventHandler(this.FormMessages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewM;
    }
}