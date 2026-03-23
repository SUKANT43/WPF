using System.Collections.Generic;

namespace DynamicDataGridChange
{
    public static class DataProvider
    {
        public static Dictionary<int, List<Measurement>> Data =
            new Dictionary<int, List<Measurement>>()
        {
            {
                1, new List<Measurement>()
                {
                    new Measurement { XAxis = 10, YAxis = 20, ZAxis = 30 },
                    new Measurement { XAxis = 11, YAxis = 21 },
                    new Measurement { XAxis = 12, YAxis = 22, ZAxis = 32 },
                    new Measurement { XAxis = 13, YAxis = 23 },
                    new Measurement { XAxis = 14, YAxis = 24, ZAxis = 34 }
                }
            },
            {
                2, new List<Measurement>()
                {
                    new Measurement { XAxis = 15, YAxis = 25, ZAxis = 35 },
                    new Measurement { XAxis = 16, YAxis = 26 },
                    new Measurement { XAxis = 17, YAxis = 27, ZAxis = 37 }
                }
            },
            {
                3, new List<Measurement>()
                {
                    new Measurement { XAxis = 18, YAxis = 28, ZAxis = 38 },
                    new Measurement { XAxis = 19, YAxis = 29, ZAxis = 39 },
                    new Measurement { XAxis = 20, YAxis = 30 },
                    new Measurement { XAxis = 21, YAxis = 31 },
                    new Measurement { XAxis = 22, YAxis = 32, ZAxis = 42 },
                    new Measurement { XAxis = 23, YAxis = 33 }
                }
            }
        };
    }

    public class Measurement
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public int? ZAxis { get; set; } // nullable
    }

    public class RowData
    {
        public int ImageId { get; set; }
        public List<int> Values { get; set; } = new List<int>();
    }
}