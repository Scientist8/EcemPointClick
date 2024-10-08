using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    // public static PlayerInputController Instance { get; private set; }

    // =========================================================================

    void Awake()
    {
        // SingletonThisObject();
    }

    // =========================================================================

    void SingletonThisObject()
    {
        // if (Instance == null)
        // {
        //     Instance = this;
        //     DontDestroyOnLoad(this.gameObject);
        // }
        // else
        // {
        //     Destroy(this.gameObject);
        // }
    }

    // =========================================================================

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastIntoTheScene();
        }
    }


    private void RaycastIntoTheScene()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen coordinates to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Output the mouse position
        Debug.Log("Mouse Clicked at: " + worldMousePosition);

        // Shoot a ray from the mouse position into the scene
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Use RaycastHit2D to store the result of the raycast
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        // Check if the ray hit something
        if (hit.collider != null)
        {
            Debug.Log("Ray hit: " + hit.collider.gameObject.name);

            // Get all components that inherit from RaycastableBase
            RaycastableBase[] raycastables = hit.collider.gameObject.GetComponents<RaycastableBase>();

            foreach (RaycastableBase raycastable in raycastables)
            {
                // Call the OnRaycastHit method
                raycastable.OnRaycastHit();
            }
        }
    }

    public GameObject RaycastToGetGridcell()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen coordinates to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Output the mouse position
        Debug.Log("Mouse Clicked at: " + worldMousePosition);

        // Shoot a ray from the mouse position into the scene
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Use RaycastHit2D to store the result of the raycast
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        // Check if the ray hit something
        if (hit.collider != null)
        {
            // Debug.Log("Ray hit: " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("GridCell"))
            {
                // Debug.Log("GridCell hit!");

                return hit.collider.gameObject;
            }
        }
        else
        {
            return null;
        }

        return null;
    }
}