using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

   public static Optional<T> FindFirst<T>(this IEnumerable<T> source)
   {
      using (var iterator = source.GetEnumerator())
      {
         bool found = iterator.MoveNext();
         if(found)
         {
            return Optional<T>.OfNullable(iterator.Current);
         }
         return Optional<T>.Empty();
      }
   }
}