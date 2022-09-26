using UnityEngine;

namespace BurningApe.Touch
{
    public class TouchEvents
    {
        public TouchData _touchData;
        private bool _swipe = false;


        #region Constructor
        public TouchEvents(TouchData newData) => _touchData = newData;
        #endregion


        #region Touch Event

        /// <summary>
        /// Called when player touches the screen.
        /// </summary>
        /// <param name="OnTapEvent"> Event to invoke when player taps the screen.</param>
        /// <param name="OnSwipeEvent"> Event to invoke when player swipes the screen.</param>
        /// <param name="OnTouchMade"> Event to invoke the first time player touches the screen.</param>
        /// <param name="OnTouchEnd"> Event to invoke when player releases finger from the screen.</param>
        /// <param name="OnSwipeOnce"> Evebt to invoke when player releases finger only after the swipe</param>
        public void OnTouchEvent(TouchEvent OnTapEvent, TouchEvent OnSwipeEvent, 
            TouchEvent OnTouchMade, TouchEvent OnTouchEnd, TouchEvent OnSwipeOnce)
        {
            if (Input.touchCount > 0)
            {
                // Getting touch.
                var touch = Input.GetTouch(0);

                // Set current touch position.
                _touchData.CurrentPosition = touch.position;

                // Calculate distance between current touch position and previous.
                _touchData.Distance = _touchData.CurrentPosition - _touchData.PreviousPosition;


                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // Invoke this event when the finger touches the screen
                        OnTouchMade.Invoke(_touchData);

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
                            OnSwipeEvent.Invoke(_touchData);
                        }

                        break;


                    case TouchPhase.Ended:

                        // Invoke on touch event only if the tap on screen wasnt identified as swipe.
                        if (!_swipe) OnTapEvent.Invoke(_touchData);
                        else OnSwipeOnce.Invoke(_touchData);

                        // Lock swipe after calling touch event.
                        _swipe = false;

                        // Invoke this event when the finger is released from the screen
                        OnTouchEnd.Invoke(_touchData);

                        break;
                }

                // Set previous touch position to current.
                _touchData.PreviousPosition = _touchData.CurrentPosition;
            }
        }
        #endregion
    }
}
