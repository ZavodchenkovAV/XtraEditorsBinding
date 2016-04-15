using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XtraEditorsBinding.Attributes
{
    public class SearchLookUpBindingAttribute: Attribute
    {
        public string ValueMember { get; set; }
        public string DisplayMember { get; set; }
        public Type DataSourceType { get; set; }
    }
}
