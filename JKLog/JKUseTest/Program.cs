using JKLog;
using JKLog.Configuration;
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
            WindowsEvent events = MapperManager.GetDefaultMapper(typeof(WindowsEvent)) as WindowsEvent;
            if (events != null)
                events.RegisterSource();


            UseTests();
        }


        public static void UseTests()
        {


            Console.WriteLine("*** SIMPLE STATIC TESTS ***");
            
            JKLogger.Error("This is Error");
            JKLogger.Warning("This is Warning");
            JKLogger.Information("This is Information");
            JKLogger.SuccessAudit("This is SuccessAudit");
            JKLogger.FailureAudit("This is FailureAudit");
            JKLogger.Debug("This is Debug");



            Console.WriteLine("*** ADVANCED STATIC TESTS ***");

            User testContext = new User("StaticTestName", 99);

            JKLogger.Error("This is Error", testContext, "TestCategory");
            JKLogger.Warning("This is Warning", testContext, "TestCategory");
            JKLogger.Information("This is Information", testContext, "TestCategory");
            JKLogger.SuccessAudit("This is SuccessAudit", testContext, "TestCategory");
            JKLogger.FailureAudit("This is FailureAudit", testContext, "TestCategory");
            JKLogger.Debug("This is Debug", testContext, "TestCategory");



            // unhandled exception
            // string oops = null;
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
