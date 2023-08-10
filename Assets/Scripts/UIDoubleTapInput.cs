using UnityEngine;
using UnityEngine.Events;

public class UIDoubleTapInput : MonoBehaviour
{
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    [System.Serializable]
    public class Event : UnityEvent { }

    [Header("Output")]
    public BoolEvent buttonStateOutputEvent;
    public Event buttonClickOutputEvent;

    private void Update()
    {
        if (Input.touchCount <= 0)
        {
            OutputButtonClickEvent();
        }
        foreach (var touch in Input.touches)
        {
            if (touch.tapCount == 2)
            {
                OutputButtonStateValue(true);
            }
        }
    }

    void OutputButtonStateValue(bool buttonState)
    {
        buttonStateOutputEvent.Invoke(buttonState);
    }

    void OutputButtonClickEvent()
    {
        buttonClickOutputEvent.Invoke();
    }

}
