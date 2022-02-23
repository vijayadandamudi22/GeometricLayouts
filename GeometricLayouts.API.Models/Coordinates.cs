using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GeometricLayouts.API.Models
{
    [ExcludeFromCodeCoverage]
    public class Coordinates
    {
        [Required]
        public int X { get; set; }

        [Required]
        public int Y { get; set; }
    }
}
