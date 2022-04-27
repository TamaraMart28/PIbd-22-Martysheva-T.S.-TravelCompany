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

namespace TravelCompanyView
{
    public partial class FormMessages : Form
    {
        private readonly IMessageInfoLogic _logic;
        public FormMessages(IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            var list = _logic.Read(null);
            if (list != null)
            {
                dataGridViewM.DataSource = list;
                dataGridViewM.Columns[0].Visible = false;
                dataGridViewM.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
