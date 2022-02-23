using GeometricLayouts.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricLayouts.Domain
{
    public interface ICalculator
    {
        Grid GetTriangleLocation(Triangle traingle);
        List<Coordinates> GetTriangleVortices(Grid grid);
    }
}
