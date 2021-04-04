using System;
using System.Linq;
using System.Collections.Generic;
using LaboratoryWork.Utils;
using LaboratoryWork.Extensions;

namespace LaboratoryWork
{
  internal static class MainClass
  {
    private static void ProcessMatrix(double[,] matrix, string matrixName)
    {
      if (matrix == null)
        throw new ArgumentNullException(nameof(matrix), "matrix can't be null");
      if (matrixName == null)
        throw new ArgumentNullException(nameof(matrixName), "matrix name can't be null");

      Console.WriteLine("Processing {0} matrix...", matrixName);

      IEnumerable<double> sequence = matrix.ToEnumerable();
      if (sequence.Count(item => item < 0) > sequence.Count(item => item >= 0))
        matrix.ToRows().Select(row => row.Where(item => item > 0).Sum()).PrintLine(", ").ToArray();
      else
        Console.WriteLine("positive item count is greater or equal to negative one.");
    }

    private static void Main()
    {
      int rowCount = Base.ReadInt32("Please enter row count value: ");
      int columnCount = Base.ReadInt32("Please enter column count value: ");
      double[,] a = LaboratoryWork.Utils.Matrix.ReadDouble(rowCount, columnCount, "Please enter a[{0}, {1}] value: ").PrintLine(", ");
      double[,] b = LaboratoryWork.Utils.Matrix.ReadDouble(rowCount, columnCount, "Please enter b[{0}, {1}] value: ").PrintLine(", ");
      
      Dictionary<string, double[,]> dictionary = new Dictionary<string, double[,]>()
      {
        { nameof(a), a },
        { nameof(b), b }
      };

      foreach (var pair in dictionary)
        ProcessMatrix(pair.Value, pair.Key);
    }
  }
}
