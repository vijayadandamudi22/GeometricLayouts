using GeometricLayouts.API.Models;
using GeometricLayouts.Controllers;
using GeometricLayouts.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GeometricLayouts.Tests.API.Controller
{
    public class GridControllerTests
    {
        private readonly AutoMocker mocker;

        public GridControllerTests()
        {
            mocker = new AutoMocker();
        }

        [Fact]
        public void GridControllerVerifyTest()
        {
            var grid = new Grid()
            {
                Row = 'A',
                Column = 1
            };
            var traingle = new Triangle();
            var mockGridCalculator = mocker.GetMock<ICalculator>();
            mockGridCalculator
                .Setup(x => x.GetTriangleLocation(It.IsAny<Triangle>()))
                .Returns(grid)
                .Verifiable();

            var controller = mocker.CreateInstance<GridController>();
            var actual = controller.Post(traingle);

            Assert.Equal(grid.Row, actual.Row);
            Assert.Equal(grid.Column, actual.Column);
            mockGridCalculator.Verify(a => a.GetTriangleLocation(traingle), Times.Once());
        }
    }
}
