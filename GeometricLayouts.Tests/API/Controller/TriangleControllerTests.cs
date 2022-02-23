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
    public class TriangleControllerTests
    {
        private readonly AutoMocker mocker;

        public TriangleControllerTests()
        {
            mocker = new AutoMocker();
        }

        [Fact]
        public void TriangleControllerVerifyTest()
        {
            var grid = new Grid();
            var coordinates = new List<Coordinates>();
            var mockGridCalculator = mocker.GetMock<ICalculator>();
            mockGridCalculator
                .Setup(x => x.GetTriangleVortices(It.IsAny<Grid>()))
                .Returns(coordinates)
                .Verifiable();

            var controller = mocker.CreateInstance<TriangleController>();
            var actual = controller.Post(grid);

            mockGridCalculator.Verify(a => a.GetTriangleVortices(grid), Times.Once());
        }
    }
}
