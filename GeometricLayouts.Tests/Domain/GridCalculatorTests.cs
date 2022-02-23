using System;
using Xunit;
using Moq.AutoMock;
using GeometricLayouts.Domain;
using GeometricLayouts.API.Models;

namespace GeometricLayouts.Tests
{
    public class GridCalculatorTests
    {
        private readonly ICalculator gridCalculator;

        public GridCalculatorTests()
        {
            gridCalculator = new Calculator();
        }

        [Fact]
        public void GetTriangleLocationForE2Test()
        {
            var traingle = new Triangle()
            {
                V1X = 20,
                V1Y = 40,
                V2X = 20,
                V2Y = 50,
                V3X = 30,
                V3Y = 40
            };
            var grid = gridCalculator.GetTriangleLocation(traingle);
            Assert.Equal(5, grid.Column);
            Assert.Equal('E', grid.Row);
        }

        [Fact]
        public void GetTriangleLocationForA12Test()
        {
            var traingle = new Triangle()
            {
                V1X = 50,
                V1Y = 50,
                V2X = 50,
                V2Y = 60,
                V3X = 60,
                V3Y = 50
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
            Assert.Equal('@', grid.Row);
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
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 0);
        }

        [Fact]
        public void GetTraingleVorticesWhenSingleReferencePassedTest()
        {
            var grid = new Grid("A1");
            var vortices = gridCalculator.GetTriangleVortices(grid);
            Assert.Equal(3, vortices.Count);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 0);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 10);
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 0);
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
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 10);
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 0);
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 10);
        }
    }
}
