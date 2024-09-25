using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    // ===========================================================================

    public static EventsManager Instance { get; private set; }

    // ===========================================================================

    //Events and delegates

    public delegate void SquareClickDelegate();
    public event SquareClickDelegate OnSquareClicked;

    public delegate void Square1ClickDelegate();
    public event Square1ClickDelegate OnSquare1Clicked;

    public delegate void Square2ClickDelegate();
    public event Square2ClickDelegate OnSquare2Clicked;

    public delegate void Square3ClickDelegate();
    public event Square3ClickDelegate OnSquare3Clicked;

    public delegate void Square4ClickDelegate();
    public event Square4ClickDelegate OnSquare4Clicked;

    // ===========================================================================


    void Awake()
    {
        SingletonThisObject();
    }

    // ===========================================================================

    private void SingletonThisObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // ===========================================================================

    public void ClickedSquare()
    {
        OnSquareClicked.Invoke();
    }

    public void ClickedSquare1()
    {
        OnSquare1Clicked.Invoke();
    }

    public void ClickedSquare2()
    {
        OnSquare2Clicked.Invoke();
    }

    public void ClickedSquare3()
    {
        OnSquare3Clicked.Invoke();
    }

    public void ClickedSquare4()
    {
        OnSquare4Clicked.Invoke();
    }


}
