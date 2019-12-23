using System;

namespace Functor
{
  public interface IFunctor<T>
  {
    IFunctor<R> Select<R>(Func<T, R> func);

    string ToString();
  }
}
