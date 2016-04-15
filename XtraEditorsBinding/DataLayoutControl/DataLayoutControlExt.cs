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
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;

namespace XtraEditorsBinding.DataLayoutControl
{
    public class DataLayoutControlExt: DevExpress.XtraDataLayout.DataLayoutControl, IHasBindingDataProvider
    {
        public IBindingDataProvider BindingDataProvider { get; set; }
        protected internal PropertyDescriptorCollection propertyDescriptors;

        protected override RepositoryItem GetRepositoryItem(LayoutElementBindingInfo bi)
        {
            var searchLookupAttr = bi.DataInfo.PropertyDescriptor.Attributes[typeof(SearchLookupBindingAttribute)] as SearchLookupBindingAttribute;
            if (searchLookupAttr != null)
            {
                bi.EditorType = typeof(SearchLookUpEdit);
                var ri = new RepositoryItemSearchLookUpEdit();
                ri.DisplayMember = searchLookupAttr.DisplayMember;
                ri.ValueMember = searchLookupAttr.ValueMember;
                return ri;
            }
            return base.GetRepositoryItem(bi);
        }

        public override LayoutCreator CreateLayoutCreator()
        {
            return new LayoutCreatorExt(this);
        }
        public override object DataSource
        {
            get
            {
                return base.DataSource;
            }

            set
            {
                base.DataSource = value;
                if (value is BindingSource)
                {
                    BindingSource bs = value as BindingSource;
                    if (bs.Current != null)
                    {
                        propertyDescriptors = TypeDescriptor.GetProperties(bs.Current);
                    }
                }
            }
        }

        public object Current
        {
            get
            {
                if (DataSource != null && DataSource is BindingSource)
                {
                    BindingSource bs = DataSource as BindingSource;
                    return bs.Current;
                }
                return null;
            }
        }
    }
}
