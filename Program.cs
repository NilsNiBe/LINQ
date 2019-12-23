using System;

namespace Functor
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // FunctorExample();
      MonadExample();
    }

    private static void MonadExample()
    {
      var myMonad = new MyMonad<MyMonad<int>>(new MyMonad<int>(24));
      var v =
        from m1 in myMonad
        from m2 in m1
        select m2;
      Console.WriteLine(v.GetValue());
    }

    private static void FunctorExample()
    {
      var myFunctor = new MyFunctor<int>(3);
      var stringFunctor =
        from f in myFunctor
        where f > 10
        select f.ToString();
      Console.WriteLine(stringFunctor);

      var myFunctor2 = new MyFunctor<int>(42);
      var stringFunctor2 =
        from f in myFunctor2
        where f > 10
        select f.ToString();
      Console.WriteLine(stringFunctor2);
    }
  }
}
