using UnityEngine;

namespace BurningApe.Touch
{
    [System.Serializable]
    public struct TouchData
    {
        [Tooltip("Swipe range is the length of magnitude between previous touch position and current." +
            " The bigger the range, the further the player will have to move the finger to detect touch as a swipe")] 
        public float SwipeRange;

        [Tooltip("Time interval in span of which the second tap after the first is detected as double tap")]
        public float DoubleTapTimeBetween;

        [Tooltip("Should events be called in fixed update while touch controlls runs in update or not")]
        public bool RunInFixedUpdate;

        [Tooltip("Amount of touches will be detected at once")]
        public int AmountOfTouches;

        [HideInInspector] public Vector2 PreviousPosition;
        [HideInInspector] public Vector2 CurrentPosition;
        [HideInInspector] public Vector2 Distance;
        public enum SwipeDirections
        {
            Right = 0,
            Left = 1,
            Up = 2,
            Down = 3
        }
        [HideInInspector] public SwipeDirections CurrentSwipeDirection;
    }
}
