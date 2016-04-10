using System;
using System.Threading;



namespace JKLog
{
    public static class JKExceptionHandler
    {
        public static ThreadExceptionEventHandler ThreadException
        {
            get
            {
                return ThreadExceptionHandler;
            }
        }



        public static UnhandledExceptionEventHandler UnhandledException
        {
            get
            {
                return UnhandledExceptionHandler;
            }
        }



        private static void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs args)
        {
            Exception ex = args.Exception as Exception;
            if (ex != null)
                JKLogger.StaticError(ex.Message, null, ex.GetType().Name);
        }



        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = args.ExceptionObject as Exception;
            if (ex != null)
                JKLogger.StaticError(ex.Message, null, ex.GetType().Name);
        }
    }
}
