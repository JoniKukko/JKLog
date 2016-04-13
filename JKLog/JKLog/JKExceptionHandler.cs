using System;
using System.Threading;



namespace JKLog
{
    public static class JKExceptionHandler
    {
        /// <summary>
        /// Gets the Thread exception handler.
        /// </summary>
        public static ThreadExceptionEventHandler ThreadException
        {
            get
            {
                return ThreadExceptionHandler;
            }
        }

        
        /// <summary>
        /// Gets the Unhandled exception handler.
        /// </summary>
        public static UnhandledExceptionEventHandler UnhandledException
        {
            get
            {
                return UnhandledExceptionHandler;
            }
        }


        
        private static void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs args)
        {
            // jos castaus onnistuu niin raportoidaan virhe loggerille
            Exception ex = args.Exception as Exception;
            if (ex != null)
                JKLogger.Error(ex.Message, null, ex.GetType().Name);
        }



        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            // jos castaus onnistuu niin raportoidaan virhe loggerille
            Exception ex = args.ExceptionObject as Exception;
            if (ex != null)
                JKLogger.Error(ex.Message, null, ex.GetType().Name);
        }
    }
}
