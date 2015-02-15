using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Security;
using System.IO;
using System.Diagnostics;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string logType = "System";

            EventLog ev = new EventLog(logType, System.Environment.MachineName);
            int LastLogToShow = ev.Entries.Count;
            if (LastLogToShow <= 0)
                Console.WriteLine("No Event Logs in the Log :" + logType);

            // Read the last 2 records in the specified log. 
            int i;
            Console.WriteLine("Searching for System Logs containing the word \"Logon\"\n");
            for (i = ev.Entries.Count - 1; i >= 0; i--)
            {
                EventLogEntry CurrentEntry = ev.Entries[i];
                if (CurrentEntry.Message.IndexOf("Logon") >= 0)
                {
                    Console.WriteLine("Event Number : " + i);
                    Console.WriteLine("Event ID : " + CurrentEntry.EventID);
                    Console.WriteLine("Entry Type : " + CurrentEntry.EntryType.ToString());
                    Console.WriteLine("Message :  " + CurrentEntry.Message + "\n");
                }
            }
            ev.Close();
            Console.WriteLine("Enter any key to exit: ");
            Console.ReadLine();
        }
    }
}
