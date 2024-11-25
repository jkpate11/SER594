using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBoundController : MonoBehaviour
{
    public Camera cam;
    public GameObject egg;
    public static float remainingTime;
    public float timeCount;
    public Text LifeText;
    public GameObject gameOverText;
    public GameObject restartButton;
    private float maxWidth;
    public GameObject[] dragons;
    Coroutine CODragonControl;
    Coroutine COTimeEgg;
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        remainingTime = timeCount;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float eggWidth = egg.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - eggWidth;
        dragons = GameObject.FindGameObjectsWithTag("Dragon");
        CODragonControl = StartCoroutine(dragonNormalEggLayingControl());
        COTimeEgg = StartCoroutine(dragonTimeEggLayingControl());
    }

    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        remainingTime -= Time.deltaTime;
        LifeText.text = "Remaining Time: " + Math.Max((int)remainingTime,0).ToString();
        if (remainingTime < 0)
        {
            if (CODragonControl != null)
                StopCoroutine(CODragonControl);
            if (COTimeEgg != null)
                StopCoroutine(COTimeEgg);
            StartCoroutine(showEndGameMenu());
        }
    }

    IEnumerator showEndGameMenu()
    {
        yield return new WaitForSeconds(0.1f);
        if (gameOverText.activeSelf == false)
        {
            gameOverText.SetActive(true);
        }
        if (restartButton.activeSelf == false)
        {
            restartButton.SetActive(true);
        }
    }

    public IEnumerator dragonNormalEggLayingControl()
    {
        int dragonIndex = -1;
        float delayTime = 0;
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            dragonIndex = UnityEngine.Random.Range((int)0, (int)dragons.Length);
            delayTime = UnityEngine.Random.Range(1.0f, 0.5f);

            dragons[dragonIndex].GetComponent<DragonScript>().LayEgg();
            yield return new WaitForSeconds(delayTime);
        }
    }

    public IEnumerator dragonTimeEggLayingControl()
    {
        int dragonIndex = -1;
        float delayTime = 0;
        yield return new WaitForSeconds(7.0f);
        while (true)
        {
            dragonIndex = UnityEngine.Random.Range((int)0, (int)dragons.Length);
            delayTime = UnityEngine.Random.Range(5.0f, 10.0f);

            dragons[dragonIndex].GetComponent<DragonScript>().LayTimeEgg();
            yield return new WaitForSeconds(delayTime);
        }
    }

}
