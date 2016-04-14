using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using XtraEditorsBinding.Attributes;
using XtraEditorsBinding.Interfaces;

namespace XtraEditorsBinding.DataLayoutControl
{
    public class DataLayoutControlExt: DevExpress.XtraDataLayout.DataLayoutControl, IHasBindingDataProvider
    {
        public IBindingDataProvider BindingDataProvider { get; set; }

        protected override RepositoryItem GetRepositoryItem(LayoutElementBindingInfo bi)
        {
            var searchLookupAttr = bi.DataInfo.PropertyDescriptor.Attributes[typeof(SearchLookupBindingAttribute)] as SearchLookupBindingAttribute;
            if (searchLookupAttr != null)
            {
                bi.EditorType = typeof(SearchLookUpEdit);
                var ri = new RepositoryItemSearchLookUpEdit();
                ri.DisplayMember = searchLookupAttr.DisplayMember;
                ri.ValueMember = searchLookupAttr.ValueMember;
                var customFilterAttr = bi.DataInfo.PropertyDescriptor.Attributes[typeof(CustomFilterAttribute)] as CustomFilterAttribute;
                if(customFilterAttr!=null)
                    ri.View.ActiveFilterString = customFilterAttr.FilterString;
                if(BindingDataProvider!=null)
                    ri.DataSource = BindingDataProvider.GetData(searchLookupAttr.DataSourceType);
                return ri;
            }
            return base.GetRepositoryItem(bi);
        }

        public override LayoutCreator CreateLayoutCreator()
        {
            return new LayoutCreatorExt(this);
        }
    }
}
