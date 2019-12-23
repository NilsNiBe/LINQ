using System;

namespace Functor
{
  public class MyMonad<T>
  {
    private T Value { get; }
    public MyMonad(T value) => Value = value;

    public T GetValue() => Value;

    /// <summary> map :: m a -> (a -> b) -> m b </summary>
    public MyMonad<R> Select<R>(Func<T, R> func)
    {
      return new MyMonad<R>(func(Value));
    }

    /// <summary> bind >>= :: m a -> (a -> m b) -> m b  </summary>
    public MyMonad<TResult> SelectMany<TResult>(
      Func<T, MyMonad<TResult>> selector)
    {
      return selector(Value);
    }

    public MyMonad<TResult> SelectMany<TCollection, TResult>(
     Func<T, MyMonad<TCollection>> collectionSelector,
     Func<T, TCollection, TResult> resultSelector)
    {
      return collectionSelector(Value)
        .Select(x => resultSelector(Value, x));
    }

    public static MyMonad<T> Join(MyMonad<MyMonad<T>> nested)
    {
      return new MyMonad<T>(nested.Value.Value);
    }

    public Func<T, MyMonad<S>> Kleisli<R, S>(Func<T, MyMonad<R>> func1, Func<R, MyMonad<S>> func2)
    {
      return t => MyMonad<S>.Join(func1(t).Select(x => func2(x)));
    }

  }
}