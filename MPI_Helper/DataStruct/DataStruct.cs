using System.Collections.Generic;

namespace MPI_Helper.DataStruct
{
    public class DataStruct
    {
        public class MatrixSize
        {
            public int I { get; set; }
            public int J { get; set; }
        }

        public MatrixSize Size = new MatrixSize();
        public List<double> Matrix { get; set; } = new List<double>();

    }
}