using UnityEngine;

namespace BurningApe.Touch
{
    [System.Serializable]
    public struct TouchData
    {
        #region Swipe Range
        /// <summary>
        /// Range within which swipe is detected
        /// </summary>
        public float SwipeRange { get; private set; }
        #endregion

        #region Previous Touch Position
        /// <summary>
        /// The touch position that was made in previous frame
        /// </summary>
        [HideInInspector] public Vector2 PreviousPosition;
        #endregion

        #region Current Touch Position
        /// <summary>
        /// The touch position in this frame
        /// </summary>
        [HideInInspector] public Vector2 CurrentPosition;
        #endregion

        #region Distance 
        /// <summary>
        /// Distance between previous and current touch position
        /// </summary>
        [HideInInspector] public Vector2 Distance;
        #endregion

        #region Swipe Directions
        /// <summary>
        /// Avaliable directions of the swipe.
        /// </summary>
        public enum SwipeDirections
        {
            Right = 0,
            Left = 1,
            Up = 2,
            Down = 3
        }
        #endregion

        #region Current Swipe Direction
        /// <summary>
        /// Current direction of the swipe.
        /// </summary>
        [HideInInspector] public SwipeDirections CurrentSwipeDirection;
        #endregion
    }
}
