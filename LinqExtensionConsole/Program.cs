using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExtensionConsole
{
   class Program
   {
      static void Main(string[] args)
      {
         List<int> list = new List<int>() { 1, 2, 4, 3, 5 };
         List<int> emptyList = new List<int>() {};

         int i1 = list
            .Where(i => i >= 2)
            .Peek(i => Console.WriteLine(i))
            .FindFirst()
            .OrElseGet(() => 1000);

         int i2 = emptyList
            .Where(i => i >= 2)
            .Peek(i => Console.WriteLine(i))
            .FindFirst()
            .OrElseGet(() => 1000);

         Console.WriteLine(i1);
         Console.WriteLine(i2);
      }
   }
}
