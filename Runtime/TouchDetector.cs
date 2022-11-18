using System;
using UnityEngine;

namespace BurningApe.Touch
{
    public class TouchDetector
    {
        public TouchData _touchData;
        private bool _swipe = false;


        #region Constructor
        public TouchDetector(TouchData newData) => _touchData = newData;
        #endregion


        #region Touch Event
        /// <summary>
        /// Called when player touches the screen.
        /// </summary>
        /// <param name="OnTap"> Event to invoke when player taps the screen.</param>
        /// <param name="OnSwipe"> Event to invoke when player swipes the screen.</param>
        /// <param name="OnTouchMade"> Event to invoke the first time player touches the screen.</param>
        /// <param name="OnTouchEnd"> Event to invoke when player releases finger from the screen.</param>
        /// <param name="invokeInFixedUpdate"> Should this events be invoked in fixed update or not</param>
        public void DetectTouch(TouchEvent OnTap, TouchEvent OnDoubleTap, TouchEvent OnSwipe, 
            TouchEvent OnTouchMade, TouchEvent OnTouchEnd, bool invokeInFixedUpdate, int AmountOfTouches)
        {
            if (AmountOfTouches <= 0) throw new ArgumentException("Amount of touches cant be zero or bellow");  

            if (Input.touchCount > 0)
            {
                for (int i = 0; i < AmountOfTouches; i++)
                {
                    if (i + 1 == Input.touchCount)
                    {
                        // Getting touch.
                        var touch = Input.GetTouch(i);

                        // Set current touch position.
                        _touchData.CurrentPosition = touch.position;

                        // Calculate distance between current touch position and previous.
                        _touchData.Distance = _touchData.CurrentPosition - _touchData.PreviousPosition;


                        switch (touch.phase)
                        {
                            case TouchPhase.Began:
                                // Invoke this event when the finger touches the screen
                                EventsInvoker.InvokeEvent(OnTouchMade, _touchData, invokeInFixedUpdate);

                                break;


                            case TouchPhase.Moved:

                                // Unlock swipe if distance between prev and cur touch pos is bigger than swipe range.
                                if (_touchData.Distance.magnitude > _touchData.SwipeRange)
                                {
                                    _swipe = true;

                                    // Identify direction of swipe.
                                    if (_touchData.PreviousPosition.x < _touchData.CurrentPosition.x)
                                    {
                                        // Right
                                        _touchData.CurrentSwipeDirection = TouchData.SwipeDirections.Right;
                                    }
                                    else if (_touchData.PreviousPosition.x > _touchData.CurrentPosition.x)
                                    {
                                        // Left
                                        _touchData.CurrentSwipeDirection = TouchData.SwipeDirections.Left;
                                    }
                                    else if (_touchData.PreviousPosition.y < _touchData.CurrentPosition.y)
                                    {
                                        // Up
                                        _touchData.CurrentSwipeDirection = TouchData.SwipeDirections.Up;
                                    }
                                    else if (_touchData.PreviousPosition.y > _touchData.CurrentPosition.y)
                                    {
                                        // Down
                                        _touchData.CurrentSwipeDirection = TouchData.SwipeDirections.Down;
                                    }

                                    // Invoke on swipe event
                                    EventsInvoker.InvokeEvent(OnSwipe, _touchData, invokeInFixedUpdate);
                                }

                                break;


                            case TouchPhase.Ended:

                                // Invoke on touch event only if the tap on screen wasnt identified as swipe.
                                if (!_swipe)
                                {
                                    EventsInvoker.InvokeEvent(OnTap, _touchData, invokeInFixedUpdate);
                                    DetectDoubleTap(OnDoubleTap, invokeInFixedUpdate);
                                }
                                _swipe = false;

                                // Invoke this event when the finger is released from the screen
                                EventsInvoker.InvokeEvent(OnTouchEnd, _touchData, invokeInFixedUpdate);

                                break;
                        }

                        // Set previous touch position to current.
                        _touchData.PreviousPosition = _touchData.CurrentPosition;
                    }
                }
            }
        }
        #endregion



        private bool clickMade = false;
        private float prevTime = 0.0f;

        private void DetectDoubleTap(TouchEvent ev, bool invokeInFixedUpdate)
        {
            if (_touchData.DoubleTapTimeBetween == 0) return;

            if (!clickMade) { prevTime = Time.time; clickMade = true; }
            else
            {
                if ((Time.time - prevTime) < 1f) { EventsInvoker.InvokeEvent(ev, _touchData, invokeInFixedUpdate); }

                clickMade = false;
            }
        }
    }
}
