using System;
using MPI_Helper.Utilities;

namespace MPI_Helper
{
    class Program
    {
        public static string SettingsFileName { get; set; } = "EntryMatrixDouble";

        public static DataStruct.DataStruct.MatrixSize Size = new DataStruct.DataStruct.MatrixSize {I = 500, J = 500};
        public static double MinValue { get; set; } = -10.10d;
        public static double MaxValue { get; set; } = 10.10d;


        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            var randomUtilities = new RandomUtilities();
            randomUtilities.DoubleRandomsToFile(Size, SettingsFileName, MinValue, MaxValue);

            if (!FileUtilities.FromFile<double>($"{SettingsFileName}.dat", out var dataStruct)) return;
            dataStruct.WriteDataStructInConsole();

            Console.ReadLine();
        }
    }
}
