using System;
using System.Collections.Generic;
using NASA.Mars.Shared.Exceptions;

namespace NASA.Mars.Domain
{
    public class Plateau
    {

        public readonly int dimX;
        public readonly int dimY;


        public Plateau(string dimensions)
        {
            if (string.IsNullOrEmpty(dimensions) || string.IsNullOrWhiteSpace(dimensions))
            {
                throw new ArgumentException("Dimensions can not be null or empty");
            }

            string[] parts = dimensions.Split(" ");
            if (parts.Length > 3 || parts.Length < 1)
            {
                throw new InvalidDimensionException(dimensions);
            }

            int _dimX = 0;
            if (!int.TryParse(parts[0], out _dimX))
            {
                throw new InvalidDimensionConvertException(parts[0]);
            }

            int _dimY = 0;
            if (!int.TryParse(parts[1], out _dimY))
            {
                throw new InvalidDimensionConvertException(parts[1]);
            }

            if (_dimX < 0)
            {
                throw new InvalidDimensionConvertException(parts[0]);
            }

            if (_dimY < 0)
            {
                throw new InvalidDimensionConvertException(parts[1]);
            }


            this.dimX = _dimX;
            this.dimY = _dimY;
        }
    }
}