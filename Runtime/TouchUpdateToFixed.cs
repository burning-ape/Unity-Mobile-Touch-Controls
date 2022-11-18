using System.Collections.Generic;

namespace BurningApe.Touch
{
    public static class TouchToFixedConverter
    {
        private static bool isLocked = true;
        public static Queue<TouchEvent> EventsToInvoke = new();
        public static TouchData touchData;


        public static void UnlockEvent(TouchEvent touchEvent, TouchData data)
        {
            isLocked = false;

            EventsToInvoke.Enqueue(touchEvent);
            touchData = data;
        }


        public static void InvokeFixedEvent()
        {
            if (!isLocked)
            {
                isLocked = true;

                foreach (var ev in EventsToInvoke)
                {
                    ev.Invoke(touchData);
                }

                EventsToInvoke.Clear();
            }
        }
    }
}

