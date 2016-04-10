using JKLog.Interface;
using JKLog.Model;
using JKLog.Util;
using System;
using System.Runtime.CompilerServices;



namespace JKLog
{
    /// <summary>
    /// Acts as a facade to the JKLogger library - simplifies usage with methods.
    /// This class is only for writing to the log.
    /// </summary>
    public class JKLogger : IWritable, IDisposable
    {
        private static IWritable defaultWriter = new JKWriter(true);
        private IWritable instanceWriter;
        private string category;



        #region Constructors

        /// <summary>
        /// Initialize a new instance with default mappers.
        /// </summary>
        public JKLogger()
        {
            this.category = null;
            this.instanceWriter = null;
        }



        /// <summary>
        /// Initialize a new instance with named category to use with default mappers.
        /// </summary>
        /// <param name="category">Category where to organize messages.</param>
        public JKLogger(string category)
        {
            this.category = category;
            this.instanceWriter = null;
        }



        /// <summary>
        /// Initialize a new instance with instance mapper.
        /// </summary>
        /// <param name="writer">Override the system default writer for this instance.</param>
        public JKLogger(IWritable writer)
        {
            this.category = null;
            this.instanceWriter = writer;
        }



        /// <summary>
        /// Initialize a new instance with category and instance mapper.
        /// </summary>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="writer">Override the system default writer for this instance.</param>
        public JKLogger(string category, IWritable writer)
        {
            this.category = category;
            this.instanceWriter = writer;
        }

        #endregion



        #region OverrideWriter

        /// <summary>
        /// Overrides default static writer.
        /// </summary>
        /// <param name="writer">IWritable to override default static writer.</param>
        public static void setDefaultWriter(IWritable writer)
        {
            defaultWriter = writer;
        }

        #endregion



        #region Error

        /// <summary>
        /// An error event. This indicates a significant problem the user should know about; usually a loss of functionality or data.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public void Error(string message, object context = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.Error, message, context, category, caller, filePath, lineNumber);

            if (this.instanceWriter != null)
                this.instanceWriter.WriteEntry(newMessage);
            else
                defaultWriter.WriteEntry(newMessage);
        }



