using System;
using System.Collections.Generic;

public static class LinqExtension
{
   public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> action)
   {
      using (var iterator = source.GetEnumerator())
      {
         while (iterator.MoveNext())
         {
            action(iterator.Current);
         }
      }

      using (var iterator = source.GetEnumerator())
      {
         while (iterator.MoveNext())
         {
            yield return iterator.Current;
         }
      }
   }

   public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
   {
      using (var iterator = source.GetEnumerator())
      {
         while (iterator.MoveNext())
         {
            action(iterator.Current);
         }
      }
   }
}