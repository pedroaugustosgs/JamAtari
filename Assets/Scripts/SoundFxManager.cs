using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundFxManager : MonoBehaviour
{
    public static SoundFxManager instance;

    [SerializeField] private AudioSource soundFXObject;
    [SerializeField] private AudioSource soundFXObject2;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    // Update is called once per frame
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLenght = audioSource.clip.length;

        Debug.Log("criou o som");

        Destroy(audioSource.gameObject, clipLenght);
    }
    public void PlaySoundFXClip2(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject2, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLenght = audioSource.clip.length;

        Debug.Log("criou o som");

        Destroy(audioSource.gameObject, clipLenght);
    }
}
