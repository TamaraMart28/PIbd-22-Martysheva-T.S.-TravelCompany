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

namespace TravelCompanyView
{
    public partial class FormReportCompanyConditions : Form
    {
        private readonly IReportLogic _logic;

        public FormReportCompanyConditions(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormReportCompanyConditions_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = _logic.GetCompanyCondition();
                if (dict != null)
                {
                    dataGridViewCC.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridViewCC.Rows.Add(new object[] { elem.CompanyName, "", "" });

                        foreach (var listElem in elem.Conditions)
                        {
                            dataGridViewCC.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridViewCC.Rows.Add(new object[] { "Итого", "", elem.TotalCount });

                        dataGridViewCC.Rows.Add(Array.Empty<object>());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveCompanyConditionToExcelFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
