# Unity Mobile Touch Controls Overview
Unity Mobile Touch Controlls is a tool developed to help Unity developers with implementing touch controlls in games and apps for mobile devices.

## Features
- Supports multitouch.
- Easy to use, subscribe to events with one line.
- Can execute events on FixedUpdate, while Controls run in Update. Useful working with physics.
- Supports double tap.
- Returns touch data struct with all the information about the made touch.
- Returns the direction of swipe (Up, Down, Right, Left).

## Examples
```c#
public class Example : MonoBehaviour
{
    public TouchControlls touchControlls;
    
    private void Start()
    {
        // Add methods to invoke on events with one line
        touchControlls.OnTapEvent.AddListener(SomeMethod1);
        touchControlls.OnSwipeEvent.AddListener(SomeMethod2);
    }
    
    private void SomeMethod1(TouchData data) { }
    private void SomeMethod2(TouchData data) { }
}

```

# Touch Events
## OnTapEvent
- Invokes after one tap on screen.
## OnDoubleTapEvent
- Invokes when player taps the screen two times in small span of time.
## OnSwipeEvent
- Invokes many times while player moves a finger across the screen.
## OnTouchMadeEvent
- Invokes when player touches the screen regardless the touch type (Swipe or tap).
## OnTouchEndEvent 
- Invokes when player releases a finger from the screen regardless the touch type.

