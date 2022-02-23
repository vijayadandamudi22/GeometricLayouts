using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GeometricLayouts.API.Models
{
    public class Grid
    {
        public char Row { get; set; }

        public int Column { get; set; }

        public Grid()
        { }

        public Grid(string rowColumn)
        {
            this.Row = rowColumn.ToCharArray().First();
            this.Column = int.Parse(rowColumn.Substring(1));
        }

        public int GetNumericRow()
        {
            int rowCharacterCode = this.Row;
            return rowCharacterCode - 64;
        }
    }
}
