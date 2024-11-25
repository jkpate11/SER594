using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDropScript : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Grass") || (col.gameObject.tag == "Destroyer"))
        {
            GameObject gameController = GameObject.Find("GameController");
            if (gameController == null)
                return;
            StandardGameController standardScript = gameController.GetComponent<StandardGameController>();
            
            standardScript.LoseLife();
        }
    }
}
