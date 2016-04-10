using JKLog;
using JKLog.Interface;
using JKLog.Mapper;
using JKLog.Model;
using System;

namespace JKUseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //   AppDomain.CurrentDomain.UnhandledException += JKExceptionHandler.UnhandledException;
            WindowsEvent.RegisterSource();

            JKLogger logger = new JKLogger();

            logger.Information("Testi temppeli matikainen");

        }


        public static void UseTests()
        {


            Console.WriteLine("*** SIMPLE STATIC TESTS ***");

            JKLogger.StaticError("This is Error");
            JKLogger.StaticWarning("This is Warning");
            JKLogger.StaticInformation("This is Information");
            JKLogger.StaticSuccessAudit("This is SuccessAudit");
            JKLogger.StaticFailureAudit("This is FailureAudit");
            JKLogger.StaticDebug("This is Debug");


            Console.WriteLine("*** SIMPLE INSTANCE TESTS ***");

            JKLogger logger = new JKLogger();

            logger.Error("This is Error");
            logger.Warning("This is Warning");
            logger.Information("This is Information");
            logger.SuccessAudit("This is SuccessAudit");
            logger.FailureAudit("This is FailureAudit");
            logger.Debug("This is Debug");



            Console.WriteLine("*** ADVANCED STATIC TESTS ***");

            User StaticTestContext = new User("StaticTestName", 99);

            JKLogger.StaticError("This is Error", StaticTestContext, "StaticTestCategory");
            JKLogger.StaticWarning("This is Warning", StaticTestContext, "StaticTestCategory");
            JKLogger.StaticInformation("This is Information", StaticTestContext, "StaticTestCategory");
            JKLogger.StaticSuccessAudit("This is SuccessAudit", StaticTestContext, "StaticTestCategory");
            JKLogger.StaticFailureAudit("This is FailureAudit", StaticTestContext, "StaticTestCategory");
            JKLogger.StaticDebug("This is Debug", StaticTestContext, "StaticTestCategory");



            Console.WriteLine("*** ADVANCED INSTANCE TESTS ***");

            User InstanceTestContext = new User("InstanceTestName", 99);
            JKLogger logger2 = new JKLogger("InstanceTestCategory");

            logger2.Error("This is Error", InstanceTestContext);
            logger2.Warning("This is Warning", InstanceTestContext);
            logger2.Information("This is Information", InstanceTestContext);
            logger2.SuccessAudit("This is SuccessAudit", InstanceTestContext);
            logger2.FailureAudit("This is FailureAudit", InstanceTestContext);
            logger2.Debug("This is Debug", InstanceTestContext);



            // unhandled exception
            string oops = null;
            // oops.Trim();
        }


    }






    class User
    {
        public string name;
        public int age;

        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return "[name: " + name + ", age: " + age + " ]";
        }
    }
}
