using UnityEngine;

namespace BurningApe.Touch
{
    public class TouchControlls : MonoBehaviour
    {
        public TouchData TouchData;
        private TouchDetector _touchDetector;

        public TouchEvent OnTapEvent = new TouchEvent();
        public TouchEvent OnDoubleTapEvent = new TouchEvent();
        public TouchEvent OnSwipeEvent = new TouchEvent();
        public TouchEvent OnTouchMadeEvent = new TouchEvent();
        public TouchEvent OnTouchEndEvent = new TouchEvent();


        private void Awake() => _touchDetector = new(TouchData);


        public void Update()
        {
            _touchDetector
                .DetectTouch(OnTapEvent, OnDoubleTapEvent, OnSwipeEvent, OnTouchMadeEvent, OnTouchEndEvent,
                TouchData.RunInFixedUpdate, TouchData.AmountOfTouches);
        }


        public void FixedUpdate() { if (TouchData.RunInFixedUpdate) TouchToFixedConverter.InvokeFixedEvent(); }
    }
}
