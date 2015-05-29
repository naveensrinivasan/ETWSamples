using System;
using System.Collections.Generic;
using Microsoft.Diagnostics.Tracing;

namespace ETWSamples
{
    /// <summary>
    /// How to generate dynamic etw events without inheriting and eventsource class.
    /// This is not advisable.
    /// </summary>
    public class DynamicEventSource 
    {
        /// <summary>
        /// The new event source provides an option to log anonymous method.
        /// </summary>
        static EventSource trace = new EventSource("Dynamic");
        public static void LogAnonymousObject() {
            for (int i = 0; i < 10; i++)
            {
                trace.Write("Test", new { Name = "Dynamic Event",
                        Number = i, Date = DateTime.Now });
            }
        }
        /// <summary>
        /// This method logs the custom class with the EventData
        /// attribute. It will serialize things like date,int,string,IEnumerable.
        /// It will not be able to serialize custom objects.
        /// </summary>
        public static void LogCustomClass()
        {
            trace.Write("Custom", new CustomClass()
            {
                Name = "Custom",
                Date = DateTime.Now,
                Number = 100,
                Countries = new[] { "USA", "India" },
                SSN="99999999"
            });
        }
    }
    [EventData]
    public class CustomClass
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<string> Countries { get; set; }
        [EventIgnore]
        public string SSN { get; set; }


    }
}