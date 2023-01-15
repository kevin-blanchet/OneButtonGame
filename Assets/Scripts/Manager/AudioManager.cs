using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
