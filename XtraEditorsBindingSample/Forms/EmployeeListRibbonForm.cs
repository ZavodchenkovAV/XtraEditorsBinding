using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using XtraEditorsBindingSample.DataModel;

namespace XtraEditorsBindingSample.Forms
{
    public partial class EmployeeListRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public EmployeeListRibbonForm()
        {
            InitializeComponent();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var employee =  gridView1.GetFocusedRow() as Employee;
            using (EmployeeEditForm employeeEditForm = new EmployeeEditForm(employee))
            {
                employeeEditForm.ShowDialog();
            }
        }

        private void bbiFlights_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (TripXtraForm tripXtraForm = new TripXtraForm())
            {
                tripXtraForm.ShowDialog();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var list = new List<Employee>();
            list.Add(new Employee() { LastName = "dfgdf" });
            BindingSource source = new BindingSource();
            source.DataSource = list;
            gridControl1.DataSource = source;
        }
    }
}