using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using XtraEditorsBinding.Attributes;
using System.ComponentModel;
using System.Collections;
using DevExpress.Data.Filtering;

namespace XtraEditorsBinding.DataLayoutControl
{
    public class LayoutCreatorExt: LayoutCreator
    {
        protected DataLayoutControlExt _dataLayoutControlExt;
        public LayoutCreatorExt(DataLayoutControlExt dataLayoutControlExt)
            : base(dataLayoutControlExt)
        {
            _dataLayoutControlExt = dataLayoutControlExt;
        }

        protected override Control CreateBindableControlRunTime(LayoutElementBindingInfo elementBi)
        {
            Control ctrl = base.CreateBindableControlRunTime(elementBi);
            if (ctrl is SearchLookUpEdit)
            {
                var searchLookupEdit = ctrl as SearchLookUpEdit;
                searchLookupEdit.Popup -= LookupEdit_Popup;
                searchLookupEdit.Popup += LookupEdit_Popup;
                
                var searchLookupAttr =
                    elementBi.DataInfo.PropertyDescriptor.Attributes[typeof (SearchLookUpBindingAttribute)] as
                        SearchLookUpBindingAttribute;
                if (searchLookupAttr != null && _dataLayoutControlExt.BindingDataProvider != null)
                        searchLookupEdit.Properties.DataSource =
                            _dataLayoutControlExt.BindingDataProvider.GetData(searchLookupAttr.DataSourceType);
            }
            if (ctrl is TreeListLookUpEdit)
            {
                var treeListLookupEdit = ctrl as TreeListLookUpEdit;
                treeListLookupEdit.Popup -= LookupEdit_Popup;
                treeListLookupEdit.Popup += LookupEdit_Popup;

                var treeListLookupAttr =
                    elementBi.DataInfo.PropertyDescriptor.Attributes[typeof(TreeListLookUpBindingAttribute)] as
                        TreeListLookUpBindingAttribute;
                if (treeListLookupAttr != null && _dataLayoutControlExt.BindingDataProvider != null)
                {
                   treeListLookupEdit.Properties.DataSource =
                            _dataLayoutControlExt.BindingDataProvider.GetData(treeListLookupAttr.DataSourceType);
                }
            }
            return ctrl;
        }

        private void LookupEdit_Popup(object sender, EventArgs e)
        {
            LookUpEditBase lookupEdit = sender as LookUpEditBase;
            if (lookupEdit==null || lookupEdit.DataBindings.Count == 0) return;

            var binding = lookupEdit.DataBindings[0];
            if(binding.BindingManagerBase.Count == 0) return;
            var source = binding.BindingManagerBase.Current;
            if(source ==null) return;
            var memberInfo = binding.BindingMemberInfo;
            var field = memberInfo.BindingField;
            var pdc = TypeDescriptor.GetProperties(source.GetType());
            PropertyDescriptor pd= pdc[field];

            var customFilterAttr = pd.Attributes[typeof(CustomFilterAttribute)] as
                        CustomFilterAttribute;
            if (customFilterAttr != null)
            {
                CriteriaOperator criteriaOperator = null;
                if (!string.IsNullOrEmpty(customFilterAttr.Parameters))
                {
                    var paramList = customFilterAttr.Parameters.Split(',');
                    List<object> values = new List<object>();
                    foreach (var param in paramList)
                    {
                        var fpd = pdc[param];

                        var value = fpd.GetValue(source);
                        values.Add(value);
                    }
                    criteriaOperator = CriteriaOperator.Parse(customFilterAttr.FilterString,values.ToArray());
                }
                else
                    criteriaOperator = CriteriaOperator.Parse(customFilterAttr.FilterString);

                if(lookupEdit is SearchLookUpEdit)
                    (lookupEdit as SearchLookUpEdit).Properties.View.ActiveFilterCriteria = criteriaOperator;
                else if (lookupEdit is TreeListLookUpEdit)
                    (lookupEdit as TreeListLookUpEdit).Properties.TreeList.ActiveFilterCriteria = criteriaOperator;
            }
        }        
    }
}
