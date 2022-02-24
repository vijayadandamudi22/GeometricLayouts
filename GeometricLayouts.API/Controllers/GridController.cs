using GeometricLayouts.API.Models;
using GeometricLayouts.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometricLayouts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        private readonly ILogger<GridController> _logger;
        private readonly ICalculator _gridCalculator;

        public GridController(ILogger<GridController> logger, ICalculator gridCalculator)
        {
            _logger = logger;
            _gridCalculator = gridCalculator;
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Grid))]
        public Grid Post([FromBody] Triangle traingle)
        {
            Grid grid;
            try
            {
                grid = _gridCalculator.GetTriangleLocation(traingle);
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while calling grid calculator", ex);
            }
            return grid;
        }
    }
}
