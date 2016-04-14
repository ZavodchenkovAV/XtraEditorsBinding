using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XtraEditorsBinding.Attributes
{
    public class CustomFilterAttribute:Attribute
    {
        public string FilterString { get; set; }
        public string SourceKeyField { get; set; }
        public string ForeignKeyField { get; set; }
    }
}
