using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using XtraEditorsBinding.Attributes;

namespace XtraEditorsBinding.DataLayoutControl
{
    public class LayoutCreatorExt: LayoutCreator
    {
        public LayoutCreatorExt(DataLayoutControlExt dataLayoutControlExt)
            : base(dataLayoutControlExt)
        {
            
        }

        protected override Control CreateBindableControlRunTime(LayoutElementBindingInfo elementBi)
        {
            Control ctrl = base.CreateBindableControlRunTime(elementBi);
            if (ctrl is SearchLookUpEdit)
            {
                var searchLookupEdit = ctrl as SearchLookUpEdit;
                var dataLayoutControlExt = dataLayoutControl as DataLayoutControlExt;
                var searchLookupAttr =
                    elementBi.DataInfo.PropertyDescriptor.Attributes[typeof (SearchLookupBindingAttribute)] as
                        SearchLookupBindingAttribute;
                if (searchLookupAttr != null)
                    if (dataLayoutControlExt != null && dataLayoutControlExt.BindingDataProvider != null)
                        searchLookupEdit.Properties.DataSource =
                            dataLayoutControlExt.BindingDataProvider.GetData(searchLookupAttr.DataSourceType);
                var customFilterAttr =
                    elementBi.DataInfo.PropertyDescriptor.Attributes[typeof (CustomFilterAttribute)] as
                        CustomFilterAttribute;
                if (customFilterAttr != null)
                {
                    searchLookupEdit.Properties.View.ActiveFilterString = customFilterAttr.FilterString;
                }
            }
            return ctrl;
        }
    }
}
