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
        private readonly IGridCalculator _gridCalculator; //TODO: make this an interface

        public GridController(ILogger<GridController> logger, IGridCalculator gridCalculator)
        {
            _logger = logger;
            _gridCalculator = gridCalculator;
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Grid))]
        public Grid Post([FromBody] Triangle grid) //TODO: may be Iactionresult
        {
            return _gridCalculator.GetTriangleLocation(grid); //Add logging for bad request
        }

        [HttpPost("triangle")] //TODO: change this route
        [ProducesResponseType(200, Type = typeof(List<Coordinates>))]
        public List<Coordinates> Post([FromBody] Grid grid)
        {
            return _gridCalculator.GetTriangleVortices(grid); //Add logging for bad request
        }
    }
}
