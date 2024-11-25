using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HardModeController : MonoBehaviour, IGameModeController
{
    public Camera cam;
    public GameObject egg;
    public int livesLeft;
    public Transform livesContainer; 
    public GameObject lifeIconPrefab; 
    public GameObject gameOverText;
    public GameObject restartButton;
    public Slider staminaBar; 
    private float maxWidth;
    public GameObject[] dragons;
    Coroutine CODragonControl;
    Coroutine COLifeEgg;

    public float maxStamina = 100f;
    private float currentStamina;
    public float staminaDrainRate = 20f; 
    public float staminaRegenRate = 5f; 
    private bool isDrainingStamina = false;

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


        InitializeLives();

        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;

        CODragonControl = StartCoroutine(dragonNormalEggLayingControl());
        COLifeEgg = StartCoroutine(dragonLifeEggLayingControl());
    }

    void Update()
    {
        if (livesLeft <= 0)
        {
            if (CODragonControl != null)
                StopCoroutine(CODragonControl);
            if (COLifeEgg != null)
                StopCoroutine(COLifeEgg);
            StartCoroutine(showEndGameMenu());
        }


        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            isDrainingStamina = true;
            DrainStamina();
        }
        else
        {
            isDrainingStamina = false;
            RegenerateStamina();
        }

        staminaBar.value = currentStamina;
        
    }

    void InitializeLives()
    {
        
        foreach (Transform child in livesContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < livesLeft; i++)
        {
            Instantiate(lifeIconPrefab, livesContainer);
        }
    }

    public void LoseLife()
    {
        if (livesLeft > 0)
        {
            livesLeft--;
            livesContainer.GetChild(livesLeft).gameObject.SetActive(false);
        }
    }

    public void GainLife()
    {

        int maxLives = livesContainer.childCount;
        if (livesLeft < maxLives)
        {

            livesContainer.GetChild(livesLeft).gameObject.SetActive(true);
            livesLeft++;
        }
    }

    public float GetCurrentStamina(){
        return currentStamina;
    }

    public void DrainStamina()
    {
        currentStamina -= staminaDrainRate * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    public void RegenerateStamina()
    {
        if (!isDrainingStamina && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }
    }



    IEnumerator showEndGameMenu()
    {
        yield return new WaitForSeconds(0.1f);
        if (!gameOverText.activeSelf)
        {
            gameOverText.SetActive(true);
        }
        if (!restartButton.activeSelf)
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
            dragonIndex = UnityEngine.Random.Range(0, dragons.Length);
            delayTime = UnityEngine.Random.Range(1.0f, 3.0f);

            dragons[dragonIndex].GetComponent<DragonScript>().LayEgg();
            yield return new WaitForSeconds(delayTime);
        }
    }

    public IEnumerator dragonLifeEggLayingControl()
    {
        int dragonIndex = -1;
        float delayTime = 0;
        yield return new WaitForSeconds(7.0f);
        while (true)
        {
            dragonIndex = UnityEngine.Random.Range(0, dragons.Length);
            delayTime = UnityEngine.Random.Range(5.0f, 10.0f);

            dragons[dragonIndex].GetComponent<DragonScript>().LayLifeEgg();
            yield return new WaitForSeconds(delayTime);
        }
    }
}
