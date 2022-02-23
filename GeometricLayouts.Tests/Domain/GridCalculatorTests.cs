using System;
using Xunit;
using Moq.AutoMock;
using GeometricLayouts.Domain;
using GeometricLayouts.API.Models;

namespace GeometricLayouts.Tests
{
    public class GridCalculatorTests
    {
        private readonly IGridCalculator gridCalculator;

        public GridCalculatorTests()
        {
            gridCalculator = new GridCalculator();
        }

        [Fact]
        public void GetTriangleLocationForE2Test()
        {
            var traingle = new Triangle()
            {
                V1X = 10,
                V1Y = 40,
                V2X = 30,
                V2Y = 40,
                V3X = 40,
                V3Y = 50
            };
            var grid = gridCalculator.GetTriangleLocation(traingle);
            Assert.Equal(2, grid.Column);
            Assert.Equal('E', grid.Row);
        }

        [Fact]
        public void GetTriangleLocationForfdgTest() //test case
        {
            var traingle = new Triangle()
            {
                V1X = 10,
                V1Y = 10,
                V2X = 0,
                V2Y = 10,
                V3X = 10,
                V3Y = 0
            };
            var grid = gridCalculator.GetTriangleLocation(traingle);
            Assert.Equal(2, grid.Column);
            Assert.Equal('B', grid.Row);
        }

        [Fact]
        public void GetTriangleLocationForA12Test()
        {
            var traingle = new Triangle()
            {
                V1X = 50,
                V1Y = 60,
                V2X = 50,
                V2Y = 50,
                V3X = 60,
                V3Y = 60
            };
            var grid = gridCalculator.GetTriangleLocation(traingle);
            Assert.Equal(11, grid.Column);
            Assert.Equal('F', grid.Row);
        }

        [Fact]
        public void GetTriangleLocationForAllZeroVorticesTest()
        {
            var traingle = new Triangle()
            {
                V1X = 0,
                V1Y = 0,
                V2X = 0,
                V2Y = 0,
                V3X = 0,
                V3Y = 0
            };
            var grid = gridCalculator.GetTriangleLocation(traingle);
            Assert.Equal(1, grid.Column);
            Assert.Equal('A', grid.Row);
        }

        [Fact]
        public void GetLeftTraingleVorticesWhenRowColumnPassedTest()
        {
            var grid = new Grid()
            {
                Column = 1,
                Row = 'A'
            };
            var vortices = gridCalculator.GetTriangleVortices(grid);
            Assert.Equal(3, vortices.Count);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 0);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 10);
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 10);
        }

        [Fact]
        public void GetTraingleVorticesWhenSingleReferencePassedTest()
        {
            var grid = new Grid("A1");
            var vortices = gridCalculator.GetTriangleVortices(grid);
            Assert.Equal(3, vortices.Count);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 0);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 10);
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 10);
        }

        [Fact]
        public void GetRightTraingleVorticesWhenRowColumnPassedTest()
        {
            var grid = new Grid()
            {
                Column = 2,
                Row = 'A'
            };
            var vortices = gridCalculator.GetTriangleVortices(grid);
            Assert.Equal(3, vortices.Count);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 0);
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 0);
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 10);
        }
    }
}
