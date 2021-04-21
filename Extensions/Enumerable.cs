using System;
using System.Globalization;
using System.Collections.Generic;

namespace LaboratoryWork.Extensions
{
  public static class Enumerable
  {
    public static IEnumerable<T> Print<T>(this IEnumerable<T> sequence, string delimiter = "")
    {
      if (sequence == null)
        throw new ArgumentNullException(nameof(sequence), "sequence can't be null");
      
      IEnumerator<T> enumerator = sequence.GetEnumerator();
      if (!enumerator.MoveNext())
          return sequence;

      Console.Write(enumerator.Current);

      while (enumerator.MoveNext())
          Console.Write("{0}{1}", delimiter, enumerator.Current);

      return sequence;
    }

    public static IEnumerable<T> PrintLine<T>(this IEnumerable<T> sequence, string delimiter = "")
    {
      if (sequence == null)
        throw new ArgumentNullException(nameof(sequence), "sequence can't be null");

      sequence.Print(delimiter);
      Console.WriteLine();
      return sequence;
    }
  }
}
