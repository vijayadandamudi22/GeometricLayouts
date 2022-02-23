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
        private readonly IGridCalculator _gridCalculator;

        public TriangleController(ILogger<GridController> logger, IGridCalculator gridCalculator)
        {
            _logger = logger;
            _gridCalculator = gridCalculator;
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<Coordinates>))]
        public List<Coordinates> Post([FromBody] Grid grid)
        {
            return _gridCalculator.GetTriangleVortices(grid); //TODO: Add logging for bad request
        }
    }
}
