using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDrop : MonoBehaviour
{
    public GameObject brokenEggSprite;
    public GameObject crackedEggSprite;
    SpriteRenderer thisSpriteRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Basket")
        {
            Destroy(gameObject);
        }        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Grass")
        {
            Vector3 spawnPosition = new Vector3( 
                transform.position.x, 
                transform.position.y, 
                0.0f 
                ); 
            Quaternion spawnRotation = Quaternion.identity; 
            GameObject thisBrokenEgg = Instantiate(brokenEggSprite, spawnPosition, spawnRotation); 
            Destroy(gameObject); 
            Destroy(thisBrokenEgg, 2);
            
            GameObject gameController = GameObject.Find("GameController");
            if (gameController == null)
                return;
            StandardGameController standardScript = gameController.GetComponent<StandardGameController>();
        }
    }


}
