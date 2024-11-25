using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Camera cam;
    public GameObject egg;
    private float maxWidth;
    public Text timerText;
    public float remainingTime;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject[] dragons;

    Coroutine CODragonControl;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float eggWidth = egg.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - eggWidth;

        dragons = GameObject.FindGameObjectsWithTag("Dragon");

        CODragonControl = StartCoroutine(dragonControl());
    }

    void FixedUpdate()
    {
        remainingTime -= Time.deltaTime; 
        if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        UpdateText();
        if (remainingTime == 0)
        {
            if (CODragonControl != null)
                StopCoroutine(CODragonControl);
            StartCoroutine(showEndGameMenu());
        }

    }
    IEnumerator showEndGameMenu()
    {
        yield return new WaitForSeconds(1.0f);
        if (gameOverText.activeSelf == false)
        {
            gameOverText.SetActive(true);
        }
        if (restartButton.activeSelf == false)
        {
            restartButton.SetActive(true);
        }
    }

    void UpdateText()
    {
        timerText.text = "Remaining Time:\n" + Mathf.RoundToInt(remainingTime).ToString();
    }

    public IEnumerator dragonControl()
    {
        int dragonIndex = -1;
        float delayTime = 0;
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            dragonIndex = UnityEngine.Random.Range((int)0, (int)dragons.Length);
            delayTime = UnityEngine.Random.Range(1.0f, 3.0f);

            dragons[dragonIndex].GetComponent<DragonScript>().LayEgg();
            yield return new WaitForSeconds(delayTime);
        }
    }

}