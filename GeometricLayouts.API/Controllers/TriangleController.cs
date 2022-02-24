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
    public class TriangleController : ControllerBase
    {
        private readonly ILogger<GridController> _logger;
        private readonly ICalculator _gridCalculator;

        public TriangleController(ILogger<GridController> logger, ICalculator gridCalculator)
        {
            _logger = logger;
            _gridCalculator = gridCalculator;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<Coordinates>))]
        public List<Coordinates> Post([FromBody] Grid grid)
        {
            List<Coordinates> coordinates;
            try
            {
                coordinates = _gridCalculator.GetTriangleVortices(grid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while calling grid calculator");
                throw;
            }
            return coordinates;
        }
    }
}
