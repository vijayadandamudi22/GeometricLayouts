using GeometricLayouts.API.Models.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GeometricLayouts.API.Models
{
    [ExcludeFromCodeCoverage]
    public class Coordinates
    {
        [GreaterThanZero]
        public int X { get; set; }

        [GreaterThanZero]
        public int Y { get; set; }
    }
}
