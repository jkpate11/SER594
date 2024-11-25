using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public Camera cam;
    private float maxWidth;
    private IGameModeController currentModeController;


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
        currentModeController = FindObjectOfType<StandardGameController>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && GetStamina()>0) {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
            Rigidbody2D rigidbody2D = new Rigidbody2D();
            GetComponent<Rigidbody2D>().MovePosition(targetPosition);
        }
        
    }

    float GetStamina()
    {
        if (currentModeController != null)
        {
            return currentModeController.GetCurrentStamina();
        }
        return 1;
    }

    public void SetMode(IGameModeController newModeController)
    {
        currentModeController = newModeController;
    }


    void SwitchToTimeBoundMode()
    {
        TimeBoundController timeBound = FindObjectOfType<TimeBoundController>();
        BasketController basket = FindObjectOfType<BasketController>();
        basket.SetMode(timeBound);
    }

    void SwitchToHardMode()
    {
        HardModeController hardMode = FindObjectOfType<HardModeController>();
        BasketController basket = FindObjectOfType<BasketController>();
        basket.SetMode(hardMode);
    }

}


public interface IGameModeController
{
    float GetCurrentStamina();
}

