using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XtraEditorsBindingSample.DataModel
{
    public class City
    {
        public long CityId { get; set; }
        public long CountryId { get; set; }
        public string Name { get; set; }

        [Browsable(false)]
        public bool Deleted { get; set; }
    }
}
