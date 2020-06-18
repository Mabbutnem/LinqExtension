using System;
using System.Collections.Generic;
using System.Text;

public class Optional<T>
{
   private readonly T value;
   public bool IsPresent { get; }

   private Optional()
   {
      value = default;
      IsPresent = false;
   }
   private Optional(T value)
   {
      if (value == null) { throw new NullReferenceException("Value can't be null. Please, use OfNullable instead"); }
      this.value = value;
      IsPresent = true;
   }

   public static Optional<T> Empty() { return new Optional<T>(); }
   public static Optional<T> Of(T value) { return new Optional<T>(value); }
   public static Optional<T> OfNullable(T value) { return value == null ? Empty() : Of(value); }

   public T Get()
   {
      if (!IsPresent) { throw new InvalidOperationException("Sequence contains no elements"); }
      return value;
   }

   public void IfPresent(Action<T> action)
   {
      if (IsPresent) { action(value); }
   }

   public Optional<T> Where(Predicate<T> predicate)
   {
      if (IsPresent)
      {
         return predicate(value) ? this : Empty();
      }
      return this;
   }

   public Optional<U> Select<U>(Func<T, U> selector)
   {
      if (IsPresent)
      {
         return Optional<U>.OfNullable(selector(value));
      }
      return Optional<U>.Empty();
   }

   public Optional<U> SelectMany<U>(Func<T, Optional<U>> selector)
   {
      if (IsPresent)
      {
         selector(value);
      }
      return Optional<U>.Empty();
   }

   public T OrElse(T other) { return IsPresent ? value : other; }

   public T OrElseGet(Func<T> other) { return IsPresent ? value : other(); }
}
