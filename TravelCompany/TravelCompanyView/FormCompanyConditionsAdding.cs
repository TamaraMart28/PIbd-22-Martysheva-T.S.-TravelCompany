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
using TravelCompanyContracts.BindingModels;

namespace TravelCompanyView
{
    public partial class FormCompanyConditionsAdding : Form
    {
        ICompanyLogic _logicCompany;

        public FormCompanyConditionsAdding(ICompanyLogic logicCompany, IConditionLogic logicCondition)
        {
            InitializeComponent();

            _logicCompany = logicCompany;

            List<CompanyViewModel> listCompany = logicCompany.Read(null);
            if (listCompany != null)
            {
                comboBoxCompany.DisplayMember = "CompanyName";
                comboBoxCompany.ValueMember = "Id";
                comboBoxCompany.DataSource = listCompany;
                comboBoxCompany.SelectedItem = null;
            }

            List<ConditionViewModel> listCondition = logicCondition.Read(null);
            if (listCondition != null)
            {
                comboBoxCondition.DisplayMember = "ConditionName";
                comboBoxCondition.ValueMember = "Id";
                comboBoxCondition.DataSource = listCondition;
                comboBoxCondition.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxCompany.SelectedValue == null)
            {
                MessageBox.Show("Выберите хранилище", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCondition.SelectedValue == null)
            {
                MessageBox.Show("Выберите условие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logicCompany.AddCondition(new CompanyBindingModel { Id = Convert.ToInt32(comboBoxCompany.SelectedValue) }, 
                Convert.ToInt32(comboBoxCondition.SelectedValue), Convert.ToInt32(textBoxCount.Text));
            
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
