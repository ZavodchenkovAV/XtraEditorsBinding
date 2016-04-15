﻿using System;
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
                searchLookupEdit.Popup -= SearchLookupEdit_Popup;
                searchLookupEdit.Popup += SearchLookupEdit_Popup;
                
                var searchLookupAttr =
                    elementBi.DataInfo.PropertyDescriptor.Attributes[typeof (SearchLookupBindingAttribute)] as
                        SearchLookupBindingAttribute;
                if (searchLookupAttr != null && _dataLayoutControlExt.BindingDataProvider != null)
                        searchLookupEdit.Properties.DataSource =
                            _dataLayoutControlExt.BindingDataProvider.GetData(searchLookupAttr.DataSourceType);
            }
            return ctrl;
        }

        private void SearchLookupEdit_Popup(object sender, EventArgs e)
        {
            SearchLookUpEdit searchLookupEdit = sender as SearchLookUpEdit;
            if (searchLookupEdit.DataBindings.Count == 0 || _dataLayoutControlExt.propertyDescriptors==null) return;

            var field = searchLookupEdit.DataBindings[0].BindingMemberInfo.BindingField;
            var pd = _dataLayoutControlExt.propertyDescriptors[field];

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
                        var fpd = _dataLayoutControlExt.propertyDescriptors[param];

                        var value = fpd.GetValue(_dataLayoutControlExt.Current);
                        values.Add(value);
                    }
                    criteriaOperator = CriteriaOperator.Parse(customFilterAttr.FilterString,values.ToArray());
                }
                else
                    criteriaOperator = CriteriaOperator.Parse(customFilterAttr.FilterString);
                searchLookupEdit.Properties.View.ActiveFilterCriteria = criteriaOperator;
            }
        }        
    }
}
