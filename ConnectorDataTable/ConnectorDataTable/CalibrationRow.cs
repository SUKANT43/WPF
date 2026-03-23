using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorDataTable
{
    public class CalibrationRow
    {
        public int ImageId { get; set; }
        public string Parameter { get; set; }
        public List<float> Values { get; set; }=new List<float>();

    }
}
