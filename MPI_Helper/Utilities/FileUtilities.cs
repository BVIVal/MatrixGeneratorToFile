using System;
using System.Collections.Generic;
using System.IO;

namespace MPI_Helper.Utilities
{
    public static class FileUtilities
    {
        public static void ToFile(List<double> text, DataStruct.DataStruct.MatrixSize size, string fileName)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream($"{fileName}.dat",
                FileMode.Create, FileAccess.ReadWrite)))
            {
                bw.Write(size.I);
                bw.Write(size.J);

                bw.WriteListDouble(text);
            }
        }

        // ReSharper disable once UnusedTypeParameter
        public static bool FromFile<T>(string fileName, out DataStruct.DataStruct dataStruct)
        {
            dataStruct = new DataStruct.DataStruct();

            if (File.Exists(fileName))
            {
                using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    dataStruct.Size.I = br.ReadInt32();
                    dataStruct.Size.J = br.ReadInt32();

                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        dataStruct.Matrix.Add(br.ReadDouble());
                    }

                }

                return true;
            }

            return false;
        }

        public static void WriteDataStructInConsole(this DataStruct.DataStruct dataStruct)
        {
            Console.Write($"{dataStruct.Size.I} ");
            Console.Write($"{dataStruct.Size.J} ");
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < dataStruct.Size.J; i++)
            {
                for (int j = 0; j < dataStruct.Size.I; j++)
                {
                    Console.Write($"{dataStruct.Matrix[i * dataStruct.Size.I + j]} ");
                }

                Console.WriteLine();
            }
        }

        public static void WriteListDouble(this BinaryWriter bw, List<double> value)
        {
            foreach (var element in value)
            {
                bw.Write(element);
            }
        }
    }
}
