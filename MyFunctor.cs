using System;

namespace Functor
{
  public class MyFunctor<T> : IFunctor<T>
  {
    public T Value { get; }
    public MyFunctor(T value) => Value = value;


    public IFunctor<R> Select<R>(Func<T, R> func)
    {
      return new MyFunctor<R>(func(Value));
    }

    public IFunctor<T> Where(Func<T, bool> func)
    {
      return func(Value) ? new MyFunctor<T>(Value) : new MyFunctor<T>(default);
    }

    public override string ToString() => Value.ToString();
  }
}
