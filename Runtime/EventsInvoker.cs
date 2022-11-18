namespace BurningApe.Touch
{
    public static class EventsInvoker
    {
        public static void InvokeEvent(TouchEvent touchEvent, TouchData data, bool invokeInFixed)
        {
            if (!invokeInFixed) touchEvent.Invoke(data);
            else TouchToFixedConverter.UnlockEvent(touchEvent, data);
        }
    }
}