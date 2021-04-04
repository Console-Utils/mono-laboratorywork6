using System;
using System.Globalization;

namespace LaboratoryWork.Utils
{
  public static class Matrix
  {
    public static double[,] ReadDouble(int rowCount, int columnCount, string prompt = "")
    {
      if (rowCount < 0)
        throw new ArgumentOutOfRangeException(nameof(rowCount), "matrix row count can't be negative");
      if (columnCount < 0)
        throw new ArgumentOutOfRangeException(nameof(columnCount), "matrix column count can't be negative");
      
      double[,] result = new double[rowCount, columnCount];
      for (var i = 0; i < rowCount; i++)
        for (var j = 0; j < columnCount; j++)
          result[i, j] = Base.ReadDouble(string.Format(CultureInfo.CurrentCulture, prompt, i, j));
      return result;
    }
  }
}
