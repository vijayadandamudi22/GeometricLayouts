using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GeometricLayouts.API.Models
{
    [ExcludeFromCodeCoverage]
    public class Triangle
    {
        [Required]
        public int V1X { get; set; }

        [Required]
        public int V1Y { get; set; }

        [Required]
        public int V2X { get; set; }

        [Required]
        public int V2Y { get; set; }

        [Required]
        public int V3X { get; set; }

        [Required]
        public int V3Y { get; set; }
    }
}