        /// <summary>
        /// An error event. This indicates a significant problem the user should know about; usually a loss of functionality or data.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void StaticError(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.Error, message, context, category, caller, filePath, lineNumber);
            defaultWriter.WriteEntry(newMessage);
        }

        #endregion



        #region Warning

        /// <summary>
        /// A warning event. This indicates a problem that is not immediately significant, but that may signify conditions that could cause future problems.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public void Warning(string message, object context = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.Warning, message, context, category, caller, filePath, lineNumber);

            if (this.instanceWriter != null)
                this.instanceWriter.WriteEntry(newMessage);
            else
                defaultWriter.WriteEntry(newMessage);
        }



        /// <summary>
        /// A warning event. This indicates a problem that is not immediately significant, but that may signify conditions that could cause future problems.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void StaticWarning(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.Warning, message, context, category, caller, filePath, lineNumber);
            defaultWriter.WriteEntry(newMessage);
        }

        #endregion



        #region Information

        /// <summary>
        /// An information event. This indicates a significant, successful operation.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public void Information(string message, object context = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.Information, message, context, this.category, caller, filePath, lineNumber);

            if (this.instanceWriter != null)
                this.instanceWriter.WriteEntry(newMessage);
            else
                defaultWriter.WriteEntry(newMessage);
        }



        /// <summary>
        /// An information event. This indicates a significant, successful operation.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void StaticInformation(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.Information, message, context, category, caller, filePath, lineNumber);
            defaultWriter.WriteEntry(newMessage);
        }

        #endregion



        #region SuccessAudit

        /// <summary>
        /// A success audit event. This indicates a security event that occurs when an audited access attempt is successful; for example, logging on successfully.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public void SuccessAudit(string message, object context = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.SuccessAudit, message, context, this.category, caller, filePath, lineNumber);

            if (this.instanceWriter != null)
                this.instanceWriter.WriteEntry(newMessage);
            else
                defaultWriter.WriteEntry(newMessage);
        }



        /// <summary>
        /// A success audit event. This indicates a security event that occurs when an audited access attempt is successful; for example, logging on successfully.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void StaticSuccessAudit(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.SuccessAudit, message, context, category, caller, filePath, lineNumber);
            defaultWriter.WriteEntry(newMessage);
        }

        #endregion



        #region FailureAudit

        /// <summary>
        /// A failure audit event. This indicates a security event that occurs when an audited access attempt fails; for example, a failed attempt to open a file.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public void FailureAudit(string message, object context = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.FailureAudit, message, context, this.category, caller, filePath, lineNumber);

            if (this.instanceWriter != null)
                this.instanceWriter.WriteEntry(newMessage);
            else
                defaultWriter.WriteEntry(newMessage);
        }



        /// <summary>
        /// A failure audit event. This indicates a security event that occurs when an audited access attempt fails; for example, a failed attempt to open a file.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void StaticFailureAudit(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.FailureAudit, message, context, category, caller, filePath, lineNumber);
            defaultWriter.WriteEntry(newMessage);
        }

        #endregion



        #region Debug

        /// <summary>
        /// Detailed debug information.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public void Debug(string message, object context = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.Debug, message, context, this.category, caller, filePath, lineNumber);

            if (this.instanceWriter != null)
                this.instanceWriter.WriteEntry(newMessage);
            else
                defaultWriter.WriteEntry(newMessage);
        }



        /// <summary>
        /// Detailed debug information.
        /// </summary>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void StaticDebug(string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(EntryType.Debug, message, context, category, caller, filePath, lineNumber);
            defaultWriter.WriteEntry(newMessage);
        }

        #endregion



        #region IWritable and overloads

        /// <summary>
        /// Logs with an arbitrary EntryType.
        /// </summary>
        /// <param name="type">One of the EntryType values.</param>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public void WriteEntry(EntryType type, string message, object context = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(type, message, context, this.category, caller, filePath, lineNumber);

            if (this.instanceWriter != null)
                this.instanceWriter.WriteEntry(newMessage);
            else
                defaultWriter.WriteEntry(newMessage);
        }



        /// <summary>
        /// Logs with an arbitrary EntryType.
        /// </summary>
        /// <param name="type">One of the EntryType values.</param>
        /// <param name="message">The value to log.</param>
        /// <param name="context">Extra values to log with the message.</param>
        /// <param name="category">Category where to organize messages.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public static void StaticWriteEntry(EntryType type, string message, object context = null, string category = null, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            IEntry newMessage = new Entry(type, message, context, category, caller, filePath, lineNumber);
            defaultWriter.WriteEntry(newMessage);
        }



        /// <summary>
        /// Logs with an arbitrary EntryType.
        /// </summary>
        /// <param name="entry">IEntry to log.</param>
        public void WriteEntry(IEntry entry)
        {
            if (this.instanceWriter != null)
                this.instanceWriter.WriteEntry(entry);
            else
                defaultWriter.WriteEntry(entry);
        }



        /// <summary>
        /// Logs with an arbitrary EntryType.
        /// </summary>
        /// <param name="entry">IEntry to log.</param>
        public static void StaticWriteEntry(IEntry entry)
        {
            defaultWriter.WriteEntry(entry);
        }

        #endregion



        #region IDisposable

        /// <summary>
        /// Disposes instance writer safely
        /// </summary>
        public void Dispose()
        {
            if (this.instanceWriter != null)
                MapperManager.DisposeMapper(this.instanceWriter);
        }



        /// <summary>
        /// Disposes default writer safely
        /// </summary>
        public static void StaticDispose()
        {
            MapperManager.DisposeDefaultMappers();
        }

        #endregion
    }
}