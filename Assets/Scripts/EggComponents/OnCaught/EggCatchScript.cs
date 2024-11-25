using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCatchScript : MonoBehaviour
{
    public int scoreAdded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Basket")
        {
            ScoreController.scoreValue = ScoreController.scoreValue + scoreAdded;
        }        
    }
}
