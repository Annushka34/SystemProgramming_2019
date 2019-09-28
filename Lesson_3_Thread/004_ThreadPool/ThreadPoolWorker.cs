using System;
using System.Threading;

namespace AsyncProgramming
{
    internal class ThreadPoolWorker<T>
    {
        private readonly Func<object, T> func;
        private T result;

        public ThreadPoolWorker(Func<object, T> func)
        {
            this.func = func ?? throw new ArgumentNullException(nameof(func));
            result = default;
        }

        public bool Success { get; private set; } = false;
        public bool Completed { get; private set; } = false;
        public Exception Exception { get; private set; } = null;
        public T Result
        {
            get
            {
                while (Completed == false)
                {
                    Thread.Sleep(150);
                }

                return Success == true && Exception == null ? result : throw Exception;
            }
        }

        public void Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), state);
        }

        private void ThreadExecution(object state)
        {
            try
            {
                result = func.Invoke(state);
                Success = true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                Success = false;
            }
            finally
            {
                Completed = true;
            }
        }
    }

}
