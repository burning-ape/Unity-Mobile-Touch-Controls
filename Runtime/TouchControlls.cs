namespace BurningApe.Touch
{
    public class TouchControlls
    {
        private TouchEvents _touchEvents;

        public TouchEvent OnTapEvent = new TouchEvent();
        public TouchEvent OnSwipeEvent = new TouchEvent();
        public TouchEvent OnTouchMadeEvent = new TouchEvent();
        public TouchEvent OnTouchEndEvent = new TouchEvent();
        public TouchEvent OnSwipeOnceEvent = new TouchEvent();

        public TouchControlls(TouchData data) => _touchEvents = new TouchEvents(data);


        public void Run() => _touchEvents
            .OnTouchEvent(OnTapEvent, OnSwipeEvent, OnTouchMadeEvent, OnTouchEndEvent, OnSwipeOnceEvent);

    }
}
