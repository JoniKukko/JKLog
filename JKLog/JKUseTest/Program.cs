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
            // BasicExample();
            // ReadFromDefault();
            // ReadFromLocal();
            // UnhandledExceptions();
            // RegisterWindowsEvent();
            // UseTests();
        }



        public static void BasicExample()
        {
            // Uusi information tyyppinen tietue
            JKLogger.Information("Terve 1!");

            JKLogger.Dispose();
        }



        public static void ReadFromDefault()
        {
            // Uusi information tyyppinen tietue
            JKLogger.Information("Terve 2!");

            // haetaan default mapperin instanssi
            IReadable readable = MapperManager.GetDefaultMapper(typeof(Managed)) as IReadable;
            if (readable != null)
            {
                // annetaan instanssi readerille
                using (JKReader reader = new JKReader(readable))
                {
                    // loopataan lukijassa olevat tietueet
                    foreach (IEntry entry in reader)
                        Console.WriteLine(entry.Message);
                }
            }

            JKLogger.Dispose();
        }



        public static void ReadFromLocal()
        {
            // alustukset
            Managed mapper = new Managed();
            JKWriter writer = new JKWriter(mapper);
            Entry entry = new Entry(EntryType.Information, "Terve 3!");

            // kirjoitetaan tietue
            writer.WriteEntry(entry);

            // annetaan instanssi readerille
            using (JKReader reader = new JKReader(mapper))
            {
                // loopataan lukijassa olevat tietueet
                foreach (IEntry e in reader)
                    Console.WriteLine(e.Message);
            }
        }



        public static void UnhandledExceptions()
        {
            // rekisteröidään handler tähän ohjelmaan
            AppDomain.CurrentDomain.UnhandledException += JKExceptionHandler.UnhandledException;

            // ja kaadutaan
            string s = null;
            s.Trim();
        }



        public static void RegisterWindowsEvent()
        {
            // haetaan default mapperin instanssi mapper managerilta
            var events = MapperManager.GetDefaultMapper(typeof(WindowsEvent)) as WindowsEvent;

            // rekisteröidään app.configin mukaisilla arvoilla
            if (events != null)
                events.RegisterSource();
        }


        
        public static void UseTests()
        {
            // simple
            JKLogger.Error("This is Error");
            JKLogger.Warning("This is Warning");
            JKLogger.Information("This is Information");
            JKLogger.SuccessAudit("This is SuccessAudit");
            JKLogger.FailureAudit("This is FailureAudit");
            JKLogger.Debug("This is Debug");
            

            User testContext = new User("StaticTestName", 99);
        
            // more advanced
            JKLogger.Error("This is Error", testContext, "TestCategory");
            JKLogger.Warning("This is Warning", testContext, "TestCategory");
            JKLogger.Information("This is Information", testContext, "TestCategory");
            JKLogger.SuccessAudit("This is SuccessAudit", testContext, "TestCategory");
            JKLogger.FailureAudit("This is FailureAudit", testContext, "TestCategory");
            JKLogger.Debug("This is Debug", testContext, "TestCategory");
            
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
