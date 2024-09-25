using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastableBase : MonoBehaviour
{
    public virtual void OnRaycastHit()
    {
        Debug.Log("Base raycast hit");
    }
}
