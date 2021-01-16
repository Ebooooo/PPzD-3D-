using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioChanger : MonoBehaviour
{
    [SerializeField] private AudioSource outsideAudioSource;
    [SerializeField] private AudioSource insideAudioSource;
    [FMODUnity.EventRef]
    public string outsideAudio;
    public string insideAudio;

    AudioSource activeAudioSource;

    private void Start()
    {
        outsideAudioSource.gameObject.SetActive(false);
        insideAudioSource.gameObject.SetActive(false);
        //przyjmujemy że zawsze startujemy na zewnątrz laboratorium
        activeAudioSource = outsideAudioSource;
        activeAudioSource.gameObject.SetActive(true);
        activeAudioSource.Play();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (activeAudioSource == outsideAudioSource)
            {
                DisableAudiosource();
                activeAudioSource = insideAudioSource;
                EnableAudiosource();
            }
            else if (activeAudioSource == insideAudioSource)
            {
                DisableAudiosource();
                activeAudioSource = outsideAudioSource;
                EnableAudiosource();
            }
        }
    }

    private void DisableAudiosource()
    {
        activeAudioSource.Stop();
        activeAudioSource.gameObject.SetActive(false);
    }

    private void EnableAudiosource()
    {
        activeAudioSource.gameObject.SetActive(true);
        activeAudioSource.Play();
    }
}
