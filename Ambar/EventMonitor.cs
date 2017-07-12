using AppKit;
using Foundation;

namespace Ambar
{
    public class EventMonitor
    {
        #region Private Members

        NSObject monitor;
		NSEventMask mask;
		GlobalEventHandler handler;

        #endregion

        #region Constructors

        public EventMonitor()
		{
            
		}

		public EventMonitor(NSEventMask mask, GlobalEventHandler handler)
		{
			this.mask = mask;
			this.handler = handler;
		}

        #endregion

        //Destructor
        ~ EventMonitor()
		{
		    Stop(); 
		}

        /// <summary>
        /// Start monitoring events of a given mask.
        /// </summary>
		public void Start()
		{
			monitor = NSEvent.AddGlobalMonitorForEventsMatchingMask(mask, handler) as NSObject;
		}

        /// <summary>
        /// Stop monitoring event and release the resources.
        /// </summary>
		public void Stop()
		{
			if (monitor != null)
			{
				NSEvent.RemoveMonitor(monitor);
				monitor = null;
			}
		}
    }
}
