using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCatchScript : MonoBehaviour
{
    public int timeAdded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Basket")
        {
            TimeBoundController.remainingTime = TimeBoundController.remainingTime + timeAdded;
        }        
    }
}
