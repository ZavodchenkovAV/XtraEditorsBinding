using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraDataLayout;

namespace XtraEditorsBinding.DataLayoutControl
{
    public class LayoutCreatorExt: LayoutCreator
    {
        public LayoutCreatorExt(DataLayoutControlExt dataLayoutControlExt)
            : base(dataLayoutControlExt)
        {
            
        }

        protected override Control CreateBindableControlDesignTime(LayoutElementBindingInfo elementBi)
        {
            return base.CreateBindableControlDesignTime(elementBi);
        }

        protected override Control CreateBindableControlRunTime(LayoutElementBindingInfo elementBi)
        {
            return base.CreateBindableControlRunTime(elementBi);
        }
    }
}
