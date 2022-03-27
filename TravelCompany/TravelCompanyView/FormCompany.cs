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
    public partial class FormCompany : Form
    {
        public int Id { set { id = value; } }
        private readonly ICompanyLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> companyConditions;

        public FormCompany(ICompanyLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormCompany_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CompanyViewModel view = _logic.Read(new CompanyBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.CompanyName;
                        textBoxNameResp.Text = view.NameResponsible;
                        companyConditions = view.CompanyConditions;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                companyConditions = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (companyConditions != null)
                {
                    dataGridViewConditions.Rows.Clear();
                    foreach (var cc in companyConditions)
                    {
                        dataGridViewConditions.Rows.Add(new object[] { cc.Key, cc.Value.Item1, cc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxNameResp.Text))
            {
                MessageBox.Show("Заполните ФИО ответственного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _logic.CreateOrUpdate(new CompanyBindingModel
                {
                    Id = id,
                    CompanyName = textBoxName.Text,
                    NameResponsible = textBoxNameResp.Text,
                    CompanyConditions = companyConditions,
                    DateCreate = DateTime.Now
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
