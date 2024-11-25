using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonScript : MonoBehaviour
{
    public GameObject egg;
    public GameObject lifeEgg;
    public GameObject timeEgg;
    private AudioSource source;
    private Object[] drop;
    private Object[] dragon;
    
    void Start()
    {
        dragon = Resources.LoadAll("SFX/dragon",typeof(AudioClip));
        drop = Resources.LoadAll("SFX/drop", typeof(AudioClip));
        source = GetComponent<AudioSource>();
    }
    
    public void LayEgg()
    {
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            0.0f
            );
        Quaternion spawnRotation = Quaternion.identity;

        var sound = (AudioClip)dragon[Random.Range(0, dragon.Length)];
        source.PlayOneShot(sound, (float)0.5);
        sound = (AudioClip)drop[Random.Range(0, drop.Length)];
        source.PlayOneShot(sound);
        Instantiate(egg, spawnPosition, spawnRotation);
    }

    public void LayLifeEgg()
    {
        if (lifeEgg != null)
        {
            Vector3 spawnPosition = new Vector3(
                transform.position.x,
                transform.position.y,
                0.0f
                );
            Quaternion spawnRotation = Quaternion.identity;

            var sound = (AudioClip)dragon[Random.Range(0, dragon.Length)];
            source.PlayOneShot(sound, (float)0.5);
            sound = (AudioClip)drop[Random.Range(0, drop.Length)];
            source.PlayOneShot(sound);
            Instantiate(lifeEgg, spawnPosition, spawnRotation);
        }
    }

    public void LayTimeEgg()
    {
        if (timeEgg != null)
        {
            Vector3 spawnPosition = new Vector3(
                transform.position.x,
                transform.position.y,
                0.0f
                );
            Quaternion spawnRotation = Quaternion.identity;

            var sound = (AudioClip)dragon[Random.Range(0, dragon.Length)];
            source.PlayOneShot(sound, (float)0.5);
            sound = (AudioClip)drop[Random.Range(0, drop.Length)];
            source.PlayOneShot(sound);
            Instantiate(timeEgg, spawnPosition, spawnRotation);
        }
    }
}
