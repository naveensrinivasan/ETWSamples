using System;
namespace ETWSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicEventSource.Run();
            CustomEvent.Run();
        }
    }
}
