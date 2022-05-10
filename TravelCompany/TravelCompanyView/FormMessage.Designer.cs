namespace TravelCompanyView
{
    partial class FormMessage
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
            this.labelSenderName = new System.Windows.Forms.Label();
            this.labelDateDelivery = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelAnswerText = new System.Windows.Forms.Label();
            this.textBoxAnswerText = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelSenderNameRes = new System.Windows.Forms.Label();
            this.labelDateDeliveryRes = new System.Windows.Forms.Label();
            this.labelSubjectRes = new System.Windows.Forms.Label();
            this.labelBodyRes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSenderName
            // 
            this.labelSenderName.AutoSize = true;
            this.labelSenderName.Location = new System.Drawing.Point(48, 30);
            this.labelSenderName.Name = "labelSenderName";
            this.labelSenderName.Size = new System.Drawing.Size(81, 15);
            this.labelSenderName.TabIndex = 0;
            this.labelSenderName.Text = "Отправитель:";
            // 
            // labelDateDelivery
            // 
            this.labelDateDelivery.AutoSize = true;
            this.labelDateDelivery.Location = new System.Drawing.Point(48, 71);
            this.labelDateDelivery.Name = "labelDateDelivery";
            this.labelDateDelivery.Size = new System.Drawing.Size(79, 15);
            this.labelDateDelivery.TabIndex = 1;
            this.labelDateDelivery.Text = "Дата письма:";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(48, 110);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(68, 15);
            this.labelSubject.TabIndex = 2;
            this.labelSubject.Text = "Заголовок:";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(48, 149);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(39, 15);
            this.labelBody.TabIndex = 3;
            this.labelBody.Text = "Текст:";
            // 
            // labelAnswerText
            // 
            this.labelAnswerText.AutoSize = true;
            this.labelAnswerText.Location = new System.Drawing.Point(48, 186);
            this.labelAnswerText.Name = "labelAnswerText";
            this.labelAnswerText.Size = new System.Drawing.Size(41, 15);
            this.labelAnswerText.TabIndex = 4;
            this.labelAnswerText.Text = "Ответ:";
            // 
            // textBoxAnswerText
            // 
            this.textBoxAnswerText.Location = new System.Drawing.Point(48, 224);
            this.textBoxAnswerText.Name = "textBoxAnswerText";
            this.textBoxAnswerText.Size = new System.Drawing.Size(276, 23);
            this.textBoxAnswerText.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(69, 277);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(218, 277);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelSenderNameRes
            // 
            this.labelSenderNameRes.AutoSize = true;
            this.labelSenderNameRes.Location = new System.Drawing.Point(144, 30);
            this.labelSenderNameRes.Name = "labelSenderNameRes";
            this.labelSenderNameRes.Size = new System.Drawing.Size(0, 15);
            this.labelSenderNameRes.TabIndex = 8;
            // 
            // labelDateDeliveryRes
            // 
            this.labelDateDeliveryRes.AutoSize = true;
            this.labelDateDeliveryRes.Location = new System.Drawing.Point(144, 71);
            this.labelDateDeliveryRes.Name = "labelDateDeliveryRes";
            this.labelDateDeliveryRes.Size = new System.Drawing.Size(0, 15);
            this.labelDateDeliveryRes.TabIndex = 9;
            // 
            // labelSubjectRes
            // 
            this.labelSubjectRes.AutoSize = true;
            this.labelSubjectRes.Location = new System.Drawing.Point(144, 110);
            this.labelSubjectRes.Name = "labelSubjectRes";
            this.labelSubjectRes.Size = new System.Drawing.Size(0, 15);
            this.labelSubjectRes.TabIndex = 10;
            // 
            // labelBodyRes
            // 
            this.labelBodyRes.AutoSize = true;
            this.labelBodyRes.Location = new System.Drawing.Point(144, 149);
            this.labelBodyRes.Name = "labelBodyRes";
            this.labelBodyRes.Size = new System.Drawing.Size(0, 15);
            this.labelBodyRes.TabIndex = 11;
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 326);
            this.Controls.Add(this.labelBodyRes);
            this.Controls.Add(this.labelSubjectRes);
            this.Controls.Add(this.labelDateDeliveryRes);
            this.Controls.Add(this.labelSenderNameRes);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxAnswerText);
            this.Controls.Add(this.labelAnswerText);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelDateDelivery);
            this.Controls.Add(this.labelSenderName);
            this.Name = "FormMessage";
            this.Text = "Письмо";
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSenderName;
        private System.Windows.Forms.Label labelDateDelivery;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Label labelAnswerText;
        private System.Windows.Forms.TextBox textBoxAnswerText;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelSenderNameRes;
        private System.Windows.Forms.Label labelDateDeliveryRes;
        private System.Windows.Forms.Label labelSubjectRes;
        private System.Windows.Forms.Label labelBodyRes;
    }
}