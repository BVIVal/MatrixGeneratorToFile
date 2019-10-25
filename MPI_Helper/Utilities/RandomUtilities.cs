using System;
using System.Collections.Generic;

namespace MPI_Helper.Utilities
{
    public class RandomUtilities
    {
        public List<double> Matrix { get; set; } = new List<double>();

        public void DoubleRandomsToFile(DataStruct.DataStruct.MatrixSize size, string fileName, double minValue , double maxValue )
        {
            Random random = new Random();
            for (int i = 0; i < size.I; i++)
            {
                for (int j = 0; j < size.J; j++)
                {
                    Matrix.Add(GetRandomNumber(random, minValue, maxValue));
                }
            }

            FileUtilities.ToFile(Matrix, size, fileName);
        }

        public double GetRandomNumber(Random random, double minValue, double maxValue)
        {
            return random.NextDouble() * Math.Abs(maxValue - minValue) + minValue;
        }
    }
}