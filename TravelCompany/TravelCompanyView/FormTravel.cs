using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.ViewModels;
using Unity;

namespace TravelCompanyView
{
    public partial class FormTravel : Form
    {
        public int Id { set { id = value; } }
        private readonly ITravelLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> travelConditions;

        public FormTravel(ITravelLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }


        private void FormTravel_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    TravelViewModel view = _logic.Read(new TravelBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxNameTravel.Text = view.TravelName;
                        textBoxPrice.Text = view.Price.ToString();
                        travelConditions = view.TravelConditions;
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
                travelConditions = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (travelConditions != null)
                {
                    dataGridViewConditions.Rows.Clear();
                    foreach (var tc in travelConditions)
                    {
                        dataGridViewConditions.Rows.Add(new object[] { tc.Key, tc.Value.Item1, tc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormTravelCondition>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (travelConditions.ContainsKey(form.Id))
                {
                    travelConditions[form.Id] = (form.ConditionName, form.Count);
                }
                else
                {
                    travelConditions.Add(form.Id, (form.ConditionName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewConditions.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormTravelCondition>();
                int id = Convert.ToInt32(dataGridViewConditions.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = travelConditions[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    travelConditions[form.Id] = (form.ConditionName, form.Count);
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewConditions.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        travelConditions.Remove(Convert.ToInt32(dataGridViewConditions.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNameTravel.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (travelConditions == null || travelConditions.Count == 0)
            {
                MessageBox.Show("Заполните условия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new TravelBindingModel
                {
                    Id = id,
                    TravelName = textBoxNameTravel.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    TravelConditions = travelConditions
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
