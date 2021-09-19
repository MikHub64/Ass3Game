using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip normalMusic;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = normalMusic;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
