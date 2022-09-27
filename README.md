# Unity Mobile Touch Controls Overview
Unity Mobile Touch Controlls is a tool developed to help Unity developers with implementing touch controlls in games and apps for mobile devices.

# Guide
1. Download and import the package into your project.

2. Open the script in which you will operate with touch controlls.

3. Define and initialize Touch Data struct as global variable and make it either public or with SerializeField attribute to make it visible in Inspector.

4. Define TouchControlls class as global variable and in Start Method initialize it passing down TouchData as argument in constructor.

5. In Start method add methods to invoke in TouchControlls events you need.

6. In Update method call TouchControlls Run method so it will detect touch input.

7. Methods, used as listeners in TouchControlls event should have TouchData as argument, because TouchControlls returns TouchData varibles.

## Example
[![Example.png](https://i.postimg.cc/ZRVNT0TK/Example.png)](https://postimg.cc/YGL0RrGJ)]

# Touch Events
## OnTapEvent
- Invokes after one tap on screen.
## OnSwipeEvent
- Invokes many times while player moves a finger across the screen.
## OnSwipeEventOnce
- Invokes once when player moves a finger across the screen.
## OnTouchMadeEvent
- Invokes when player touches the screen.
## OnTouchEndEvent 
- Invokes when player releases a finger from the screen.
