using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorDataTable
{
    public static class DataProvider
    {

        public static List<CalibrationRow> BuilRows(CalibrationMeasurement data, string axis, Dictionary<int, int> chamberPinMap)
        {
            var rows = new List<CalibrationRow>();
            foreach (var image in data.CalibrationMeasurementCollection.OrderBy(x => x.Key))
            {
                int imageId = image.Key;

                var row = new CalibrationRow()
                {
                    ImageId = imageId,
                    Parameter = axis
                };

                foreach (var chamberInfo in chamberPinMap.OrderBy(x => x.Key))
                {
                    int chamberId = chamberInfo.Key;
                    int maxPins = chamberInfo.Value;

                    if (image.Value.ContainsKey(chamberId))
                    {
                        var chamber = image.Value[chamberId];

                        for (int pinId = 1; pinId <= maxPins; pinId++)
                        {
                            if (chamber.CalibrationMeasurements.ContainsKey(pinId))
                            {
                                var pin = chamber.CalibrationMeasurements[pinId];

                                float value;

                                switch (axis)
                                {
                                    case "X":
                                        value = pin.XMeasure;
                                        break;

                                    case "Y":
                                        value = pin.YMeasure;
                                        break;

                                    case "Z":
                                        value = pin.ZMeasure;
                                        break;

                                    default:
                                        value = 0;
                                        break;
                                }

                                row.Values.Add(value);
                            }
                            else
                            {
                                row.Values.Add(0);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < maxPins; i++)
                            row.Values.Add(0);
                    }
                }

                rows.Add(row);
            }
            return rows;
        }
        public class CalibrationMeasurement
        {

            public static CalibrationMeasurement GetData()
            {
                return new CalibrationMeasurement(10, 70)
                {
                    CalibrationMeasurementCollection = new Dictionary<int, Dictionary<int, CalibrationMeasurementSet>>()
                    {
                        {1,new Dictionary<int, CalibrationMeasurementSet>()
                        {
                            {
                                1,new CalibrationMeasurementSet(5)
                                {
                                    CalibrationMeasurements=new Dictionary<int, CalibrationMeasurementData>()
                                    {
                                       { 1, new CalibrationMeasurementData() { XMeasure = 10, YMeasure = 20, ZMeasure = 30 } },
                                       { 2, new CalibrationMeasurementData() { XMeasure = 11 ,ZMeasure = 31 } },
                                       { 3, new CalibrationMeasurementData() { XMeasure = 12, YMeasure = 22, ZMeasure = 32 } },
                                       { 4, new CalibrationMeasurementData() { XMeasure = 13, YMeasure = 23, ZMeasure = 33 } },
                                    }
                                }
                            },
                            {2,new CalibrationMeasurementSet(3)
                            {
                                CalibrationMeasurements=new Dictionary<int, CalibrationMeasurementData>
                                {
                                     { 1, new CalibrationMeasurementData() { XMeasure = 10, YMeasure = 20, ZMeasure = 30 } },
                                     { 2, new CalibrationMeasurementData() { XMeasure = 11, YMeasure = 21, ZMeasure = 31 } },
                                     { 3, new CalibrationMeasurementData() { XMeasure = 12, YMeasure = 22, ZMeasure = 32 } }
                                }
                            }
                            }
                        }
                        },

                        {2, new Dictionary<int, CalibrationMeasurementSet>()
                            {
                                { 1, new CalibrationMeasurementSet(5)
                                        {
                                            CalibrationMeasurements = new Dictionary<int, CalibrationMeasurementData>()
                                            {
                                                { 1, new CalibrationMeasurementData() { XMeasure = 10, YMeasure = 20, ZMeasure = 30 } },
                                                { 2, new CalibrationMeasurementData() { XMeasure = 11, YMeasure = 21, ZMeasure = 31 } },
                                                { 3, new CalibrationMeasurementData() { XMeasure = 12, YMeasure = 22, ZMeasure = 32 } },
                                                { 4, new CalibrationMeasurementData() { XMeasure = 13, YMeasure = 23, ZMeasure = 33 } },
                                                { 5, new CalibrationMeasurementData() { XMeasure = 14, YMeasure = 24, ZMeasure = 34 } }
                                            }
                                        }
                                },
                                { 2, new CalibrationMeasurementSet(3)
                                        {
                                            CalibrationMeasurements = new Dictionary<int, CalibrationMeasurementData>()
                                            {
                                                { 1, new CalibrationMeasurementData() { XMeasure = 10, YMeasure = 20, ZMeasure = 30 } },
                                                { 2, new CalibrationMeasurementData() { XMeasure = 11, YMeasure = 21, ZMeasure = 31 } },
                                            }
                                        }
                                }
                            }
                     },
                         {3, new Dictionary<int, CalibrationMeasurementSet>()
                            {
                                { 1, new CalibrationMeasurementSet(5)
                                        {
                                            CalibrationMeasurements = new Dictionary<int, CalibrationMeasurementData>()
                                            {
                                                { 3, new CalibrationMeasurementData() { XMeasure = 12, YMeasure = 22, ZMeasure = 32 } },
                                                { 4, new CalibrationMeasurementData() { XMeasure = 13, YMeasure = 23, ZMeasure = 33 } },
                                                { 5, new CalibrationMeasurementData() { XMeasure = 14, YMeasure = 24, ZMeasure = 34 } }
                                            }
                                        }
                                },
                                { 2, new CalibrationMeasurementSet(3)
                                        {
                                            CalibrationMeasurements = new Dictionary<int, CalibrationMeasurementData>()
                                            {
                                                { 1, new CalibrationMeasurementData() { XMeasure = 10, YMeasure = 20, ZMeasure = 30 } },
                                                { 2, new CalibrationMeasurementData() { XMeasure = 11, YMeasure = 21, ZMeasure = 31 } },
                                            }
                                        }
                                }
                            }
                     },
                          {4, new Dictionary<int, CalibrationMeasurementSet>()
                            {
                                { 1, new CalibrationMeasurementSet(5)
                                        {
                                            CalibrationMeasurements = new Dictionary<int, CalibrationMeasurementData>()
                                            {
                                                { 3, new CalibrationMeasurementData() { XMeasure = 12, YMeasure = 22, ZMeasure = 32 } },
                                                { 4, new CalibrationMeasurementData() { XMeasure = 13, YMeasure = 23, ZMeasure = 33 } },
                                                { 5, new CalibrationMeasurementData() { XMeasure = 14, YMeasure = 24, ZMeasure = 34 } }
                                            }
                                        }
                                },
                                { 2, new CalibrationMeasurementSet(3)
                                        {
                                            CalibrationMeasurements = new Dictionary<int, CalibrationMeasurementData>()
                                            {
                                                { 1, new CalibrationMeasurementData() { XMeasure = 10, YMeasure = 20, ZMeasure = 30 } },
                                            }
                                        }
                                }
                            }
                     },

                    }
                };
            }

            public CalibrationMeasurement(int imageCount, int pinCount)
            {
                ImageCount = imageCount;
                PinCount = pinCount;
            }
            public int ImageCount { get; set; }
            public int PinCount { get; set; }

            public Dictionary<int, Dictionary<int, CalibrationMeasurementSet>> CalibrationMeasurementCollection { get; set; } = new Dictionary<int, Dictionary<int, CalibrationMeasurementSet>>();

            public Dictionary<int, CalibrationMeasurementSet> CalibrationMeasurementHeaders =>
                CalibrationMeasurementCollection.Values.FirstOrDefault();

            public Dictionary<int, Dictionary<int, CalibrationMeasurementSet>> CalibrationMeasurementRows =>
                CalibrationMeasurementCollection;

            public void Clear()
            {
                CalibrationMeasurementCollection?.Clear();
            }

        }

        public class CalibrationMeasurementSet
        {
            public CalibrationMeasurementSet(int pincCount)
            {
                PinCount = pincCount;
            }
            public int PinCount { get; set; }
            public int ImageId { get; set; }

            public bool CalibrationStatus { get; set; }


            public Dictionary<int, CalibrationMeasurementData> CalibrationMeasurements { get; set; } =
                new Dictionary<int, CalibrationMeasurementData>();

            public void Clear()
            {
                CalibrationMeasurements?.Clear();
            }

        }

        public class CalibrationMeasurementData
        {
            public float XMeasure { get; set; }
            public float YMeasure { get; set; }
            public float ZMeasure { get; set; }
        }

    }
}
