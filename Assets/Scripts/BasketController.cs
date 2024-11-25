using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public Camera cam;
    private float maxWidth;
    void Start()
    {
        if (cam==null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float basketWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - basketWidth;
    }

    void FixedUpdate()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        Rigidbody2D rigidbody2D = new Rigidbody2D();
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);
    }
}
