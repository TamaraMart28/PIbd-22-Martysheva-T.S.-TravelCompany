namespace TravelCompanyView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.условияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.путевкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хранилищаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьХранилищеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокПутевокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.путевкиСУсловиямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокХранилищToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хранилищаСУсловиямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовПоДатамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.пополнитьХранилищеToolStripMenuItem1,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1069, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.условияToolStripMenuItem,
            this.путевкиToolStripMenuItem,
            this.хранилищаToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // условияToolStripMenuItem
            // 
            this.условияToolStripMenuItem.Name = "условияToolStripMenuItem";
            this.условияToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.условияToolStripMenuItem.Text = "Условия";
            this.условияToolStripMenuItem.Click += new System.EventHandler(this.условияToolStripMenuItem_Click);
            // 
            // путевкиToolStripMenuItem
            // 
            this.путевкиToolStripMenuItem.Name = "путевкиToolStripMenuItem";
            this.путевкиToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.путевкиToolStripMenuItem.Text = "Путевки";
            this.путевкиToolStripMenuItem.Click += new System.EventHandler(this.путевкиToolStripMenuItem_Click);
            // 
            // хранилищаToolStripMenuItem
            // 
            this.хранилищаToolStripMenuItem.Name = "хранилищаToolStripMenuItem";
            this.хранилищаToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.хранилищаToolStripMenuItem.Text = "Хранилища";
            this.хранилищаToolStripMenuItem.Click += new System.EventHandler(this.хранилищаToolStripMenuItem_Click);
            // 
            // пополнитьХранилищеToolStripMenuItem1
            // 
            this.пополнитьХранилищеToolStripMenuItem1.Name = "пополнитьХранилищеToolStripMenuItem1";
            this.пополнитьХранилищеToolStripMenuItem1.Size = new System.Drawing.Size(148, 20);
            this.пополнитьХранилищеToolStripMenuItem1.Text = "Пополнить хранилище";
            this.пополнитьХранилищеToolStripMenuItem1.Click += new System.EventHandler(this.пополнитьХранилищеToolStripMenuItem1_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокПутевокToolStripMenuItem,
            this.путевкиСУсловиямиToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.списокХранилищToolStripMenuItem,
            this.хранилищаСУсловиямиToolStripMenuItem,
            this.списокЗаказовПоДатамToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокПутевокToolStripMenuItem
            // 
            this.списокПутевокToolStripMenuItem.Name = "списокПутевокToolStripMenuItem";
            this.списокПутевокToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.списокПутевокToolStripMenuItem.Text = "Список путевок";
            this.списокПутевокToolStripMenuItem.Click += new System.EventHandler(this.списокПутевокToolStripMenuItem_Click);
            // 
            // путевкиСУсловиямиToolStripMenuItem
            // 
            this.путевкиСУсловиямиToolStripMenuItem.Name = "путевкиСУсловиямиToolStripMenuItem";
            this.путевкиСУсловиямиToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.путевкиСУсловиямиToolStripMenuItem.Text = "Путевки с условиями";
            this.путевкиСУсловиямиToolStripMenuItem.Click += new System.EventHandler(this.путевкиСУсловиямиToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // списокХранилищToolStripMenuItem
            // 
            this.списокХранилищToolStripMenuItem.Name = "списокХранилищToolStripMenuItem";
            this.списокХранилищToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.списокХранилищToolStripMenuItem.Text = "Список хранилищ";
            this.списокХранилищToolStripMenuItem.Click += new System.EventHandler(this.списокХранилищToolStripMenuItem_Click);
            // 
            // хранилищаСУсловиямиToolStripMenuItem
            // 
            this.хранилищаСУсловиямиToolStripMenuItem.Name = "хранилищаСУсловиямиToolStripMenuItem";
            this.хранилищаСУсловиямиToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.хранилищаСУсловиямиToolStripMenuItem.Text = "Хранилища с условиями";
            this.хранилищаСУсловиямиToolStripMenuItem.Click += new System.EventHandler(this.хранилищаСУсловиямиToolStripMenuItem_Click);
            // 
            // списокЗаказовПоДатамToolStripMenuItem
            // 
            this.списокЗаказовПоДатамToolStripMenuItem.Name = "списокЗаказовПоДатамToolStripMenuItem";
            this.списокЗаказовПоДатамToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.списокЗаказовПоДатамToolStripMenuItem.Text = "Список заказов по датам";
            this.списокЗаказовПоДатамToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовПоДатамToolStripMenuItem_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowTemplate.Height = 25;
            this.dataGridViewOrders.Size = new System.Drawing.Size(822, 411);
            this.dataGridViewOrders.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(892, 54);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(135, 23);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(892, 109);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(135, 23);
            this.buttonIssuedOrder.TabIndex = 5;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(895, 263);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(135, 23);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 450);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Туристическая фирма";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonIssuedOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem условияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem путевкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хранилищаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьХранилищеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокПутевокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem путевкиСУсловиямиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокХранилищToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хранилищаСУсловиямиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовПоДатамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
    }
}