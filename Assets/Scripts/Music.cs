using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip normalMusic;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        AudioSource music = GetComponent<AudioSource>();

        music.Play();
        yield return new WaitForSeconds(music.clip.length);
        music.clip = normalMusic;
        music.Play();
    }
}
