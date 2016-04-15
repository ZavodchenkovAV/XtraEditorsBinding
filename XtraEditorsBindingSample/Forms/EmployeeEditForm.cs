using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtraEditorsBindingSample.BindingDataProvider;
using XtraEditorsBindingSample.DataModel;

namespace XtraEditorsBindingSample.Forms
{
    public partial class EmployeeEditForm : Form
    {
        private readonly Employee _employee;
        public EmployeeEditForm(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
        }

        protected override void OnLoad(EventArgs e)
        {
            var dataProvider = new SimpleEmployeeDataProvider();
            dataLayoutControlExt1.BindingDataProvider = dataProvider;

            var list = new List<Employee>();
            list.Add(_employee);
            BindingSource source = new BindingSource();
            source.DataSource = list;
            dataLayoutControlExt1.DataSource = source;
            dataLayoutControlExt1.RetrieveFields();
        }
    }
}
