using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XtraEditorsBindingSample.BindingDataProvider;
using XtraEditorsBindingSample.DataModel;

namespace XtraEditorsBindingSample.Forms
{
    public partial class TripXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public TripXtraForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            var dataProvider = new SimpleEmployeeDataProvider();
            dataLayoutControlExt1.BindingDataProvider = dataProvider;

            var list = new List<Trip>();
            list.Add(new Trip());
            BindingSource source = new BindingSource();
            source.DataSource = list;
            dataLayoutControlExt1.DataSource = source;
            dataLayoutControlExt1.RetrieveFields();
        }
    }
}