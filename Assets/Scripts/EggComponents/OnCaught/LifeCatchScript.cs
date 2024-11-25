using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCatchScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Basket")
        {
            GameObject gameController = GameObject.Find("GameController");
            if (gameController == null)
                return;
            StandardGameController standardScript = gameController.GetComponent<StandardGameController>();
            standardScript.GainLife();
            
        }        
    }
}
