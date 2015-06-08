using Microsoft.Diagnostics.Tracing;
using System.Threading;

namespace ETWSamples
{
    public sealed class CustomEvent: EventSource
    {
        public static CustomEvent Instance = new CustomEvent();
        [Event(1, Opcode = EventOpcode.Start)]
        public void RequestStart(int RequestID ) { WriteEvent(1, RequestID ); }
        [Event(2, Opcode = EventOpcode.Stop)]
        public void RequestStop(int RequestID) { WriteEvent(2, RequestID); }

        /// <summary>
        /// With this perfview would show the duration it took to complete an event based on the 
        /// naming convention.
        /// This could also be used for stopping perfview when the duration of this took more than what 
        /// is expected.
        /// </summary>
        public static void Run()
        {
            for (int i = 1; i < 12; i++)
            {
                CustomEvent.Instance.RequestStart(i);
                if ((i % 2) == 0) {
                    Thread.Sleep(5000);
                }
                CustomEvent.Instance.RequestStop(i);
            }
        }
    }
}
