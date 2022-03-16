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
    public partial class FormReportTravelConditions : Form
    {
        private readonly IReportLogic _logic;

        public FormReportTravelConditions(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormReportTravelConditions_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = _logic.GetTravelCondition();
                if (dict != null)
                {
                    dataGridViewTC.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridViewTC.Rows.Add(new object[] { elem.TravelName, "", "" });

                        foreach (var listElem in elem.Conditions)
                        {
                            dataGridViewTC.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridViewTC.Rows.Add(new object[] { "Итого", "", elem.TotalCount });

                        dataGridViewTC.Rows.Add(Array.Empty<object>());
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
                    _logic.SaveTravelConditionToExcelFile(new ReportBindingModel
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
