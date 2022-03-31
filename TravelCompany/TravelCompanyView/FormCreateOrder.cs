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


namespace TravelCompanyView
{
    public partial class FormCreateOrder : Form
    {
        private readonly ITravelLogic _logicT;
        private readonly IOrderLogic _logicO;
        private readonly IClientLogic _logicC;
        public FormCreateOrder(ITravelLogic logicT, IOrderLogic logicO, IClientLogic logicC)
        {
            InitializeComponent();
            _logicT = logicT;
            _logicO = logicO;
            _logicC = logicC;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            // прописать логику
            try
            {
                var listT = _logicT.Read(null);
                foreach (var travel in listT)
                {
                    comboBoxTravel.DataSource = listT;
                    comboBoxTravel.DisplayMember = "TravelName";
                    comboBoxTravel.ValueMember = "Id";
                    comboBoxTravel.SelectedItem = null;
                }

                var listC = _logicC.Read(null);
                foreach (var client in listC)
                {
                    comboBoxClient.DataSource = listC;
                    comboBoxClient.DisplayMember = "ClientFIO";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.SelectedItem = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxTravel.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxTravel.SelectedValue);
                    TravelViewModel travel = _logicT.Read(new TravelBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * travel?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxTravel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxTravel.SelectedValue == null)
            {
                MessageBox.Show("Выберите путевку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    TravelId = Convert.ToInt32(comboBoxTravel.SelectedValue),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
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
