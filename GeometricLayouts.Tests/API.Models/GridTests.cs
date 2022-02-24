using GeometricLayouts.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GeometricLayouts.Tests.API.Models
{
    public class GridTests
    {
        [Theory]
        [InlineData("E1", 'E', 1)]
        [InlineData("A4", 'A', 4)]
        public void GetRowColumnTest(string rowColumn, char row, int column)
        {
            var grid = new Grid(rowColumn);
            Assert.Equal(row, grid.Row);
            Assert.Equal(column, grid.Column);
        }

        [Fact]
        public void GetRowColumnThrowsColumnArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new Grid(""); });
        }

        [Fact]
        public void GetRowColumnThrowsRowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { new Grid(null); });
        }

        [Theory]
        [InlineData('E', 5)]
        [InlineData('A', 1)]
        [InlineData('@', 0)]
        public void GetNumericRowTest(char row, int rowNumber)
        {
            var result = new Grid()
            {
                Row = row
            }.GetNumericRow();

            Assert.Equal(rowNumber, result);
        }
    }
}
