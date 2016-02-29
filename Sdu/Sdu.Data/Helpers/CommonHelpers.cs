using System;

namespace Sdu.Data.Helpers
{
   public static class CommonHelpers
    {

        //obligatory
        public static T TryItThrice<T>(Func<T> func)
       {
           return TryItNTimes(func,3,1000);
       }

       public static T TryItNTimes<T>(Func<T> func, int times, int delay)
       {
            return p_TryItNTimes<T>(func, times, delay,0);
        }

       private static T p_TryItNTimes<T>(Func<T> func, int times, int delay , int count)
       {
           try
           {
  //yuck but without a real logging framework, we can't change log depth.
                Console.WriteLine(String.Format("Attempting to call {2}  {0} of {1}.", count + 1, times, func.Method.Name));
 
                return func.Invoke();
           }
           catch (Exception ex)
           {

               if (count>=times)
               {
                    Console.WriteLine(String.Format("Failed after {0} attempts with exception {1}",count, ex.Message));
                   throw;
               }
                Console.WriteLine(String.Format("Attempt  {0} of {1} to call {2} failed.  Sleeping for {3} ms.",count+ 1 , times ,  func.Method.Name, delay));
                System.Threading.Thread.Sleep(delay);
               count = count + 1;
               return p_TryItNTimes<T>(func, times, delay, count);
           }

       }
    }
}
