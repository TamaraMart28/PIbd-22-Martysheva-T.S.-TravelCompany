namespace TravelCompanyView
{
    partial class FormCreateOrder
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
            this.labelTravel = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.comboBoxTravel = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTravel
            // 
            this.labelTravel.AutoSize = true;
            this.labelTravel.Location = new System.Drawing.Point(23, 67);
            this.labelTravel.Name = "labelTravel";
            this.labelTravel.Size = new System.Drawing.Size(54, 15);
            this.labelTravel.TabIndex = 0;
            this.labelTravel.Text = "Путевка:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(23, 117);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 15);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество:";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(23, 167);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(48, 15);
            this.labelSum.TabIndex = 2;
            this.labelSum.Text = "Сумма:";
            // 
            // comboBoxTravel
            // 
            this.comboBoxTravel.FormattingEnabled = true;
            this.comboBoxTravel.Location = new System.Drawing.Point(106, 67);
            this.comboBoxTravel.Name = "comboBoxTravel";
            this.comboBoxTravel.Size = new System.Drawing.Size(279, 23);
            this.comboBoxTravel.TabIndex = 3;
            this.comboBoxTravel.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTravel_SelectedIndexChanged);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(125, 117);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(260, 23);
            this.textBoxCount.TabIndex = 4;
            this.textBoxCount.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(106, 164);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(279, 23);
            this.textBoxSum.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(204, 227);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(310, 227);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(125, 27);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(260, 23);
            this.comboBoxClient.TabIndex = 8;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(23, 30);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(49, 15);
            this.labelClient.TabIndex = 9;
            this.labelClient.Text = "Клиент:";
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 277);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxTravel);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelTravel);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTravel;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.ComboBox comboBoxTravel;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Label labelClient;
    }
}