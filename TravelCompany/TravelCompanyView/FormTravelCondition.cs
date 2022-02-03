using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.ViewModels;


namespace TravelCompanyView
{
    public partial class FormTravelCondition : Form
    {
        public int Id
        {
            get { return Convert.ToInt32(comboBoxCondition.SelectedValue); }
            set { comboBoxCondition.SelectedValue = value; }
        }
        public string ComponentName { get { return comboBoxCondition.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public FormTravelCondition(IConditionLogic logic)
        {
            InitializeComponent();
            List<ConditionViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxCondition.DisplayMember = "ConditionName";
                comboBoxCondition.ValueMember = "Id";
                comboBoxCondition.DataSource = list;
                comboBoxCondition.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCondition.SelectedValue == null)
            {
                MessageBox.Show("Выберите условие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
