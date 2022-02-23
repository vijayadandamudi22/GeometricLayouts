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
        private readonly IGridCalculator _gridCalculator;

        public GridController(ILogger<GridController> logger, IGridCalculator gridCalculator)
        {
            _logger = logger;
            _gridCalculator = gridCalculator;
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Grid))]
        public Grid Post([FromBody] Triangle traingle) //TODO: may be Iactionresult
        {
            return _gridCalculator.GetTriangleLocation(traingle); //Add logging for bad request
        }
    }
}
