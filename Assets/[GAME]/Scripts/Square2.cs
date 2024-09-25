using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square2 : RaycastableBase
{
    private Vector3 initialPos;
    public override void OnRaycastHit()
    {
        Debug.Log("Square2 hit");

        EventsManager.Instance.ClickedSquare2();
    }

    void OnEnable()
    {
        initialPos = transform.position;

        EventsManager.Instance.OnSquareClicked += OnSquareClick;
        EventsManager.Instance.OnSquare1Clicked += OnSquare1Click;
        EventsManager.Instance.OnSquare2Clicked += OnSquare2Click;
        EventsManager.Instance.OnSquare3Clicked += OnSquare2Click;
        EventsManager.Instance.OnSquare4Clicked += OnSquare3Click;
    }

    void OnDisable()
    {
        EventsManager.Instance.OnSquareClicked -= OnSquareClick;
        EventsManager.Instance.OnSquare1Clicked -= OnSquare1Click;
        EventsManager.Instance.OnSquare2Clicked -= OnSquare2Click;
        EventsManager.Instance.OnSquare3Clicked -= OnSquare2Click;
        EventsManager.Instance.OnSquare4Clicked -= OnSquare3Click;
    }

    private void OnSquareClick()
    {
        Debug.Log("Clicked on yourself dummy, setting initial position");

        transform.position = initialPos;
    }
    private void OnSquare1Click()
    {
        transform.position += Vector3.right * Mathf.Lerp(0, 2, 0.1f);
    }
    private void OnSquare2Click()
    {
        transform.position += Vector3.left * Mathf.Lerp(0, 2, 0.1f);
    }
    private void OnSquare3Click()
    {
        transform.position += Vector3.up * Mathf.Lerp(0, 2, 0.1f);
    }
    private void OnSquare4Click()
    {
        transform.position += Vector3.down * Mathf.Lerp(0, 2, 0.1f);
    }

}
