using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using XtraEditorsBinding.BindingAttributes;
using XtraEditorsBinding.Interfaces;

namespace XtraEditorsBinding.DataLayoutControl
{
    public class DataLayoutControlExt: DevExpress.XtraDataLayout.DataLayoutControl, IHasBindingDataProvider
    {
        public IBindingDataProvider BindingDataProvider { get; set; }

        protected override RepositoryItem GetRepositoryItem(LayoutElementBindingInfo bi)
        {
            var attr = bi.DataInfo.PropertyDescriptor.Attributes[typeof(SearchLookupBindingAttribute)] as SearchLookupBindingAttribute;
            if (attr != null)
            {
                bi.EditorType = typeof(SearchLookUpEdit);
                var ri = new RepositoryItemSearchLookUpEdit();
                ri.DisplayMember = attr.DisplayMember;
                ri.ValueMember = attr.ValueMember;
                if(BindingDataProvider!=null)
                    ri.DataSource = BindingDataProvider.GetData(attr.DataSourceType);
                return ri;
            }
            return base.GetRepositoryItem(bi);
        }
    }
}
