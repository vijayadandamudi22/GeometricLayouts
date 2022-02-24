using GeometricLayouts.API.Models;
using System;
using System.Collections.Generic;

namespace GeometricLayouts.Domain
{
    public class Calculator: ICalculator
    {
        private const int CELLSIZE = 10;

        public Grid GetTriangleLocation(Triangle traingle)
        {
            var row = traingle.V2Y / CELLSIZE;
            var column = (traingle.V1X / CELLSIZE) * 2;
            if(traingle.V2X == traingle.V1X)
            {
                column++;
            }
            return new Grid { Row = (char)(64 + row), Column = column, RowColumn = $"{(char)(64 + row)}{column}" };
        }

        public List<Coordinates> GetTriangleVortices(Grid grid)
        {
            if(!string.IsNullOrEmpty(grid.RowColumn))
            {
               grid = new Grid(grid.RowColumn);
            }

            if(grid?.Column % 2 == 0)
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
            var topLeftY = grid.GetNumericRow() * CELLSIZE;
            var bottomY = (grid.GetNumericRow() - 1) * CELLSIZE;
            var bottomRightX = leftX + CELLSIZE;

            coordinates.Add(new Coordinates { X = leftX, Y = bottomY });
            coordinates.Add(new Coordinates { X = leftX, Y = topLeftY });
            coordinates.Add(new Coordinates { X = bottomRightX, Y = bottomY });
            return coordinates;
        }

        private List<Coordinates> GetRightTriangleVortices(Grid grid)
        {
            var coordinates = new List<Coordinates>();
            var topLeftX = ((grid.Column / 2) - 1) * CELLSIZE;
            var leftY = grid.GetNumericRow() * CELLSIZE;
            var rightX = topLeftX + CELLSIZE;
            var bottomRightY = leftY - CELLSIZE;

            coordinates.Add(new Coordinates { X = rightX, Y = leftY });
            coordinates.Add(new Coordinates { X = topLeftX, Y = leftY });
            coordinates.Add(new Coordinates { X = rightX, Y = bottomRightY });

            return coordinates;
        }
    }
}
