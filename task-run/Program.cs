using System;
using System.Threading.Tasks;

namespace task_run
{
    class Program
    {
        public static void Main()
        {
            // task.run is a quick way to use Task.Factory.StartNew
            // because the tasks are of type System.Threading.Tasks.Task<TResult>, they each have a public Task<TResult>.
            // Result property that contains the result of the computation.
            Task<Double>[] taskArray = { 
                Task<Double>.Factory.StartNew(() => DoComputation(1.0)),
                Task<Double>.Factory.StartNew(() => DoComputation(100.0)),
                Task<Double>.Factory.StartNew(() => DoComputation(1000.0)) 
            };

            var results = new Double[taskArray.Length];
            Double sum = 0;

            for (int i = 0; i < taskArray.Length; i++)
            {
                results[i] = taskArray[i].Result;
                Console.Write("{0:N1} {1}", results[i],
                                  i == taskArray.Length - 1 ? "= " : "+ ");
                sum += results[i];
            }
            Console.WriteLine("{0:N1}", sum);
        }

        private static Double DoComputation(Double start)
        {
            Double sum = 0;
            for (var value = start; value <= start + 10; value += .1)
                sum += value;

            return sum;
        }
    }
}
