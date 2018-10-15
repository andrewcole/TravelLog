using System;
using System.Collections.Generic;

namespace Illallangi.TravelLog.GreatCircles
{
    public interface IGreatCircle
    {
        List<Tuple<double, double>> Points { get; }
    }
}
