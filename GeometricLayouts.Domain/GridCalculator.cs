using GeometricLayouts.API.Models;
using System;
using System.Collections.Generic;

namespace GeometricLayouts.Domain
{
    public class GridCalculator: IGridCalculator
    {
        private const int CELLSIZE = 10;

        public Grid GetTriangleLocation(Triangle traingle)
        {
            var row = traingle.V1Y / CELLSIZE;
            if (traingle.V2Y == traingle.V1Y) //left traingle
            {
                row++;
            }
            var column = (traingle.V1X / CELLSIZE) * 2;
            if(traingle.V2X == traingle.V1X) //right traingle
            {
                column++;
            }
            return new Grid { Row = (char)(64 + row), Column = column};
        }

        public List<Coordinates> GetTriangleVortices(Grid grid)
        {
            if(!string.IsNullOrEmpty(grid.RowColumn))
            {
                new Grid(grid.RowColumn);
            }

            if(grid.Column % 2 == 0)
            {
                return GetRightTriangleVortices(grid);
            }
            else
            {
                return GetLeftTriangleVortices(grid);
            }
        }

        private List<Coordinates> GetLeftTriangleVortices(Grid grid)
        {
            var coordinates = new List<Coordinates>();
            var leftX = ((grid.Column - 1) * CELLSIZE) / 2;
            var bottomY = grid.GetNumericRow() * CELLSIZE;
            var topLeftY = (grid.GetNumericRow() - 1) * CELLSIZE;
            var bottomRightX = leftX + CELLSIZE;

            coordinates.Add(new Coordinates { X = leftX, Y = topLeftY });
            coordinates.Add(new Coordinates { X = leftX, Y = bottomY });
            coordinates.Add(new Coordinates { X = bottomRightX, Y = bottomY });
            return coordinates;
        }

        private List<Coordinates> GetRightTriangleVortices(Grid grid)
        {
            var coordinates = new List<Coordinates>();
            var topLeftX = (((grid.Column / 2) - 1) * CELLSIZE);
            var leftY = (grid.GetNumericRow() - 1) * CELLSIZE;
            var bottomX = topLeftX + CELLSIZE;
            var bottomRightY = leftY + CELLSIZE;

            coordinates.Add(new Coordinates { X = topLeftX, Y = leftY });
            coordinates.Add(new Coordinates { X = bottomX, Y = leftY });
            coordinates.Add(new Coordinates { X = bottomX, Y = bottomRightY });

            return coordinates;
        }
    }
}
