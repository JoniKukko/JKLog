using JKLog.Interface;
using JKLog.Model;
using JKLog.Util;
using System.Runtime.CompilerServices;



namespace JKLog
{
    /// <summary>
    /// Acts as a facade to the JKLogger library - simplifies usage with methods.
    /// This class is only for writing to the log with default mappers.
    /// </summary>
    public static class JKLogger
    {
        private static JKWriter writer = null;
        private static JKWriter Writer
        {
            get
            {
                if (JKLogger.writer == null)
                    JKLogger.writer = new JKWriter(MapperManager.GetDefaultWritables());
                
                return JKLogger.writer;
            }
        }



        #region Error

        /// <summary>
        /// An error event. This indicates a significant problem the user should know about; usually a loss of functionality or data.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void Error(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            JKLogger.Writer.WriteEntry( new Entry(EntryType.Error, message, context, category, caller, filePath, lineNumber) );
        }

        #endregion



        #region Warning
        
        /// <summary>
        /// A warning event. This indicates a problem that is not immediately significant, but that may signify conditions that could cause future problems.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void Warning(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            JKLogger.Writer.WriteEntry( new Entry(EntryType.Warning, message, context, category, caller, filePath, lineNumber) );
        }

        #endregion



        #region Information

        /// <summary>
        /// An information event. This indicates a significant, successful operation.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void Information(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            JKLogger.Writer.WriteEntry( new Entry(EntryType.Information, message, context, category, caller, filePath, lineNumber) );
        }

        #endregion



        #region SuccessAudit
        
        /// <summary>
        /// A success audit event. This indicates a security event that occurs when an audited access attempt is successful; for example, logging on successfully.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void SuccessAudit(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            JKLogger.Writer.WriteEntry( new Entry(EntryType.SuccessAudit, message, context, category, caller, filePath, lineNumber) );
        }

        #endregion



        #region FailureAudit
        
        /// <summary>
        /// A failure audit event. This indicates a security event that occurs when an audited access attempt fails; for example, a failed attempt to open a file.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void FailureAudit(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            JKLogger.Writer.WriteEntry( new Entry(EntryType.FailureAudit, message, context, category, caller, filePath, lineNumber) );
        }

        #endregion



        #region Debug
        
        /// <summary>
        /// Detailed debug information.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void Debug(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            JKLogger.Writer.WriteEntry( new Entry(EntryType.Debug, message, context, category, caller, filePath, lineNumber) );
        }

        #endregion
        


        #region Dispose

        /// <summary>
        /// Disposes default writer safely
        /// </summary>
        public static void Dispose()
        {
            MapperManager.DisposeDefaultMappers();
            JKLogger.writer = null;
        }

        #endregion
    }
}