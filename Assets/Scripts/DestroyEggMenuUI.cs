using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEggMenuUI : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < 0)
            Destroy(gameObject);
    }
}
